/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Public License (Ms-PL)                            //
//             http://www.opensource.org/licenses/ms-pl.html               //
//                                                                         //
//  AUTHOR     Colin Vella                                                 //
//                                                                         //
//  CODEBASE   http://tide.codeplex.com                                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using xTile.Dimensions;
using xTile.ObjectModel;
using xTile.Layers;
using xTile.Tiles;

namespace xTile.Format
{
    /// <summary>
    /// Default tIDE map format implementation
    /// </summary>
    internal class TideFormat: IMapFormat
    {
        #region Public Properties

        /// <summary>
        /// tIDE map format name
        /// </summary>
        public string Name
        {
            get { return "tIDE Map File"; }
        }

        /// <summary>
        /// tIDE map format descriptor
        /// </summary>
        public string FileExtensionDescriptor
        {
            get { return "tIDE Map Files (*.tide)"; }
        }

        /// <summary>
        /// tIDE file extension (.tide)
        /// </summary>
        public string FileExtension
        {
            get { return "tide"; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines the map compatibility with tIDE. This is implicitly
        /// supported in Full
        /// </summary>
        /// <param name="map">Map to analyse</param>
        /// <returns>Format compatibility report</returns>
        public CompatibilityReport DetermineCompatibility(Map map)
        {
            // trivially compatible
            return m_compatibilityResults;
        }

        /// <summary>
        /// Loads a map in tIDE format from the given stream
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <returns>Map instance loaded from stream</returns>
        public Map Load(Stream stream)
        {
#if WINDOWS
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
#else
            throw new NotSupportedException();
#endif
        }

        /// <summary>
        /// Stores the given map in the given output stream using
        /// the tIDE format
        /// </summary>
        /// <param name="map">Map to store</param>
        /// <param name="stream">Output stream</param>
        public void Store(Map map, Stream stream)
        {
#if WINDOWS
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
#else
            throw new NotSupportedException();
#endif
        }

        #endregion

        #region Internal Methods

        internal TideFormat()
        {
            m_compatibilityResults = new CompatibilityReport();
        }

        #endregion

        #region Private Methods

        private void LoadProperties(XmlHelper xmlHelper, Component component, bool consumeStartElement)
        {
            if (consumeStartElement)
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

        private void LoadProperties(XmlHelper xmlHelper, Component component)
        {
            LoadProperties(xmlHelper, component, true);
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


            // advance to end Animated tag or Properties
            xmlHelper.AdvanceNode();

            XmlNodeType xmlNodeType = xmlHelper.XmlReader.NodeType;
            string nodeName = xmlHelper.XmlReader.Name;
            if (xmlNodeType == XmlNodeType.Element && nodeName == "Properties")
            {
                LoadProperties(xmlHelper, animatedTile, false);

                xmlHelper.AdvanceNode();
                xmlNodeType = xmlHelper.XmlReader.NodeType;
                nodeName = xmlHelper.XmlReader.Name;
            }

            if (xmlNodeType == XmlNodeType.EndElement && nodeName == "Animated")
                return animatedTile;
            else
                throw new Exception("Closing \"Animated\" element expected");
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
            xmlWriter.WriteAttributeString("Visible", layer.Visible.ToString());

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

            for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
            {
                xmlWriter.WriteStartElement("Row");

                for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
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

        #endregion

        #region Private Variables

        private CompatibilityReport m_compatibilityResults;

        #endregion
    }
}
