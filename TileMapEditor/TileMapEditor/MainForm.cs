using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

using TileMapEditor.Control;
using TileMapEditor.Dialog;

namespace TileMapEditor
{
    public partial class MainForm : Form
    {
        private Map m_map;
        private Tiling.Component m_selectedComponent;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_map = new Map("Untitled map");
            m_mapTreeView.Map = m_map;

            m_selectedComponent = m_map;
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
                m_mapTreeView.UpdateTree();
            }
        }

        private void OnMapProperties(object sender, EventArgs eventArgs)
        {
            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(m_map);
            mapPropertiesDialog.ShowDialog(this);
        }

        private void OnTileSheetNew(object sender, EventArgs eventArgs)
        {
            TileSheet tileSheet = new TileSheet("untitled tile sheet", m_map, "",
                new Tiling.Size(8, 8), new Tiling.Size(8, 8));
            TileSheetPropertiesDialog tileSheetPropertiesDialog = new TileSheetPropertiesDialog(tileSheet);

            if (tileSheetPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            m_map.AddTileSheet(tileSheet);
            m_mapTreeView.UpdateTree();
        }

        private void m_mapTreeView_ComponentChanged(object sender, MapTreeViewEventArgs mapTreeViewEventArgs)
        {
            Tiling.Component component = mapTreeViewEventArgs.Component;

            m_tileSheetPropertiesMenuItem.Enabled = m_tileSheetDeleteMenuItem.Enabled
                = component != null && mapTreeViewEventArgs.Component is TileSheet;

            m_selectedComponent = component;
        }

        private void OnTileSheetProperties(object sender, EventArgs e)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;
            TileSheetPropertiesDialog TileSheetPropertiesDialog
                = new TileSheetPropertiesDialog(tileSheet);

            TileSheetPropertiesDialog.ShowDialog(this);

            m_mapTreeView.UpdateTree();
        }

        private void OnTileSheetDelete(object sender, EventArgs e)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;

            if (MessageBox.Show(this, "Are you sure you want to delete this Tile Sheet?",
                "Delete Tile Sheet \"" + tileSheet.Id + "\"",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            m_map.RemoveTileSheet(tileSheet);

            m_mapTreeView.UpdateTree();
        }
    }
}
