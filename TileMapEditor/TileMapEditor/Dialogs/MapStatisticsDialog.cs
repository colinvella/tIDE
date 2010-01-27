using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

using TileMapEditor.Commands;
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class MapStatisticsDialog : Form
    {
        private Map m_map;

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Map ID: ");
            stringBuilder.Append(m_map.Id);

            m_textBoxStatistics.Text = stringBuilder.ToString();
        }

        public MapStatisticsDialog(Map map)
        {
            InitializeComponent();

            m_map = map;
        }
    }
}
