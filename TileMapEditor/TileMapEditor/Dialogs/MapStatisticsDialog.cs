using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Layers;
using Tiling.ObjectModel;
using Tiling.Tiles;

using TileMapEditor.Commands;
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class MapStatisticsDialog : Form
    {
        private Map m_map;
        private Font m_headerFont;
        private Font m_propertyNameFont;
        private Font m_propertyValueFont;

        private void DisplayCustomProperties(Tiling.ObjectModel.Component component)
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
            // map details
            m_textBoxStatistics.SelectionFont = m_headerFont;
            m_textBoxStatistics.AppendText("Layer ");
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
            m_textBoxStatistics.AppendLine(layer.Description.Length == 0 ? "(no description)" : m_map.Description);

            // layer size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Layer Size\t");

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
        }

        private void DisplayTileSheetStatistics(TileSheet tileSheet)
        {
        }

        private void DisplayMapStatistics(Map map)
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
            m_textBoxStatistics.AppendLine(map.Id);

            // map description
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Description\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(map.Description.Length == 0 ? "(no description)" : map.Description);

            // size
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Size\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendText(map.DisplaySize.ToString());
            m_textBoxStatistics.AppendLine(" pixels");

            // layers
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Layers\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(map.Layers.Count.ToString());

            // tile sheets
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Tile Sheets\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(map.TileSheets.Count.ToString());

            // custom properties
            m_textBoxStatistics.AppendLine();
            DisplayCustomProperties(map);

            m_textBoxStatistics.SelectionIndent += 50;

            // layers
            m_textBoxStatistics.AppendLine();
            foreach (Layer layer in map.Layers)
                DisplayLayerStatistics(layer);

            // tile sheets
            m_textBoxStatistics.AppendLine();
            foreach (TileSheet tileSheet in map.TileSheets)
                DisplayTileSheetStatistics(tileSheet);
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_headerFont = new Font(this.Font.FontFamily, this.Font.Size * 1.5f, FontStyle.Bold);

            m_propertyNameFont = new Font(this.Font, FontStyle.Bold);
            m_propertyValueFont = this.Font;

            DisplayMapStatistics(m_map);
        }

        public MapStatisticsDialog(Map map)
        {
            InitializeComponent();

            m_map = map;
        }
    }
}
