using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using XTile.Dimensions;
using XTile.ObjectModel;
using XTile.Layers;
using XTile.Tiles;

namespace XTile.Format
{
    internal class TiledTmxFormat: IMapFormat
    {
        private void LoadProperties(XmlHelper xmlHelper, Component component)
        {
            xmlHelper.AdvanceStartElement("properties");

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

        private StaticTile LoadStaticTile(XmlHelper xmlHelper, Layer layer, TileSheet tileSheet)
        {
            int tileIndex = xmlHelper.GetIntAttribute("Index");
            BlendMode blendMode
                = xmlHelper.GetAttribute("BlendMode") == BlendMode.Alpha.ToString()
                    ? BlendMode.Alpha : BlendMode.Additive;

            StaticTile staticTile = new StaticTile(layer, tileSheet, blendMode, tileIndex);

            if (!xmlHelper.XmlReader.IsEmptyElement)
            {
                LoadProperties(xmlHelper, staticTile);
                xmlHelper.AdvanceEndElement("Static");
            }

            return staticTile;
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

        private AnimatedTile LoadAnimatedTile(XmlHelper xmlHelper, Layer layer, TileSheet tileSheet)
        {
            int frameInterval = xmlHelper.GetIntAttribute("Interval");

            xmlHelper.AdvanceStartElement("Frames");

            Map map = layer.Map;
            List<StaticTile> tileFrames = new List<StaticTile>();

            while (xmlHelper.AdvanceNode() != XmlNodeType.EndElement)
            {
                if (xmlHelper.XmlReader.Name == "Static")
                    tileFrames.Add(LoadStaticTile(xmlHelper, layer, tileSheet));
                else if (xmlHelper.XmlReader.Name == "TileSheet")
                {
                    string tileSheetRef = xmlHelper.GetAttribute("Ref");
                    tileSheet = map.GetTileSheet(tileSheetRef);
                }
            }

            AnimatedTile animatedTile
                = new AnimatedTile(layer, tileFrames.ToArray(), frameInterval);

            // end of this element or optional props
            if (xmlHelper.AdvanceNode() != XmlNodeType.EndElement)
                LoadProperties(xmlHelper, animatedTile);

            return animatedTile;
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

        private void LoadLayer(XmlHelper xmlHelper, Map map)
        {
            string id = xmlHelper.GetAttribute("Id");

            xmlHelper.AdvanceStartElement("Description");
            string description = xmlHelper.GetCData();
            xmlHelper.AdvanceEndElement("Description");

            xmlHelper.AdvanceStartElement("Dimensions");
            Size layerSize = Size.FromString(xmlHelper.GetAttribute("LayerSize"));
            Size tileSize = Size.FromString(xmlHelper.GetAttribute("TileSize"));
            xmlHelper.AdvanceEndElement("Dimensions");

            Layer layer = new Layer(id, map, layerSize, tileSize);
            layer.Description = description;

            xmlHelper.AdvanceStartElement("TileArray");

            Location tileLocation = Location.Origin;
            TileSheet tileSheet = null;
            XmlReader xmlReader = xmlHelper.XmlReader;
            while (xmlHelper.AdvanceStartRepeatedElement("Row", "TileArray"))
            {
                tileLocation.X = 0;

                while (xmlHelper.AdvanceNode() != XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "Null")
                    {
                        int nullCount = xmlHelper.GetIntAttribute("Count");
                        tileLocation.X += nullCount % layerSize.Width;
                    }
                    else if (xmlReader.Name == "TileSheet")
                    {
                        string tileSheetRef = xmlHelper.GetAttribute("Ref");
                        tileSheet = map.GetTileSheet(tileSheetRef);
                    }
                    else if (xmlReader.Name == "Static")
                    {
                        layer.Tiles[tileLocation] = LoadStaticTile(xmlHelper, layer, tileSheet);

                        ++tileLocation.X;
                    }
                    else if (xmlReader.Name == "Animated")
                    {
                        layer.Tiles[tileLocation] = LoadAnimatedTile(xmlHelper, layer, tileSheet);

                        ++tileLocation.X;
                    }
                }

                ++tileLocation.Y;
            }

            LoadProperties(xmlHelper, layer);

            xmlHelper.AdvanceEndElement("Layer");

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
            // not implemented yet
            throw new Exception("This format is not supported yet");

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

                if (xmlReader.Name == "tileset")
                    LoadTileSet(xmlHelper, map);
                else if (xmlReader.Name == "layer")
                    LoadLayer(xmlHelper, map);
            }

            LoadProperties(xmlHelper, map);

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
