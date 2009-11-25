using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

using TileMapEditor.Dialog;

namespace TileMapEditor
{
    public partial class MainForm : Form
    {
        private Map m_map;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_map = new Map("Untitled map");
            m_mapTreeView.Map = m_map;

            m_map.Properties.Add("hello", "world");
            m_map.Properties.Add("yo", true);
        }

        private void OnFileNew(object sender, EventArgs eventArgs)
        {
            if (MessageBox.Show(this, "Start a new map project?", "New map", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            Map map = new Map("Untitled Map");

            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(map);

            if (mapPropertiesDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_map = map;
                m_mapTreeView.Map = m_map;
                m_mapTreeView.Rebuild();
            }
        }

        private void OnMapProperties(object sender, EventArgs eventArgs)
        {
            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(m_map);
            mapPropertiesDialog.ShowDialog(this);
        }

        private void OnTileSheetNew(object sender, EventArgs eventArgs)
        {
            TileSheet tileSheet = new TileSheet("untitled tile sheet", "", new Tiling.Size(8, 8), new Tiling.Size(8, 8));
            TileSheetPropertiesDialog tileSheetPropertiesDialog = new TileSheetPropertiesDialog(tileSheet);
            tileSheetPropertiesDialog.ShowDialog(this);
        }
    }
}
