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
        #region Private Variables

        private Map m_map;
        private Tiling.Component m_selectedComponent;

        #endregion

        #region Private Mehods

        private void MainForm_Load(object sender, EventArgs eventArgs)
        {
            m_map = new Map("Untitled map");

            m_mapTreeView.Map = m_map;
            m_tilePicker.Map = m_map;
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
                m_tilePicker.Map = map;
                m_selectedComponent = null;
            }
        }

        private void OnMapProperties(object sender, EventArgs eventArgs)
        {
            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(m_map);
            mapPropertiesDialog.ShowDialog(this);
        }

        private void OnLayerNew(object sender, EventArgs eventArgs)
        {
            Layer layer = new Layer("untitled layer", m_map,
                new Tiling.Size(1, 1), new Tiling.Size(8, 8));
            LayerPropertiesDialog layerPropertiesDialog = new LayerPropertiesDialog(layer);

            if (layerPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            m_map.AddLayer(layer);

            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = layer;
        }

        private void OnLayerProperties(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;
            LayerPropertiesDialog layerPropertiesDialog
                = new LayerPropertiesDialog(layer);

            layerPropertiesDialog.ShowDialog(this);

            m_mapTreeView.UpdateTree();
        }

        private void OnLayerBringForward(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;
            LayerPropertiesDialog layerPropertiesDialog
                = new LayerPropertiesDialog(layer);

            m_map.BringLayerForward(layer);

            m_mapTreeView.UpdateTree(true);
            m_mapTreeView.SelectedComponent = layer;
        }

        private void OnLayerSendBackward(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;
            LayerPropertiesDialog layerPropertiesDialog
                = new LayerPropertiesDialog(layer);

            m_map.SendLayerBackward(layer);

            m_mapTreeView.UpdateTree(true);
            m_mapTreeView.SelectedComponent = layer;
        }

        private void OnLayerDelete(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;

            if (MessageBox.Show(this, "Are you sure you want to delete this Layer?",
                "Delete Layer \"" + layer.Id + "\"",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            m_map.RemoveLayer(layer);

            m_mapTreeView.UpdateTree();
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
            m_mapTreeView.SelectedComponent = tileSheet;

            m_tilePicker.UpdatePicker();
        }

        private void OnTileSheetProperties(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;
            TileSheetPropertiesDialog TileSheetPropertiesDialog
                = new TileSheetPropertiesDialog(tileSheet);

            TileSheetPropertiesDialog.ShowDialog(this);

            m_mapTreeView.UpdateTree();
            m_tilePicker.UpdatePicker();
        }

        private void OnTileSheetDelete(object sender, EventArgs eventArgs)
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
            m_tilePicker.UpdatePicker();
        }

        private void OnSingleTileTool(object sender, EventArgs eventArgs)
        {
            m_editSingleTileButton.Checked = true;
            m_editTileBlockButton.Checked = false;
        }

        private void OnTileBlockTool(object sender, EventArgs eventArgs)
        {
            m_editSingleTileButton.Checked = false;
            m_editTileBlockButton.Checked = true;
        }

        private void OnTreeComponentChanged(object sender, MapTreeViewEventArgs mapTreeViewEventArgs)
        {
            Tiling.Component component = mapTreeViewEventArgs.Component;

            // enable/disable layer menu items as applicable
            bool layerSelected = component != null && component is Layer;

            m_layerPropertiesMenuItem.Enabled
                = m_layerDeleteMenuItem.Enabled
                = layerSelected;

            if (layerSelected)
            {
                Layer layer = (Layer)component;
                int layerIndex = m_map.Layers.IndexOf(layer);
                m_layerBringForwardMenuItem.Enabled = layerIndex < m_map.Layers.Count - 1;
                m_layerSendBackwardMenuItem.Enabled = layerIndex > 0;
            }
            else
                m_layerBringForwardMenuItem.Enabled
                    = m_layerSendBackwardMenuItem.Enabled = false;


            // enable/disable tile sheet menu items as applicable
            m_tileSheetPropertiesMenuItem.Enabled
                = m_tileSheetDeleteMenuItem.Enabled
                = component != null && component is TileSheet;

            m_selectedComponent = component;
        }

        private void OnPaintContentPanel(object sender, PaintEventArgs paintEventArgs)
        {
            GdiPlusDisplayDevice gdiPlusDisplayDevice = new GdiPlusDisplayDevice();
            gdiPlusDisplayDevice.Graphics = paintEventArgs.Graphics;

            m_map.LoadTileSheets(gdiPlusDisplayDevice);

            m_map.Draw(gdiPlusDisplayDevice,
                new Tiling.Rectangle(Tiling.Location.Origin,
                    new Tiling.Size(m_contentPanel.ClientRectangle.Width, m_contentPanel.ClientRectangle.Height)));

            m_map.DisposeTileSheets(gdiPlusDisplayDevice);
        }

        #endregion

        #region Public Mehods

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion


    }
}
