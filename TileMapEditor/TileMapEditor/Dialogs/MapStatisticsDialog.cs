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

        private void DisplayCustomProperties(Tiling.ObjectModel.Component component, int indent)
        {
            int oldIndent = m_textBoxStatistics.SelectionIndent;

            m_textBoxStatistics.SelectionIndent = indent;
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Custom Properties\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Properties.Count.ToString());

            foreach (KeyValuePair<string, PropertyValue> keyValuePair in m_map.Properties)
            {
                m_textBoxStatistics.SelectionBullet = true;
                m_textBoxStatistics.SelectionIndent = indent + 25;

                m_textBoxStatistics.SelectionFont = m_propertyNameFont;
                m_textBoxStatistics.AppendText(keyValuePair.Key);
                m_textBoxStatistics.AppendText(" = ");

                m_textBoxStatistics.SelectionFont = m_propertyValueFont;
                m_textBoxStatistics.AppendLine(keyValuePair.Value);
            }
            m_textBoxStatistics.SelectionBullet = false;
            m_textBoxStatistics.SelectionIndent = oldIndent;
        }

        private void DisplayLayer(Layer layer)
        {
            // map details
            m_textBoxStatistics.SelectionFont = m_headerFont;
            m_textBoxStatistics.AppendText("Layer ");
            m_textBoxStatistics.AppendText(layer.Map.Layers.IndexOf(layer).ToString());
            m_textBoxStatistics.AppendLine(" Details");
            m_textBoxStatistics.AppendLine();
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_headerFont = new Font(this.Font.FontFamily, this.Font.Size * 1.5f, FontStyle.Bold);

            m_propertyNameFont = new Font(this.Font, FontStyle.Bold);
            m_propertyValueFont = this.Font;

            // map details
            m_textBoxStatistics.SelectionFont = m_headerFont;
            m_textBoxStatistics.AppendLine("Map Details");
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

            // layers
            m_textBoxStatistics.SelectionFont = m_propertyNameFont;
            m_textBoxStatistics.AppendText("Layers\t");

            m_textBoxStatistics.SelectionFont = m_propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Layers.Count.ToString());

            // custom properties
            m_textBoxStatistics.AppendLine();
            DisplayCustomProperties(m_map, 0);

            // layers
            m_textBoxStatistics.AppendLine();
            foreach (Layer layer in m_map.Layers)
                DisplayLayer(layer);
        }

        public MapStatisticsDialog(Map map)
        {
            InitializeComponent();

            m_map = map;
        }
    }
}
