using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.ObjectModel;

using TileMapEditor.Commands;
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class MapStatisticsDialog : Form
    {
        private Map m_map;

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            Font headerFont = new Font(this.Font.FontFamily, this.Font.Size * 1.5f, FontStyle.Bold);

            Font propertyNameFont = new Font(this.Font, FontStyle.Bold);
            Font propertyValueFont = this.Font;

            // map details
            m_textBoxStatistics.SelectionFont = headerFont;
            m_textBoxStatistics.AppendLine("Map Details");
            m_textBoxStatistics.AppendLine();

            // set indentation
            m_textBoxStatistics.SelectionTabs = new int[] { 120 };

            // map id
            m_textBoxStatistics.SelectionFont = propertyNameFont;
            m_textBoxStatistics.AppendText("ID\t");

            m_textBoxStatistics.SelectionFont = propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Id);

            // map description
            m_textBoxStatistics.SelectionFont = propertyNameFont;
            m_textBoxStatistics.AppendText("Description\t");

            m_textBoxStatistics.SelectionFont = propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Description.Length == 0 ? "(no description)" : m_map.Description);

            // layers
            m_textBoxStatistics.SelectionFont = propertyNameFont;
            m_textBoxStatistics.AppendText("Layers\t");

            m_textBoxStatistics.SelectionFont = propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Layers.Count.ToString());

            // custom properties
            m_textBoxStatistics.AppendLine();
            m_textBoxStatistics.SelectionFont = propertyNameFont;
            m_textBoxStatistics.AppendText("Custom Properties\t");

            m_textBoxStatistics.SelectionFont = propertyValueFont;
            m_textBoxStatistics.AppendLine(m_map.Properties.Count.ToString());

            foreach (KeyValuePair<string, PropertyValue> keyValuePair in m_map.Properties)
            {
                m_textBoxStatistics.SelectionBullet = true;
                m_textBoxStatistics.SelectionIndent = 25;

                m_textBoxStatistics.SelectionFont = propertyNameFont;
                m_textBoxStatistics.AppendText(keyValuePair.Key);
                m_textBoxStatistics.AppendText(" = ");

                m_textBoxStatistics.SelectionFont = propertyValueFont;
                m_textBoxStatistics.AppendLine(keyValuePair.Value);
            }
            m_textBoxStatistics.SelectionBullet = false;
            m_textBoxStatistics.SelectionIndent = 0;
        }

        public MapStatisticsDialog(Map map)
        {
            InitializeComponent();

            m_map = map;
        }
    }
}
