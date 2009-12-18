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

        private void LoadProperties(Component component, XmlTextReader xmlTextReader)
        {
            xmlTextReader.ReadStartElement("Properties");

            foreach (KeyValuePair<string, PropertyValue> keyValuePair in component.Properties)
            {
                /*
                xmlTextReader.ReadStartElement("Property");
                xmlTextReader.("Key", keyValuePair.Key);
                xmlTextReader.at
                xmlTextWriter.WriteAttributeString("Type", keyValuePair.Value.Type.Name);
                xmlTextWriter.WriteCData(keyValuePair.Value);
                xmlTextReader.ReadEndElement();*/
            }

            xmlTextReader.ReadEndElement();
        }

        private void StoreProperties(Component component, XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Properties");

            foreach (KeyValuePair<string, PropertyValue> keyValuePair in component.Properties)
            {
                xmlTextWriter.WriteStartElement("Property");
                xmlTextWriter.WriteAttributeString("Key", keyValuePair.Key);
                xmlTextWriter.WriteAttributeString("Type", keyValuePair.Value.Type.Name);
                xmlTextWriter.WriteCData(keyValuePair.Value);
                xmlTextWriter.WriteEndElement();
            }

            xmlTextWriter.WriteEndElement();
        }

        private void Store(TileSheet tileSheet, XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("TileSheet");
            xmlTextWriter.WriteAttributeString("Id", tileSheet.Id);

            xmlTextWriter.WriteStartElement("Description");
            xmlTextWriter.WriteCData(tileSheet.Description);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("ImageSource");
            xmlTextWriter.WriteCData(tileSheet.ImageSource);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("Alignment");
            xmlTextWriter.WriteAttributeString("TileSize", tileSheet.TileSize.ToString());
            xmlTextWriter.WriteAttributeString("Margin", tileSheet.Margin.ToString());
            xmlTextWriter.WriteAttributeString("Spacing", tileSheet.Spacing.ToString());
            xmlTextWriter.WriteEndElement();

            StoreProperties(tileSheet, xmlTextWriter);

            xmlTextWriter.WriteEndElement();
        }

        private void Store(ReadOnlyCollection<TileSheet> tileSheets, XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("TileSheets");
            foreach (TileSheet tileSheet in tileSheets)
                Store(tileSheet, xmlTextWriter);
            xmlTextWriter.WriteEndElement();
        }

        private void Store(Layer layer, XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Layer");
            xmlTextWriter.WriteAttributeString("Id", layer.Id);

            xmlTextWriter.WriteStartElement("Description");
            xmlTextWriter.WriteCData(layer.Description);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("TileArray");

            TileSheet previousTileSheet = null;

            for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
            {
                xmlTextWriter.WriteStartElement("Row");

                for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                {
                    Tile currentTile = layer.Tiles[tileX, tileY];

                    if (currentTile == null)
                    {
                        xmlTextWriter.WriteStartElement("Null");
                        xmlTextWriter.WriteEndElement();
                        continue;
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
                        xmlTextWriter.WriteStartElement("Static");
                        xmlTextWriter.WriteAttributeString("Index", currentTile.TileIndex.ToString());
                        xmlTextWriter.WriteAttributeString("BlendMode", currentTile.BlendMode.ToString());

                        if (currentTile.Properties.Count > 0)
                            StoreProperties(currentTile, xmlTextWriter);

                        xmlTextWriter.WriteEndElement();
                    }
                    else if (currentTile is AnimatedTile)
                    {
                        xmlTextWriter.WriteStartElement("Animated");
                        xmlTextWriter.WriteAttributeString("BlendMode", currentTile.BlendMode.ToString());

                        AnimatedTile animatedTile = (AnimatedTile)currentTile;
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (int frameIndex in animatedTile.TileIndices)
                        {
                            stringBuilder.Append(frameIndex);
                            stringBuilder.Append(" ");
                        }
                        xmlTextWriter.WriteAttributeString("Indices", stringBuilder.ToString().Trim());

                        if (currentTile.Properties.Count > 0)
                            StoreProperties(currentTile, xmlTextWriter);

                        xmlTextWriter.WriteEndElement();
                    }
                }
                xmlTextWriter.WriteEndElement();
            }

            xmlTextWriter.WriteEndElement();

            StoreProperties(layer, xmlTextWriter);

            xmlTextWriter.WriteEndElement();
        }

        private void Store(ReadOnlyCollection<Layer> layers, XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Layers");
            foreach (Layer layer in layers)
                Store(layer, xmlTextWriter);
            xmlTextWriter.WriteEndElement();
        }

        internal StandardFormat()
        {
            m_compatibilityResults = new CompatibilityResults(true, new List<string>());

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

            FileStream fileStream = new FileStream("Test.xml", FileMode.Create);
            Store(map, fileStream);
            fileStream.Close();
        }

        public CompatibilityResults DetermineCompatibility(Map map)
        {
            // trivially compatible
            return m_compatibilityResults;
        }

        public Map Load(Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Store(Map map, Stream stream)
        {
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;

            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("Map");
            xmlTextWriter.WriteAttributeString("Id", map.Id);

            xmlTextWriter.WriteStartElement("Description");
            xmlTextWriter.WriteCData(map.Description);
            xmlTextWriter.WriteEndElement();

            Store(map.TileSheets, xmlTextWriter);

            Store(map.Layers, xmlTextWriter);

            StoreProperties(map, xmlTextWriter);

            xmlTextWriter.WriteEndElement();

            xmlTextWriter.Flush();
        }

        public string Name
        {
            get { return "Map Files"; }
        }

        public string FileExtension
        {
            get { return "tmex"; }
        }
    }
}
