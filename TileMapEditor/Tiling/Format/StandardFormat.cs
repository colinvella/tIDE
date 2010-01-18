using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using Tiling.Dimensions;
using Tiling.ObjectModel;
using Tiling.Layers;
using Tiling.Tiles;

namespace Tiling.Format
{
    internal class StandardFormat: IMapFormat
    {
        private CompatibilityResults m_compatibilityResults;

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

        private StaticTile LoadStaticTile(XmlHelper xmlHelper, Layer layer, TileSheet tileSheet)
        {
            int tileIndex = int.Parse(xmlHelper.GetAttribute("Index"));
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
            int frameInterval = int.Parse(xmlHelper.GetAttribute("Interval"));

            xmlHelper.AdvanceStartElement("Frames");

            Map map = layer.Map;
            List<StaticTile> tileFrames = new List<StaticTile>();

            while (xmlHelper.AdvanceNode() != XmlNodeType.EndElement)
            {
                if (xmlHelper.XmlReader.Name == "StaticTile")
                    tileFrames.Add(LoadStaticTile(xmlHelper, layer, tileSheet));
                else if (xmlHelper.XmlReader.Name == "TileSheet")
                {
                    string tileSheetRef = xmlHelper.GetAttribute("Ref");
                    tileSheet = map.GetTileSheet(tileSheetRef);
                }
            }

            AnimatedTile animatedTile
                = new AnimatedTile(layer, tileFrames.ToArray(), frameInterval);

            if (xmlHelper.AdvanceNode() != XmlNodeType.EndElement)
                LoadProperties(xmlHelper, animatedTile);

            xmlHelper.AdvanceEndElement("Animated");

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

        private void StoreTileSheets(ReadOnlyCollection<TileSheet> tileSheets, XmlWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("TileSheets");
            foreach (TileSheet tileSheet in tileSheets)
                StoreTileSheet(tileSheet, xmlTextWriter);
            xmlTextWriter.WriteEndElement();
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
                        int nullCount = int.Parse(xmlHelper.GetAttribute("Count"));
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

        private void StoreLayer(Layer layer, XmlWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Layer");
            xmlTextWriter.WriteAttributeString("Id", layer.Id);

            xmlTextWriter.WriteStartElement("Description");
            xmlTextWriter.WriteCData(layer.Description);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("Dimensions");
            xmlTextWriter.WriteAttributeString("LayerSize", layer.LayerSize.ToString());
            xmlTextWriter.WriteAttributeString("TileSize", layer.TileSize.ToString());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("TileArray");

            TileSheet previousTileSheet = null;
            int nullCount = 0;

            for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
            {
                xmlTextWriter.WriteStartElement("Row");

                for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                {
                    Tile currentTile = layer.Tiles[tileX, tileY];

                    if (currentTile == null)
                    {
                        ++nullCount;
                        continue;
                    }
                    else
                    {
                        xmlTextWriter.WriteStartElement("Null");
                        xmlTextWriter.WriteAttributeString("Count", nullCount.ToString());
                        xmlTextWriter.WriteEndElement();
                        nullCount = 0;
                    }

                    TileSheet currentTileSheet = currentTile.TileSheet;

                    if (previousTileSheet != currentTileSheet)
                    {
                        xmlTextWriter.WriteStartElement("TileSheet");
                        xmlTextWriter.WriteAttributeString("Ref", currentTileSheet == null ? "" : currentTileSheet.Id);
                        xmlTextWriter.WriteEndElement();

                        previousTileSheet = currentTileSheet;
                    }

                    if (currentTile is StaticTile)
                    {
                        StoreStaticTile((StaticTile)currentTile, xmlTextWriter);
                    }
                    else if (currentTile is AnimatedTile)
                    {
                        xmlTextWriter.WriteStartElement("Animated");

                        AnimatedTile animatedTile = (AnimatedTile)currentTile;
                        StringBuilder stringBuilder = new StringBuilder();
                        //TODO FIX!
                        /*foreach (int frameIndex in animatedTile.TileIndices)
                        {
                            stringBuilder.Append(frameIndex);
                            stringBuilder.Append(" ");
                        }*/
                        xmlTextWriter.WriteAttributeString("Indices", stringBuilder.ToString().Trim());

                        xmlTextWriter.WriteAttributeString("Interval", animatedTile.FrameInterval.ToString());

                        xmlTextWriter.WriteAttributeString("BlendMode", currentTile.BlendMode.ToString());

                        if (currentTile.Properties.Count > 0)
                            StoreProperties(currentTile, xmlTextWriter);

                        xmlTextWriter.WriteEndElement();
                    }
                }

                if (nullCount > 0)
                {
                    xmlTextWriter.WriteStartElement("Null");
                    xmlTextWriter.WriteAttributeString("Count", nullCount.ToString());
                    xmlTextWriter.WriteEndElement();
                    nullCount = 0;
                }

                // row closing tag
                xmlTextWriter.WriteEndElement();
            }

            // tile array closing tag
            xmlTextWriter.WriteEndElement();

            StoreProperties(layer, xmlTextWriter);

            xmlTextWriter.WriteEndElement();
        }

        private void LoadLayers(XmlHelper xmlHelper, Map map)
        {
            xmlHelper.AdvanceStartElement("Layers");

            while (xmlHelper.AdvanceStartRepeatedElement("Layer", "Layers"))
                LoadLayer(xmlHelper, map);
        }

        private void StoreLayers(ReadOnlyCollection<Layer> layers, XmlWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Layers");
            foreach (Layer layer in layers)
                StoreLayer(layer, xmlTextWriter);
            xmlTextWriter.WriteEndElement();
        }

        internal StandardFormat()
        {
            m_compatibilityResults = new CompatibilityResults(CompatibilityLevel.Full);

            /*
            // test
            Map map = new Map("test");
            map.Description = "12345";
            map.Properties["foo"] = "bar";

            TileSheet ts = new TileSheet("ts 1", map, "foo.png", new Size(20, 10), new Size(16, 16));
            map.AddTileSheet(ts);

            Layer layer = new Layer("layer 1", map, new Size(40, 15), new Size(16, 16));
            map.AddLayer(layer);
            layer.Tiles[2, 1] = new StaticTile(layer, ts, BlendMode.Additive, 3);
            layer.Tiles[2, 1].Properties["goo"] = 34.2f;

            layer.Tiles[4, 3] = new AnimatedTile(layer, ts, BlendMode.Additive, new int[3] { 9, 8, 7 }, 10);

            FileStream fileStream = new FileStream("Test.xml", FileMode.Create);
            Store(map, fileStream);
            fileStream.Close();


            // test load
            fileStream = new FileStream("Test.xml", FileMode.Open);
            Map map2 = Load(fileStream);
             */ 
        }

        public CompatibilityResults DetermineCompatibility(Map map)
        {
            // trivially compatible
            return m_compatibilityResults;
        }

        public Map Load(Stream stream)
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
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Map");
            xmlWriter.WriteAttributeString("Id", map.Id);

            xmlWriter.WriteStartElement("Description");
            xmlWriter.WriteCData(map.Description);
            xmlWriter.WriteEndElement();

            StoreTileSheets(map.TileSheets, xmlWriter);

            StoreLayers(map.Layers, xmlWriter);

            StoreProperties(map, xmlWriter);

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();
        }

        public string Name
        {
            get { return "TIDE Map File"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Map Files (*.tide)"; }
        }

        public string FileExtension
        {
            get { return "tide"; }
        }
    }
}
