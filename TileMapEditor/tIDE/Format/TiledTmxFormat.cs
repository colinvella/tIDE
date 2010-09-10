using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;

using xTile;
using xTile.Dimensions;
using xTile.Format;
using xTile.ObjectModel;
using xTile.Layers;
using xTile.Tiles;

using TileMapEditor.Compression.Zlib;
using TileMapEditor.Dialogs;

namespace TileMapEditor.Format
{
    public enum TmxEncoding
    {
        Xml,
        Base64,
        Base64Gzip,
        Base64Zlib,
        Csv
    }

    internal class TiledTmxFormat: IMapFormat
    {
        private class DummyComponent : Component
        {
        }

        private void LoadProperties(XmlHelper xmlHelper, Component component)
        {
            while (xmlHelper.AdvanceStartRepeatedElement("property", "properties"))
            {
                string propertyKey = xmlHelper.GetAttribute("name");
                string propertyValue = xmlHelper.GetAttribute("value");

                component.Properties[propertyKey] = propertyValue;

                xmlHelper.AdvanceEndElement("property");
            }
        }

        private void StoreProperties(Component component, XmlWriter xmlWriter)
        {
            // properties are an optional element in TMX
            if (component.Properties.Count == 0)
                return;

            xmlWriter.WriteStartElement("properties");

            foreach (KeyValuePair<string, PropertyValue> keyValuePair in component.Properties)
            {
                xmlWriter.WriteStartElement("property");
                xmlWriter.WriteAttributeString("name", keyValuePair.Key);
                xmlWriter.WriteAttributeString("value", keyValuePair.Value.ToString());
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        private void LoadTileSet(XmlHelper xmlHelper, Map map)
        {
            string id = xmlHelper.GetAttribute("name");

            int firstGid = xmlHelper.GetIntAttribute("firstgid");

            int tileWidth = xmlHelper.GetIntAttribute("tilewidth");
            int tileHeight = xmlHelper.GetIntAttribute("tileheight");
            Size tileSize = new Size(tileWidth, tileHeight);

            int marginValue = xmlHelper.GetIntAttribute("margin", 0);
            Size margin = new Size(marginValue);

            int spacingValue = xmlHelper.GetIntAttribute("spacing", 0);
            Size spacing = new Size(spacingValue);

            xmlHelper.AdvanceStartElement("image");
            string imageSource = xmlHelper.GetAttribute("source");
            xmlHelper.AdvanceEndElement("image");
            
            Size sheetSize = new Size();
            try
            {
                using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(imageSource))
                {
                    sheetSize.Width = (bitmap.Width + spacingValue - marginValue) / (tileWidth + spacingValue);
                    sheetSize.Height = (bitmap.Height + spacingValue - marginValue) / (tileHeight + spacingValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to determine sheet size from image source", exception);
            }

            TileSheet tileSheet = new TileSheet(id, map, imageSource, sheetSize, tileSize);
            tileSheet.Margin = margin;
            tileSheet.Spacing = spacing;

            // keep track of first gid as custom property
            tileSheet.Properties["@FirstGid"] = firstGid;

            // also add lastgid to facilitate import
            tileSheet.Properties["@LastGid"] = firstGid + tileSheet.TileCount - 1;

            // properties at tile level within tile sets not supported
            // but are mapped as prefixed properties at tile sheet level
            XmlNodeType xmlNodeType = xmlHelper.AdvanceNode();
            while (xmlNodeType == XmlNodeType.Element && xmlHelper.XmlReader.Name == "tile")
            {
                int tileId = xmlHelper.GetIntAttribute("id");
                xmlHelper.AdvanceNamedNode(XmlNodeType.Element, "properties");
                Component dummyComponent = new DummyComponent();
                LoadProperties(xmlHelper, dummyComponent);
                xmlHelper.AdvanceEndElement("tile");

                foreach (string propertyName in dummyComponent.Properties.Keys)
                {
                    tileSheet.Properties["@Tile@" + tileId + "@" + propertyName]
                        = dummyComponent.Properties[propertyName];
                }

                xmlNodeType = xmlHelper.AdvanceNode();
            }

            map.AddTileSheet(tileSheet);
        }

        private void StoreTileSet(TileSheet tileSheet, int firstGid, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("tileset");

            xmlWriter.WriteAttributeString("firstgid", firstGid.ToString());
            xmlWriter.WriteAttributeString("name", tileSheet.Id);
            xmlWriter.WriteAttributeString("tilewidth", tileSheet.TileSize.Width.ToString());
            xmlWriter.WriteAttributeString("tileheight", tileSheet.TileSize.Height.ToString());
            xmlWriter.WriteAttributeString("spacing", tileSheet.Spacing.Width.ToString());
            xmlWriter.WriteAttributeString("margin", tileSheet.Margin.Width.ToString());

            xmlWriter.WriteStartElement("image");
            xmlWriter.WriteAttributeString("source", tileSheet.ImageSource);
            xmlWriter.WriteEndElement();

            // if tileset tile properties were imported and converted to tilesheet properties,
            // try to convert them back
            int lastTileIndex = -1;
            foreach (string propertyName in tileSheet.Properties.Keys)
            {
                if (!propertyName.StartsWith("@Tile@"))
                    continue;

                string[] tokens = propertyName.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 3)
                    continue;

                int tileIndex = 0;
                if (!int.TryParse(tokens[1], out tileIndex))
                    continue;

                string tilePropertyName = tokens[2];
                string tilePropertyValue = tileSheet.Properties[propertyName];

                if (tileIndex != lastTileIndex)
                {
                    if (lastTileIndex != -1)
                    {
                        // properties closing tag
                        xmlWriter.WriteEndElement();

                        // item closing tag
                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteStartElement("tile");
                    xmlWriter.WriteAttributeString("id", tileIndex.ToString());
                    xmlWriter.WriteStartElement("properties");
                }

                xmlWriter.WriteStartElement("property");
                xmlWriter.WriteAttributeString("name", tilePropertyName);
                xmlWriter.WriteAttributeString("value", tilePropertyValue);
                xmlWriter.WriteEndElement();

                lastTileIndex = tileIndex;
            }

            if (lastTileIndex != -1)
            {
                // properties closing tag
                xmlWriter.WriteEndElement();

                // item closing tag
                xmlWriter.WriteEndElement();
            }

            // tileset close tag
            xmlWriter.WriteEndElement();
        }

        private void StoreTileSets(ReadOnlyCollection<TileSheet> tileSheets, XmlWriter xmlWriter)
        {
            int firstGid = 1;
            foreach (TileSheet tileSheet in tileSheets)
            {
                StoreTileSet(tileSheet, firstGid, xmlWriter);
                firstGid += tileSheet.TileCount;
            }
        }

        private Tile LoadStaticTile(Layer layer, int gid)
        {
            if (gid == 0)
                return null;

            TileSheet selectedTileSheet = null;
            int tileIndex = -1;
            foreach (TileSheet tileSheet in layer.Map.TileSheets)
            {
                int firstGid = tileSheet.Properties["@FirstGid"];
                int lastGid = tileSheet.Properties["@LastGid"];

                if (gid >= firstGid && gid <= lastGid)
                {
                    selectedTileSheet = tileSheet;
                    tileIndex = gid - firstGid;

                    break;
                }
            }

            if (selectedTileSheet == null)
                throw new Exception("Invalid tile gid: " + gid);

            return new StaticTile(layer, selectedTileSheet, BlendMode.Alpha, tileIndex);
        }

        private void LoadLayerDataXml(XmlHelper xmlHelper, Layer layer)
        {
            Location tileLocation = Location.Origin;

            while (xmlHelper.AdvanceStartRepeatedElement("tile", "data"))
            {
                int gid = xmlHelper.GetIntAttribute("gid");

                layer.Tiles[tileLocation] = LoadStaticTile(layer, gid);

                ++tileLocation.X;
                if (tileLocation.X >= layer.LayerSize.Width)
                {
                    tileLocation.X = 0;
                    ++tileLocation.Y;
                }
            }
        }

        private void LoadLayerDataBase64(XmlHelper xmlHelper, Layer layer, string dataCompression)
        {
            xmlHelper.AdvanceNode(XmlNodeType.Text);

            string base64Data = xmlHelper.XmlReader.Value;

            byte[] dataBytes = System.Convert.FromBase64String(base64Data);

            if (dataCompression == "none")
            {
                // do nothing
            }
            else if (dataCompression == "gzip")
            {
                GZipStream inGZipStream = new GZipStream(
                    new MemoryStream(dataBytes), CompressionMode.Decompress);

                MemoryStream outMemoryStream = new MemoryStream();

                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = inGZipStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    outMemoryStream.Write(buffer, 0, bytesRead);
                }

                dataBytes = outMemoryStream.ToArray();
            }
            else if (dataCompression == "zlib")
            {
                ZInputStream inZInputStream = new ZInputStream(
                    new MemoryStream(dataBytes));

                MemoryStream outMemoryStream = new MemoryStream();

                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = inZInputStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    outMemoryStream.Write(buffer, 0, bytesRead);
                }

                dataBytes = outMemoryStream.ToArray();
            }
            else
                throw new Exception("Unknown compression scheme: " + dataCompression);

            if (dataBytes.Length % 4 != 0)
                throw new Exception("Base64 byte stream size must be a mutliple of 4 bytes");

            Location tileLocation = Location.Origin;
            for (int byteIndex = 0; byteIndex < dataBytes.Length; byteIndex += 4)
            {
                int gid =
                    dataBytes[byteIndex] |
                    dataBytes[byteIndex + 1] << 8 |
                    dataBytes[byteIndex + 2] << 16 |
                    dataBytes[byteIndex + 3] << 24;

                layer.Tiles[tileLocation] = LoadStaticTile(layer, gid);

                ++tileLocation.X;
                if (tileLocation.X >= layer.LayerSize.Width)
                {
                    tileLocation.X = 0;
                    ++tileLocation.Y;
                }
            }

            xmlHelper.AdvanceEndElement("data");
        }

        private void LoadLayerDataCsv(XmlHelper xmlHelper, Layer layer)
        {
            xmlHelper.AdvanceNode(XmlNodeType.Text);

            XmlReader xmlReader = xmlHelper.XmlReader;

            string csvData = xmlReader.Value;
            string[] csvElements = csvData.Split(new char[] { ',', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            Location tileLocation = Location.Origin;
            foreach (string csvElement in csvElements)
            {
                int gid = int.Parse(csvElement);

                layer.Tiles[tileLocation] = LoadStaticTile(layer, gid);

                ++tileLocation.X;
                if (tileLocation.X >= layer.LayerSize.Width)
                {
                    tileLocation.X = 0;
                    ++tileLocation.Y;
                }
            }

            xmlHelper.AdvanceEndElement("data");
        }

        private void LoadLayer(XmlHelper xmlHelper, Map map)
        {
            if (map.TileSheets.Count == 0)
                throw new Exception("Must load at least one tileset to determine layer tile size");

            string id = xmlHelper.GetAttribute("name");

            int layerWidth = xmlHelper.GetIntAttribute("width");
            int layerHeight = xmlHelper.GetIntAttribute("height");
            Size layerSize = new Size(layerWidth, layerHeight);

            int visible = xmlHelper.GetIntAttribute("visible", 1);

            // must assume tile size from first tile set
            Size tileSize = map.TileSheets[0].TileSize;

            Layer layer = new Layer(id, map, layerSize, tileSize);
            layer.Visible = visible > 0;

            // load properties if available
            XmlNodeType xmlNodeType = xmlHelper.AdvanceNode();
            if (xmlNodeType == XmlNodeType.Element && xmlHelper.XmlReader.Name == "properties")
            {
                LoadProperties(xmlHelper, layer);

                // try to obtain layer description via custom property
                if (layer.Properties.ContainsKey("@Description"))
                    layer.Description = layer.Properties["@Description"];

                xmlHelper.AdvanceStartElement("data");
            }
            else if (xmlNodeType != XmlNodeType.Element || xmlHelper.XmlReader.Name != "data")
                throw new Exception("The element <properties> or <data> expected");

            string dataEncoding = xmlHelper.GetAttribute("encoding", "xml");
            string dataCompression = xmlHelper.GetAttribute("compression", "none");

            if (dataEncoding == "xml")
                LoadLayerDataXml(xmlHelper, layer);
            else if (dataEncoding == "base64")
                LoadLayerDataBase64(xmlHelper, layer, dataCompression);
            else if (dataEncoding == "csv")
                LoadLayerDataCsv(xmlHelper, layer);
            else
                throw new Exception("Unknown encoding/compression setting combination (" + dataEncoding + "/" + dataCompression + ")");

            xmlHelper.AdvanceEndElement("layer");

            map.AddLayer(layer);
        }

        private byte[] ConvertTileIndicesToBytes(List<int> tileIndices)
        {
            byte[] tileBytes = new byte[tileIndices.Count * 4];
            int byteIndex = 0;
            foreach (int tileIndex in tileIndices)
            {
                tileBytes[byteIndex++] = (byte)(tileIndex & 0xFF);
                tileBytes[byteIndex++] = (byte)((tileIndex >> 8) & 0xFF);
                tileBytes[byteIndex++] = (byte)((tileIndex >> 16) & 0xFF);
                tileBytes[byteIndex++] = (byte)((tileIndex >> 24) & 0xFF);
            }

            return tileBytes;
        }

        private void StoreLayerDataXml(List<int> tileIndices, XmlWriter xmlWriter)
        {
            foreach (int tileIndex in tileIndices)
            {
                xmlWriter.WriteStartElement("tile");
                xmlWriter.WriteAttributeString("gid", tileIndex.ToString());
                xmlWriter.WriteEndElement();
            }
        }

        private void StoreLayerDataBase64(List<int> tileIndices, XmlWriter xmlWriter, string dataCompression)
        {
            byte[] tileBytes = ConvertTileIndicesToBytes(tileIndices);

            if (dataCompression == "none")
            {
                string base64Data = Convert.ToBase64String(tileBytes);
                xmlWriter.WriteString(base64Data);
            }
            else if (dataCompression == "gzip")
            {
                MemoryStream inMemoryStream = new MemoryStream(tileBytes);
                MemoryStream outMemoryStream = new MemoryStream();
                GZipStream outGZipStream = new GZipStream(outMemoryStream, CompressionMode.Compress);

                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = inMemoryStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    outGZipStream.Write(buffer, 0, bytesRead);
                }
                outGZipStream.Close();

                byte[] compressedBytes = outMemoryStream.ToArray();
                string base64Data = Convert.ToBase64String(compressedBytes);
                xmlWriter.WriteString(base64Data);
            }
            else if (dataCompression == "zlib")
            {
                MemoryStream inMemoryStream = new MemoryStream(tileBytes);
                MemoryStream outMemoryStream = new MemoryStream();
                ZOutputStream zOutputStream = new ZOutputStream(outMemoryStream, 9);

                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = inMemoryStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    zOutputStream.Write(buffer, 0, bytesRead);
                }
                zOutputStream.Close();

                byte[] compressedBytes = outMemoryStream.ToArray();
                string base64Data = Convert.ToBase64String(compressedBytes);
                xmlWriter.WriteString(base64Data);
            }
        }

        private void StoreLayerDataCsv(List<int> tileIndices, XmlWriter xmlWriter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int tileIndex in tileIndices)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(',');
                stringBuilder.Append(tileIndex);
            }
            xmlWriter.WriteString(stringBuilder.ToString());
        }

        private void StoreLayer(Layer layer, XmlWriter xmlWriter, TmxEncoding tmxEncoding)
        {
            xmlWriter.WriteStartElement("layer");

            xmlWriter.WriteAttributeString("name", layer.Id);
            xmlWriter.WriteAttributeString("width", layer.LayerSize.Width.ToString());
            xmlWriter.WriteAttributeString("height", layer.LayerSize.Height.ToString());

            // visible by default - specify property otherwise
            if (!layer.Visible)
                xmlWriter.WriteAttributeString("visible", "0");

            // handle description as custom property
            layer.Properties["@Description"] = layer.Description;

            // store properties
            StoreProperties(layer, xmlWriter);

            xmlWriter.WriteStartElement("data");

            switch (tmxEncoding)
            {
                case TmxEncoding.Xml:
                    xmlWriter.WriteAttributeString("encoding", "xml");
                    break;
                case TmxEncoding.Base64:
                    xmlWriter.WriteAttributeString("encoding", "base64");
                    break;
                case TmxEncoding.Base64Gzip:
                    xmlWriter.WriteAttributeString("encoding", "base64");
                    xmlWriter.WriteAttributeString("compression", "gzip");
                    break;
                case TmxEncoding.Base64Zlib:
                    xmlWriter.WriteAttributeString("encoding", "base64");
                    xmlWriter.WriteAttributeString("compression", "zlib");
                    break;
                case TmxEncoding.Csv:
                    xmlWriter.WriteAttributeString("encoding", "csv");
                    break;
            }

            // annotate tilesheets with first gid to simplify mapping
            int firstGid = 1;
            foreach (TileSheet tileSheet in layer.Map.TileSheets)
            {
                tileSheet.Properties["@FirstGid"] = firstGid;
                firstGid += tileSheet.TileCount;
            }

            // convert to TMX tile indices using firstGid of each tile set
            List<int> tileIndices = new List<int>();
            for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
            {
                for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                {
                    Tile tile = layer.Tiles[tileX, tileY];

                    int tileIndex = 0; // null tile index
                    if (tile != null)
                        tileIndex = tile.TileIndex + tile.TileSheet.Properties["@FirstGid"];

                    tileIndices.Add(tileIndex);
                }
            }

            switch (tmxEncoding)
            {
                case TmxEncoding.Xml:
                    StoreLayerDataXml(tileIndices, xmlWriter);
                    break;
                case TmxEncoding.Base64:
                    StoreLayerDataBase64(tileIndices, xmlWriter, "none");
                    break;
                case TmxEncoding.Base64Gzip:
                    StoreLayerDataBase64(tileIndices, xmlWriter, "gzip");
                    break;
                case TmxEncoding.Base64Zlib:
                    StoreLayerDataBase64(tileIndices, xmlWriter, "zlib");
                    break;
                case TmxEncoding.Csv:
                    StoreLayerDataCsv(tileIndices, xmlWriter);
                    break;
            }

            // data closing tag
            xmlWriter.WriteEndElement();

            // layer closing tag
            xmlWriter.WriteEndElement();
        }

        private void StoreLayers(ReadOnlyCollection<Layer> layers, XmlWriter xmlTextWriter, TmxEncoding tmxEncoding)
        {
            foreach (Layer layer in layers)
                StoreLayer(layer, xmlTextWriter, tmxEncoding);
        }

        internal TiledTmxFormat()
        {
        }

        public CompatibilityReport DetermineCompatibility(Map map)
        {
            List<CompatibilityNote> compatibilityNotes = new List<CompatibilityNote>();

            // check that margin values and spacign values are equal since
            // TMX does not distinguish between vertical/horizontal values
            foreach (TileSheet tileSheet in  map.TileSheets)
            {
                if (!tileSheet.Margin.Square)
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None,
                            "Tilesheet " + tileSheet.Id + ": Margin values (" + tileSheet.Margin + ") are not equal"));

                if (!tileSheet.Spacing.Square)
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None,
                            "Tilesheet " + tileSheet.Id + ": Spacing values (" + tileSheet.Margin + ") are not equal"));
            }

            if (map.Layers.Count > 0)
            {
                Layer firstLayer = map.Layers[0];

                bool layerWidthMismatch = false;
                bool layerHeightMismatch = false;
                bool tileWidthMismatch = false;
                bool tileHeightMismatch = false;
                foreach (Layer layer in map.Layers)
                {
                    if (layer == firstLayer)
                        continue;

                    if (layer.LayerSize.Width != firstLayer.LayerSize.Width)
                        layerWidthMismatch = true;
                    if (layer.LayerSize.Height != firstLayer.LayerSize.Height)
                        layerHeightMismatch = true;

                    if (layer.TileSize.Width != firstLayer.TileSize.Width)
                        tileWidthMismatch = true;
                    if (layer.TileSize.Height != firstLayer.TileSize.Height)
                        tileHeightMismatch = true;
                }

                if (layerWidthMismatch)
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None,
                            "Layer widths do not match across all layers"));
                if (layerHeightMismatch)
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None,
                            "Layer heights do not match across all layers"));

                if (tileWidthMismatch)
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None, 
                            "Tile widths do not match across all layers"));
                if (tileHeightMismatch)
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None, 
                            "Tile heights do not match across all layers"));
            }

            // description fields
            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial,
                    "Map and layer description fields are preserved as custom properties named '@Description'. These properties are recognised and restored by tIDE"));

            // tile properties in layers lost
            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Custom tile properties within layers are not supported"));

            // TMX object layers
            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "TMX object layers are lost on import"));

            return new CompatibilityReport(compatibilityNotes);
        }

        public Map Load(Stream stream)
        {
            XmlTextReader xmlReader = new XmlTextReader(stream);
            xmlReader.WhitespaceHandling = WhitespaceHandling.None;

            XmlHelper xmlHelper = new XmlHelper(xmlReader);

            xmlHelper.AdvanceDeclaration();
            xmlHelper.AdvanceStartElement("map");

            string orientation = xmlHelper.GetAttribute("orientation");

            if (orientation != "orthogonal")
                throw new Exception("Only orthogonal Tiled maps are supported.");

            int mapWidth = xmlHelper.GetIntAttribute("width");
            int mapHeight = xmlHelper.GetIntAttribute("height");

            int tileWidth = xmlHelper.GetIntAttribute("tilewidth");
            int tileHeight = xmlHelper.GetIntAttribute("tileheight");

            Map map = new Map();

            while (true)
            {
                XmlNodeType xmlNodeType = xmlHelper.AdvanceNode();
                if (xmlNodeType == XmlNodeType.EndElement)
                    break;

                if (xmlReader.Name == "properties")
                    LoadProperties(xmlHelper, map);
                else if (xmlReader.Name == "tileset")
                    LoadTileSet(xmlHelper, map);
                else if (xmlReader.Name == "layer")
                    LoadLayer(xmlHelper, map);
                else
                    xmlHelper.SkipToEndElement(xmlReader.Name);
            }

            // try to obtain map description via custom property
            if (map.Properties.ContainsKey("@Description"))
                map.Description = map.Properties["@Description"];

            return map;
        }

        public void Store(Map map, Stream stream)
        {
            TiledFormatOptionsDialog tiledFormatOptionsDialog
                = new TiledFormatOptionsDialog();
            if (tiledFormatOptionsDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                throw new Exception("Store operation cancelled by user");

            TmxEncoding tmxEncoding = tiledFormatOptionsDialog.TmxEncoding;

            XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("map");
            xmlWriter.WriteAttributeString("version", "1.0");
            xmlWriter.WriteAttributeString("orientation", "orthogonal");

            // determine map with from a layer (all assumed same size)
            int mapWidth = 0, mapHeight = 0;
            int tileWidth = 32, tileHeight = 32;
            if (map.Layers.Count > 0)
            {
                Layer firstLayer = map.Layers[0];
                mapWidth = firstLayer.LayerSize.Width;
                mapHeight = firstLayer.LayerSize.Height;
                tileWidth = firstLayer.TileSize.Width;
                tileHeight = firstLayer.TileSize.Height;
            }

            xmlWriter.WriteAttributeString("width", mapWidth.ToString());
            xmlWriter.WriteAttributeString("height", mapHeight.ToString());

            xmlWriter.WriteAttributeString("tilewidth", tileWidth.ToString());
            xmlWriter.WriteAttributeString("tileheight", tileHeight.ToString());

            // preserve tIDE map description as TMX map property
            if (map.Description.Length > 0)
                map.Properties["@Description"] = map.Description;

            StoreProperties(map, xmlWriter);

            map.Properties.Remove("@Description");

            // store tile sets
            StoreTileSets(map.TileSheets, xmlWriter);

            // store layers
            StoreLayers(map.Layers, xmlWriter, tmxEncoding);

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();
        }

        public string Name
        {
            get { return "Tiled XML Format"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Tiled XML Map Files (*.tmx)"; }
        }

        public string FileExtension
        {
            get { return "tmx"; }
        }
    }
}
