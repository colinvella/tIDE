using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Layers;
using xTile.ObjectModel;
using xTile.Tiles;

using TileMapEditor.Commands;
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class MapStatisticsDialog : Form
    {
        private Map m_map;
        private xTile.Dimensions.Rectangle m_viewport;
        private Font m_headerFont;
        private Font m_propertyNameFont;
        private Font m_propertyValueFont;

        private void DisplayCustomProperties(xTile.ObjectModel.Component component)
        {
            int oldIndent = m_textBoxStatistics.SelectionIndent;

            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Custom Properties\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(component.Properties.Count.ToString());

            m_textBoxStatistics.SelectionIndent += 25;
            foreach (KeyValuePair<string, PropertyValue> keyValuePair in component.Properties)
            {
                m_textBoxStatistics.SelectionBullet = true;

                m_textBoxStatistics.SelectionFont = m_propertyNameFont;
                m_textBoxStatistics.AppendText(keyValuePair.Key);
                m_textBoxStatistics.AppendText(" = ");

                m_textBoxStatistics.SelectionFont = m_propertyValueFont;
                m_textBoxStatistics.AppendLine(keyValuePair.Value);
            }
            m_textBoxStatistics.SelectionBullet = false;
            m_textBoxStatistics.SelectionIndent = oldIndent;
        }

        private void DisplayLayerStatistics(Layer layer)
        {
            // layer details
            m_textBoxStatistics.InsertImage(Properties.Resources.Layer);
            m_textBoxStatistics.SelectionFont = m_headerFont;
            m_textBoxStatistics.AppendText(" Layer ");
            m_textBoxStatistics.AppendText(layer.Map.Layers.IndexOf(layer).ToString());
            m_textBoxStatistics.AppendLine(" Details");
            m_textBoxStatistics.AppendLine();

            // set indentation
            m_textBoxStatistics.SelectionTabs = new int[] { 170 };

            // layer id
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("ID\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(layer.Id);

            // layer description
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Description\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(layer.Description.Length == 0 ? "(no description)" : layer.Description);

            // layer size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Size\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(layer.LayerSize.ToString());
            m_textBoxStatistics.AppendText(" tiles, ");
            m_textBoxStatistics.AppendText(layer.DisplaySize.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // tile size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Tile Size\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(layer.TileSize.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // visbility
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Visible\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(layer.Visible ? "Yes" : "No");

            // custom properties
            m_textBoxStatistics.AppendLine();
            DisplayCustomProperties(layer);

            // compute tile usage statistics
            Dictionary<TileSheet, int> tileSheetUsage = new Dictionary<TileSheet, int>();
            int nullTiles = 0;
            foreach (TileSheet tileSheet in layer.Map.TileSheets)
                tileSheetUsage[tileSheet] = 0;
            
            for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
                for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                {
                    Tile tile = layer.Tiles[tileX, tileY];
                    if (tile == null)
                        ++nullTiles;
                    else
                        ++tileSheetUsage[tile.TileSheet];
                }
            int totalTiles = layer.LayerSize.Area;

            m_textBoxStatistics.AppendLine();
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendLine("Tile Sheet Usage");
            m_textBoxStatistics.SelectionBullet = true;
            m_textBoxStatistics.SelectionTabs = new int[] { 400 };
            foreach (TileSheet tileSheet in layer.Map.TileSheets)
            {
                m_textBoxStatistics.SelectionFont = m_propertyNameFont;
                m_textBoxStatistics.AppendText(tileSheet.Id);
                m_textBoxStatistics.AppendText("\t");

                int usage = tileSheetUsage[tileSheet];
                m_textBoxStatistics.SelectionFont = m_propertyValueFont;
                m_textBoxStatistics.AppendText(usage.ToString());
                m_textBoxStatistics.AppendText(" (");
                m_textBoxStatistics.AppendText((Math.Round((usage * 100.0) / totalTiles)).ToString());
                m_textBoxStatistics.AppendLine("%)");
            }

            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Clear Tiles\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(nullTiles.ToString());
            m_textBoxStatistics.AppendText(" (");
            m_textBoxStatistics.AppendText(((nullTiles * 100) / totalTiles).ToString());
            m_textBoxStatistics.AppendLine("%)");

            m_textBoxStatistics.SelectionBullet = false;

            // parallax ratios
            if (layer.Map.Layers.Count > 1)
            {
                m_textBoxStatistics.AppendLine();
                m_textBoxStatistics.SelectionFont = m_propertyNameFont;
                m_textBoxStatistics.AppendLine("Parallax Ratios");
                m_textBoxStatistics.SelectionBullet = true;
                m_textBoxStatistics.SelectionTabs = new int[] { 400 };

                xTile.Dimensions.Size thisSize = layer.DisplaySize;
                thisSize.Width -= m_viewport.Size.Width;
                thisSize.Height -= m_viewport.Size.Height;

                foreach (Layer layerOther in layer.Map.Layers)
                {
                    if (layerOther == layer)
                        continue;

                    xTile.Dimensions.Size displaySizeOther = layerOther.DisplaySize;
                    xTile.Dimensions.Size otherSize = displaySizeOther;
                    otherSize.Width -= m_viewport.Size.Width;
                    otherSize.Height -= m_viewport.Size.Height;

                    m_textBoxStatistics.SelectionFont = m_propertyNameFont;
                    m_textBoxStatistics.AppendText(layerOther.Id);
                    m_textBoxStatistics.AppendText("\t");

                    string ratioX = otherSize.Width != 0 ? (thisSize.Width * 100 / otherSize.Width).ToString() : "∞";
                    string ratioY = otherSize.Height != 0 ? (thisSize.Height * 100 / otherSize.Height).ToString() : "∞";

                    m_textBoxStatistics.SelectionFont = m_propertyValueFont;
                    m_textBoxStatistics.AppendLine(ratioX + "%, " + ratioY + "%");
                }
            }

            m_textBoxStatistics.SelectionBullet = false;

            m_textBoxStatistics.AppendLine();
        }

        private void DisplayTileSheetStatistics(TileSheet tileSheet)
        {
            // tile sheet details
            m_textBoxStatistics.InsertImage(Properties.Resources.TileSheet);
            m_textBoxStatistics.SelectionFont = m_headerFont;
            m_textBoxStatistics.AppendText(" Tile Sheet ");
            m_textBoxStatistics.AppendText(tileSheet.Map.TileSheets.IndexOf(tileSheet).ToString());
            m_textBoxStatistics.AppendLine(" Details");
            m_textBoxStatistics.AppendLine();

            // set indentation
            m_textBoxStatistics.SelectionTabs = new int[] { 170 };

            // tile sheet id
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("ID\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(tileSheet.Id);

            // tile sheet description
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Description\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(tileSheet.Description.Length == 0 ? "(no description)" : tileSheet.Description);

            // image source
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Image Source\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(tileSheet.ImageSource);

            // sheet size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Sheet Size\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(tileSheet.SheetSize.ToString());
            m_textBoxStatistics.AppendText(" (");
            m_textBoxStatistics.AppendText(tileSheet.TileCount.ToString());
            m_textBoxStatistics.AppendLine(") tiles");

            // tile size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Tile Size\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(tileSheet.TileSize.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // margin
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Left, Top Margin\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(tileSheet.Margin.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // spacing
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Hor, Ver Spacing\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(tileSheet.Spacing.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // custom properties
            m_textBoxStatistics.AppendLine();
            DisplayCustomProperties(tileSheet);

            // compute tile usage statistics per layer

            m_textBoxStatistics.AppendLine();
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendLine("Tile Sheet Usage");
            m_textBoxStatistics.SelectionBullet = true;
            m_textBoxStatistics.SelectionTabs = new int[] { 400 };

            foreach (Layer layer in tileSheet.Map.Layers)
            {
                int totalTiles = layer.LayerSize.Area;

                int tileSheetTiles = 0;
                for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
                    for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                    {
                        Tile tile = layer.Tiles[tileX, tileY];
                        if (tile != null && tile.TileSheet == tileSheet)
                            ++tileSheetTiles;
                    }

                m_textBoxStatistics.SelectionFont = m_propertyNameFont;
                m_textBoxStatistics.AppendText("Layer ");
                m_textBoxStatistics.AppendText(tileSheet.Map.Layers.IndexOf(layer).ToString());
                m_textBoxStatistics.AppendText("\t");

                m_textBoxStatistics.SelectionFont = m_propertyValueFont;
                m_textBoxStatistics.AppendText(tileSheetTiles.ToString());
                m_textBoxStatistics.AppendText(" (");
                m_textBoxStatistics.AppendText((Math.Round((tileSheetTiles * 100.0) / totalTiles)).ToString());
                m_textBoxStatistics.AppendLine("%)");
            }

            m_textBoxStatistics.SelectionBullet = false;

            m_textBoxStatistics.AppendLine();
        }

        private void DisplayMapStatistics()
        {
            // map details
            m_textBoxStatistics.InsertImage(Properties.Resources.Map);
            m_textBoxStatistics.SelectionFont = m_headerFont;
            m_textBoxStatistics.AppendLine(" Map Details");
            m_textBoxStatistics.AppendLine();

            // set indentation
            m_textBoxStatistics.SelectionTabs = new int[] { 120 };

            // map id
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("ID\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Id);

            // map description
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Description\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Description.Length == 0 ? "(no description)" : m_map.Description);

            // size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Size\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(m_map.DisplaySize.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // layers
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Layers\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Layers.Count.ToString());

            // tile sheets
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Tile Sheets\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.TileSheets.Count.ToString());

            // custom properties
            m_textBoxStatistics.AppendLine();
            DisplayCustomProperties(m_map);

            m_textBoxStatistics.SelectionIndent += 50;

            // layers
            m_textBoxStatistics.AppendLine();
            foreach (Layer layer in m_map.Layers)
                DisplayLayerStatistics(layer);

            // tile sheets
            m_textBoxStatistics.AppendLine();
            foreach (TileSheet tileSheet in m_map.TileSheets)
                DisplayTileSheetStatistics(tileSheet);
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_headerFont = new Font(this.Font.FontFamily, this.Font.Size * 1.5f, FontStyle.Bold);

            m_propertyNameFont = new Font(this.Font, FontStyle.Bold);
            m_propertyValueFont = this.Font;

            DisplayMapStatistics();
        }

        public MapStatisticsDialog(Map map, xTile.Dimensions.Rectangle viewport)
        {
            InitializeComponent();

            m_map = map;
            m_viewport = viewport;
        }
    }
}
