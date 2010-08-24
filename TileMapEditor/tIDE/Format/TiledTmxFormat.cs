using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using XTile;
using XTile.Dimensions;
using XTile.Format;
using XTile.ObjectModel;
using XTile.Layers;
using XTile.Tiles;

namespace TileMapEditor.Format
{
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

        private void StoreStaticTile(StaticTile staticTile, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Static");
            xmlWriter.WriteAttributeString("Index", staticTile.TileIndex.ToString());
            xmlWriter.WriteAttributeString("BlendMode", staticTile.BlendMode.ToString());

            if (staticTile.Properties.Count > 0)
                StoreProperties(staticTile, xmlWriter);

            xmlWriter.WriteEndElement();
        }

        private void StoreAnimatedTile(AnimatedTile animatedTile, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Animated");
            xmlWriter.WriteAttributeString("Interval", animatedTile.FrameInterval.ToString());

            xmlWriter.WriteStartElement("Frames");
            TileSheet tileSheet = null;
            foreach (StaticTile tileFrame in animatedTile.TileFrames)
            {
                if (tileSheet != tileFrame.TileSheet)
                {
                    xmlWriter.WriteStartElement("TileSheet");
                    xmlWriter.WriteAttributeString("Ref", tileFrame.TileSheet.Id);
                    xmlWriter.WriteEndElement();

                    tileSheet = tileFrame.TileSheet;
                }
                StoreStaticTile(tileFrame, xmlWriter);
            }
            xmlWriter.WriteEndElement(); // Frames

            if (animatedTile.Properties.Count > 0)
                StoreProperties(animatedTile, xmlWriter);

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
                    sheetSize.Width = (bitmap.Width - marginValue) / (tileWidth + spacingValue);
                    sheetSize.Height = (bitmap.Height - marginValue) / (tileHeight + spacingValue);
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
            xmlWriter.WriteAttributeString("source", tileSheet.ImageSource);
            xmlWriter.WriteAttributeString("name", tileSheet.Id);
            xmlWriter.WriteAttributeString("tilewidth", tileSheet.TileSize.Width.ToString());
            xmlWriter.WriteAttributeString("tileheight", tileSheet.TileSize.Height.ToString());

            xmlWriter.WriteAttributeString("spacing", tileSheet.Spacing.Width.ToString());
            xmlWriter.WriteAttributeString("margin", tileSheet.Margin.Width.ToString());

            xmlWriter.WriteStartElement("Alignment");
            xmlWriter.WriteAttributeString("SheetSize", tileSheet.SheetSize.ToString());
            xmlWriter.WriteAttributeString("TileSize", tileSheet.TileSize.ToString());
            xmlWriter.WriteAttributeString("Margin", tileSheet.Margin.ToString());
            xmlWriter.WriteAttributeString("Spacing", tileSheet.Spacing.ToString());
            xmlWriter.WriteEndElement();

            StoreProperties(tileSheet, xmlWriter);

            xmlWriter.WriteEndElement();
        }

        private void StoreTileSets(ReadOnlyCollection<TileSheet> tileSheets, XmlWriter xmlWriter)
        {
            int firstGid = 0;
            foreach (TileSheet tileSheet in tileSheets)
            {
                StoreTileSet(tileSheet, firstGid, xmlWriter);
                firstGid += tileSheet.TileCount;
            }
        }

        private Tile LoadStaticTile(Layer layer, int gid)
        {
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
                throw new Exception("GZIP compression not supported");
            }
            else if (dataCompression == "zlib")
            {
                throw new Exception("ZLIB compression not supported");
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

            // must assume tile size from first tile set
            Size tileSize = map.TileSheets[0].TileSize;

            Layer layer = new Layer(id, map, layerSize, tileSize);

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

        private void StoreLayer(Layer layer, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Layer");
            xmlWriter.WriteAttributeString("Id", layer.Id);

            xmlWriter.WriteStartElement("Description");
            xmlWriter.WriteCData(layer.Description);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Dimensions");
            xmlWriter.WriteAttributeString("LayerSize", layer.LayerSize.ToString());
            xmlWriter.WriteAttributeString("TileSize", layer.TileSize.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("TileArray");

            TileSheet previousTileSheet = null;
            int nullCount = 0;

            for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
            {
                xmlWriter.WriteStartElement("Row");

                for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                {
                    Tile currentTile = layer.Tiles[tileX, tileY];

                    if (currentTile == null)
                    {
                        ++nullCount;
                        continue;
                    }
                    else if (nullCount > 0)
                    {
                        xmlWriter.WriteStartElement("Null");
                        xmlWriter.WriteAttributeString("Count", nullCount.ToString());
                        xmlWriter.WriteEndElement();
                        nullCount = 0;
                    }

                    TileSheet currentTileSheet = currentTile.TileSheet;

                    if (previousTileSheet != currentTileSheet)
                    {
                        xmlWriter.WriteStartElement("TileSheet");
                        xmlWriter.WriteAttributeString("Ref", currentTileSheet == null ? "" : currentTileSheet.Id);
                        xmlWriter.WriteEndElement();

                        previousTileSheet = currentTileSheet;
                    }

                    if (currentTile is StaticTile)
                    {
                        StoreStaticTile((StaticTile)currentTile, xmlWriter);
                    }
                    else if (currentTile is AnimatedTile)
                    {
                        AnimatedTile animatedTile = (AnimatedTile)currentTile;
                        StoreAnimatedTile(animatedTile, xmlWriter);
                    }
                }

                if (nullCount > 0)
                {
                    xmlWriter.WriteStartElement("Null");
                    xmlWriter.WriteAttributeString("Count", nullCount.ToString());
                    xmlWriter.WriteEndElement();
                    nullCount = 0;
                }

                // row closing tag
                xmlWriter.WriteEndElement();
            }

            // tile array closing tag
            xmlWriter.WriteEndElement();

            StoreProperties(layer, xmlWriter);

            xmlWriter.WriteEndElement();
        }

        private void StoreLayers(ReadOnlyCollection<Layer> layers, XmlWriter xmlTextWriter)
        {
            foreach (Layer layer in layers)
                StoreLayer(layer, xmlTextWriter);
        }

        internal TiledTmxFormat()
        {
        }

        public CompatibilityReport DetermineCompatibility(Map map)
        {
            // TODO

            // all layer sizes same
            // all tile sizes same

            // spacing must be equal x, y
            // margin must be equal x, y

            List<CompatibilityNote> compatibilityNotes = new List<CompatibilityNote>();
            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.None, "This format is still work in progress"));
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
            }

            // try to obtain map description via custom property
            if (map.Properties.ContainsKey("@Description"))
                map.Description = map.Properties["@Description"];

            return map;
        }

        public void Store(Map map, Stream stream)
        {
            // not implemented yet
            throw new Exception("This format is not supported yet");

            XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("map");
            xmlWriter.WriteAttributeString("version", "1.0");
            xmlWriter.WriteAttributeString("orientation", "orthogonal");

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

            xmlWriter.WriteEndElement();

            StoreTileSets(map.TileSheets, xmlWriter);

            StoreLayers(map.Layers, xmlWriter);

            StoreProperties(map, xmlWriter);

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
