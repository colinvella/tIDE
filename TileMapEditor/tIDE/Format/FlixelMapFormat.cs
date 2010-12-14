using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile.Format;
using xTile;
using System.IO;
using xTile.Layers;
using xTile.Tiles;
using xTile.ObjectModel;
using System.Xml;
using System.Collections.ObjectModel;
using xTile.Dimensions;

namespace tIDE.Format
{
    internal class FlixelMapFormat: IMapFormat
    {
        #region Public Methods

        public CompatibilityReport DetermineCompatibility(Map map)
        {
            List<CompatibilityNote> compatibilityNotes = new List<CompatibilityNote>();

            bool mixedTileSheets = false;
            bool nullTiles = false;
            bool animationTiles = false;
            foreach (Layer layer in map.Layers)
            {
                for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
                {
                    for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                    {
                        Tile tile = layer.Tiles[tileX, tileY];
                        if (tile == null)
                            nullTiles = true;
                        else if (tile is AnimatedTile)
                            animationTiles = true;

                        // no need to test further?
                        if (mixedTileSheets && nullTiles && animationTiles)
                            goto CompatibilityTestEnd;
                    }
                }
            }
            CompatibilityTestEnd: // label to shorten compatibility test

            if (mixedTileSheets)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.None, "Cannot have multiple tile sheets per layer"));

            if (nullTiles)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.Partial, "Null tiles will be converted to the zero tile index"));

            if (animationTiles)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.Partial, "Animated tiles will be converted to static tiles"));

            CompatibilityReport compatibilityReport = new CompatibilityReport(compatibilityNotes);
            return compatibilityReport;
        }

        public Map Load(System.IO.Stream stream)
        {
            XmlTextReader xmlReader = new XmlTextReader(stream);
            xmlReader.WhitespaceHandling = WhitespaceHandling.None;

            XmlHelper xmlHelper = new XmlHelper(xmlReader);

            xmlHelper.AdvanceDeclaration();
            xmlHelper.AdvanceStartElement("Map");
            string mapId = xmlHelper.GetAttribute("Id");
            Map map = new Map(mapId);

            xmlHelper.AdvanceStartElement("Description");
            string mapDescription = xmlHelper.GetCData();
            xmlHelper.AdvanceEndElement("Description");
            map.Description = mapDescription;

            LoadTileSheets(xmlHelper, map);

            LoadLayers(xmlHelper, map);

            LoadProperties(xmlHelper, map);

            return map;
        }

        public void Store(Map map, Stream stream)
        {
            // determine layer filename prefix to use
            string mainFilename = "Map.flixel";
            if (stream is FileStream)
            {
                FileStream fileStream = (FileStream)stream;
                mainFilename = fileStream.Name;
            }
            string filenamePrefix = Path.GetDirectoryName(mainFilename)
                + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(mainFilename) + "_";


            XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Map");
            xmlWriter.WriteAttributeString("Id", map.Id);

            xmlWriter.WriteStartElement("Description");
            xmlWriter.WriteCData(map.Description);
            xmlWriter.WriteEndElement();

            StoreTileSheets(map.TileSheets, xmlWriter);

            StoreLayers(filenamePrefix, map.Layers, xmlWriter);

            StoreProperties(map, xmlWriter);

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get { return "Flixel Map Format"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Flixel Map Files (*.flixel)"; }
        }

        public string FileExtension
        {
            get { return "flixel"; }
        }

        #endregion

        #region Private Methods

        private string MakeValidPath(string text)
        {
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars())
            {
                text = text.Replace(ch, '_');
            }
            return text;
        }

        private TileSheet DetermineAssociatedTileSheet(Layer layer)
        {
            TileSheet tileSheet = null;
            for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                {
                    Tile tile = layer.Tiles[tileX, tileY];
                    if (tile == null)
                        continue;
                    tileSheet = tile.TileSheet;
                    break;
                }
                if (tileSheet != null)
                    break;
            }

            return tileSheet;
        }

        private void LoadProperties(XmlHelper xmlHelper, Component component)
        {
            xmlHelper.AdvanceStartElement("Properties");

            while (xmlHelper.AdvanceStartRepeatedElement("Property", "Properties"))
            {
                string propertyKey = xmlHelper.GetAttribute("Key");
                string propertyType = xmlHelper.GetAttribute("Type");
                string propertyValue = xmlHelper.GetCData();

                if (propertyType == typeof(bool).Name)
                    component.Properties[propertyKey] = bool.Parse(propertyValue);
                else if (propertyType == typeof(int).Name)
                    component.Properties[propertyKey] = int.Parse(propertyValue);
                else if (propertyType == typeof(float).Name)
                    component.Properties[propertyKey] = float.Parse(propertyValue);
                else
                    component.Properties[propertyKey] = propertyValue;

                xmlHelper.AdvanceEndElement("Property");
            }
        }

        private void StoreProperties(Component component, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Properties");

            foreach (KeyValuePair<string, PropertyValue> keyValuePair in component.Properties)
            {
                xmlWriter.WriteStartElement("Property");
                xmlWriter.WriteAttributeString("Key", keyValuePair.Key);
                xmlWriter.WriteAttributeString("Type", keyValuePair.Value.Type.Name);
                xmlWriter.WriteCData(keyValuePair.Value);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        private void LoadTileSheet(XmlHelper xmlHelper, Map map)
        {
            string id = xmlHelper.GetAttribute("Id");

            xmlHelper.AdvanceStartElement("Description");
            string description = xmlHelper.GetCData();
            xmlHelper.AdvanceEndElement("Description");

            xmlHelper.AdvanceStartElement("ImageSource");
            string imageSource = xmlHelper.GetCData();
            xmlHelper.AdvanceEndElement("ImageSource");

            xmlHelper.AdvanceStartElement("Alignment");

            Size sheetSize = Size.FromString(xmlHelper.GetAttribute("SheetSize"));
            Size tileSize = Size.FromString(xmlHelper.GetAttribute("TileSize"));
            Size margin = Size.FromString(xmlHelper.GetAttribute("Margin"));
            Size spacing = Size.FromString(xmlHelper.GetAttribute("Spacing"));

            xmlHelper.AdvanceEndElement("Alignment");

            TileSheet tileSheet = new TileSheet(id, map, imageSource, sheetSize, tileSize);
            tileSheet.Margin = margin;
            tileSheet.Spacing = spacing;

            LoadProperties(xmlHelper, tileSheet);

            xmlHelper.AdvanceEndElement("TileSheet");

            map.AddTileSheet(tileSheet);
        }

        private void StoreTileSheet(TileSheet tileSheet, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("TileSheet");
            xmlWriter.WriteAttributeString("Id", tileSheet.Id);

            xmlWriter.WriteStartElement("Description");
            xmlWriter.WriteCData(tileSheet.Description);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ImageSource");
            xmlWriter.WriteCData(tileSheet.ImageSource);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Alignment");
            xmlWriter.WriteAttributeString("SheetSize", tileSheet.SheetSize.ToString());
            xmlWriter.WriteAttributeString("TileSize", tileSheet.TileSize.ToString());
            xmlWriter.WriteAttributeString("Margin", tileSheet.Margin.ToString());
            xmlWriter.WriteAttributeString("Spacing", tileSheet.Spacing.ToString());
            xmlWriter.WriteEndElement();

            StoreProperties(tileSheet, xmlWriter);

            xmlWriter.WriteEndElement();
        }

        private void LoadTileSheets(XmlHelper xmlHelper, Map map)
        {
            xmlHelper.AdvanceStartElement("TileSheets");

            while (xmlHelper.AdvanceStartRepeatedElement("TileSheet", "TileSheets"))
                LoadTileSheet(xmlHelper, map);
        }

        private void StoreTileSheets(ReadOnlyCollection<TileSheet> tileSheets, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("TileSheets");
            foreach (TileSheet tileSheet in tileSheets)
                StoreTileSheet(tileSheet, xmlWriter);
            xmlWriter.WriteEndElement();
        }

        private void LoadLayer(XmlHelper xmlHelper, Map map)
        {
            string id = xmlHelper.GetAttribute("Id");

            bool visible = bool.Parse(xmlHelper.GetAttribute("Visible"));

            xmlHelper.AdvanceStartElement("Description");
            string description = xmlHelper.GetCData();
            xmlHelper.AdvanceEndElement("Description");

            xmlHelper.AdvanceStartElement("Dimensions");
            Size layerSize = Size.FromString(xmlHelper.GetAttribute("LayerSize"));
            Size tileSize = Size.FromString(xmlHelper.GetAttribute("TileSize"));
            xmlHelper.AdvanceEndElement("Dimensions");

            Layer layer = new Layer(id, map, layerSize, tileSize);
            layer.Description = description;
            layer.Visible = visible;

            xmlHelper.AdvanceStartElement("TileData");
            string tileSheetId = xmlHelper.GetAttribute("TileSheet");
            string layerFilename = xmlHelper.GetAttribute("Filename");
            xmlHelper.AdvanceEndElement("TileData");

            TileSheet tileSheet = map.GetTileSheet(tileSheetId);
            if (tileSheet == null)
                throw new Exception("Invalid tile sheet reference: " + tileSheetId);

            TextReader layerTextReader = new StreamReader(layerFilename);
            int tileY = 0;
            char[] commas = new char[]{','};
            while (tileY < layer.LayerHeight)
            {
                string layerLine = layerTextReader.ReadLine();
                if (layerLine == null)
                    return;

                string[] tokens = layerLine.Split(commas);
                int tileX = 0;
                foreach (string token in tokens)
                {
                    if (tileX >= layer.LayerWidth)
                        break;
                    int tileIndex = int.Parse(token.Trim());
                    layer.Tiles[tileX++, tileY] = new StaticTile(layer, tileSheet, BlendMode.Alpha, tileIndex);
                }

                ++tileY;
            }
            layerTextReader.Close();

            LoadProperties(xmlHelper, layer);

            xmlHelper.AdvanceEndElement("Layer");

            map.AddLayer(layer);
        }

        private void StoreLayer(string layerFilenamePrefix, Layer layer, XmlWriter xmlWriter)
        {
            // generate valid filename for the layer data
            string layerFilename = layerFilenamePrefix + MakeValidPath(layer.Id) + ".txt";

            // determine associated tilesheet
            TileSheet tileSheet = DetermineAssociatedTileSheet(layer);

            xmlWriter.WriteStartElement("Layer");
            xmlWriter.WriteAttributeString("Id", layer.Id);
            xmlWriter.WriteAttributeString("Visible", layer.Visible.ToString());

            xmlWriter.WriteStartElement("Description");
            xmlWriter.WriteCData(layer.Description);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Dimensions");
            xmlWriter.WriteAttributeString("LayerSize", layer.LayerSize.ToString());
            xmlWriter.WriteAttributeString("TileSize", layer.TileSize.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("TileData");
            xmlWriter.WriteAttributeString("TileSheet", tileSheet.Id);
            xmlWriter.WriteAttributeString("Filename", layerFilename);
            xmlWriter.WriteEndElement();

            StoreProperties(layer, xmlWriter);

            xmlWriter.WriteEndElement();

            // write layer CSV file
            TextWriter layerTextWriter = new StreamWriter(layerFilename);
            for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                {
                    if (tileX > 0)
                        layerTextWriter.Write(",");

                    Tile tile = layer.Tiles[tileX, tileY];
                    if (tile == null)
                        layerTextWriter.Write("0");
                    else
                        layerTextWriter.Write(tile.TileIndex);
                }
                layerTextWriter.WriteLine();
            }
            layerTextWriter.Flush();
            layerTextWriter.Close();
        }

        private void LoadLayers(XmlHelper xmlHelper, Map map)
        {
            xmlHelper.AdvanceStartElement("Layers");

            while (xmlHelper.AdvanceStartRepeatedElement("Layer", "Layers"))
                LoadLayer(xmlHelper, map);
        }

        private void StoreLayers(string layerFilenamePrefix, ReadOnlyCollection<Layer> layers, XmlWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Layers");
            foreach (Layer layer in layers)
                StoreLayer(layerFilenamePrefix, layer, xmlTextWriter);
            xmlTextWriter.WriteEndElement();
        }

        #endregion
    }
}
