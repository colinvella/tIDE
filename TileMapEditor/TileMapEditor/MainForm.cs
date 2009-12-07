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

        #region Private Methods

        private void ArrangeToolStripLayout()
        {
            List<System.Windows.Forms.Control> controls = new List<System.Windows.Forms.Control>();
            foreach (System.Windows.Forms.Control control in m_toolStripContainer.TopToolStripPanel.Controls)
                controls.Add(control);
            m_toolStripContainer.TopToolStripPanel.Controls.Clear();
            
            Point currentPosition = m_toolStripContainer.TopToolStripPanel.ClientRectangle.Location;
            foreach (System.Windows.Forms.Control control in controls)
            {
                currentPosition.X += control.Margin.Left;
                currentPosition.Y += control.Margin.Top;

                if (currentPosition.X + control.Width + control.Margin.Right > m_toolStripContainer.TopToolStripPanel.ClientRectangle.Width)
                {
                    currentPosition.X = control.Margin.Left;
                    currentPosition.Y += control.Height + control.Margin.Bottom;
                }

                control.Location = currentPosition;
                m_toolStripContainer.TopToolStripPanel.Controls.Add(control);
                currentPosition = control.Location;

                currentPosition.X += control.Width + control.Margin.Right;
                currentPosition.Y -= control.Margin.Top;
            }
        }

        private void UpdateZoomControls()
        {
            int zoom = m_mapPanel.Zoom;
            foreach (ToolStripMenuItem toolStripMenuItem in m_viewZoomMenuItem.DropDownItems)
                toolStripMenuItem.Checked = toolStripMenuItem.Tag.ToString() == zoom.ToString();

            m_viewZoomComboBox.SelectedIndex = zoom - 1;

            m_viewZoomInButton.Enabled = zoom < 10;
            m_viewZoomOutButton.Enabled = zoom > 1;
        }

        private void UpdateLayerCompositingControls()
        {
            if (m_mapPanel.LayerCompositing == LayerCompositing.DimUnselected)
            {
                m_viewLayerCompositingDimUnselectedMenuItem.Enabled = false;
                m_viewLayerCompositingShowAllMenuItem.Enabled = true;

                m_viewLayerCompositingToggleButton.ToolTipText = "Show all layers";
                m_viewLayerCompositingToggleButton.Image
                    = Properties.Resources.ViewLayerCompositingShowAll;
            }
            else
            {
                m_viewLayerCompositingDimUnselectedMenuItem.Enabled = true;
                m_viewLayerCompositingShowAllMenuItem.Enabled = false;

                m_viewLayerCompositingToggleButton.ToolTipText = "Dim unselected layers";
                m_viewLayerCompositingToggleButton.Image
                    = Properties.Resources.ViewLayerCompositingDimUnselected;
            }
        }

        private void UpdateTileGuidesControls()
        {
            bool tileGuides = m_mapPanel.TileGuides;
            m_viewTileGuidesShowMenuItem.Enabled = !tileGuides;
            m_viewTileGuidesHideMenuItem.Enabled = tileGuides;

            m_viewTileGuidesToggleButton.ToolTipText = tileGuides
                ? "Hide tile guides" : "Show tile guides";

            m_viewTileGuidesToggleButton.Image = tileGuides
                ? Properties.Resources.VewTileGuidesHide
                : Properties.Resources.VewTileGuidesShow;
        }

        private void UpdateEditToolButtons()
        {
            EditTool editTool = m_mapPanel.EditTool;

            m_editSelectButton.Checked = editTool == EditTool.Select;
            m_editSingleTileButton.Checked = editTool == EditTool.SingleTile;
            m_editTileBlockButton.Checked = editTool == EditTool.TileBlock;
            m_editEraserButton.Checked = editTool == EditTool.Eraser;
            m_editDropperButton.Checked = editTool == EditTool.Dropper;
        }

        private void OnMainFormLoad(object sender, EventArgs eventArgs)
        {
            m_map = new Map("Untitled map");

            m_mapTreeView.Map = m_map;
            m_tilePicker.Map = m_map;
            m_mapPanel.Map = m_map;

            m_selectedComponent = m_map;

            m_viewZoomComboBox.SelectedIndex = 0;

            ArrangeToolStripLayout();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.S:
                    m_mapPanel.EditTool = EditTool.Select;
                    UpdateEditToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.T:
                    m_mapPanel.EditTool = EditTool.SingleTile;
                    UpdateEditToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.B:
                    m_mapPanel.EditTool = EditTool.TileBlock;
                    UpdateEditToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.E:
                    m_mapPanel.EditTool = EditTool.Eraser;
                    UpdateEditToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.P:
                    m_mapPanel.EditTool = EditTool.Dropper;
                    UpdateEditToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
            }
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
                m_mapPanel.Map = map;

                m_selectedComponent = null;
            }
        }

        private void OnViewZoom(object sender, EventArgs eventArgs)
        {
            ToolStripDropDownItem toolStripDropDownItem = (ToolStripDropDownItem)sender;
            if (toolStripDropDownItem.Tag == null)
                return;
            int zoom = int.Parse(toolStripDropDownItem.Tag.ToString());
            m_mapPanel.Zoom = zoom;

            UpdateZoomControls();
        }

        private void OnViewZoomComboBox(object sender, EventArgs eventArgs)
        {
            m_mapPanel.Zoom = m_viewZoomComboBox.SelectedIndex + 1;
            UpdateZoomControls();
            m_viewToolStrip.Focus();
        }

        private void OnViewZoomIn(object sender, EventArgs eventArgs)
        {
            if (m_mapPanel.Zoom == 10)
                return;

            ++m_mapPanel.Zoom;
            UpdateZoomControls();
        }

        private void OnViewZoomOut(object sender, EventArgs eventArgs)
        {
            if (m_mapPanel.Zoom == 1)
                return;

            --m_mapPanel.Zoom;
            UpdateZoomControls();
        }

        private void OnViewLayerCompositingDimUnselected(object sender, EventArgs eventArgs)
        {
            m_mapPanel.LayerCompositing = LayerCompositing.DimUnselected;
            UpdateLayerCompositingControls();
        }

        private void OnViewLayerCompositingShowAll(object sender, EventArgs eventArgs)
        {
                        m_mapPanel.LayerCompositing = LayerCompositing.ShowAll;
            UpdateLayerCompositingControls();
        }

        private void OnViewLayerCompositingToggleButton(object sender, EventArgs eventArgs)
        {
            m_mapPanel.LayerCompositing
                = m_mapPanel.LayerCompositing == LayerCompositing.DimUnselected
                ? LayerCompositing.ShowAll
                : LayerCompositing.DimUnselected;
            UpdateLayerCompositingControls();
        }

        private void OnViewTileGuidesShow(object sender, EventArgs eventArgs)
        {
            m_mapPanel.TileGuides = true;
            UpdateTileGuidesControls();
        }

        private void OnViewTileGuidesHide(object sender, EventArgs eventArgs)
        {
            m_mapPanel.TileGuides = false;
            UpdateTileGuidesControls();
        }

        private void OnViewTileGuidesToggleButton(object sender, EventArgs eventArgs)
        {
            m_mapPanel.TileGuides = !m_mapPanel.TileGuides;
            UpdateTileGuidesControls();
        }

        private void OnMapProperties(object sender, EventArgs eventArgs)
        {
            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(m_map);
            mapPropertiesDialog.ShowDialog(this);
        }

        private void OnLayerNew(object sender, EventArgs eventArgs)
        {
            Tiling.Size tileSize = m_map.TileSheets.Count > 0
                ? m_map.TileSheets[0].TileSize
                : new Tiling.Size(8, 8);

            Layer layer = new Layer("untitled layer", m_map,
                new Tiling.Size(100, 25), tileSize);
            LayerPropertiesDialog layerPropertiesDialog = new LayerPropertiesDialog(layer);

            if (layerPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            m_map.AddLayer(layer);

            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = layer;

            m_mapPanel.Enabled = true;
            m_mapPanel.Invalidate(true);
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

            if (m_map.Layers.Count == 0)
                m_mapPanel.Enabled = false;
        }

        private void OnTileSheetNew(object sender, EventArgs eventArgs)
        {
            TileSheet tileSheet = new TileSheet("untitled tile sheet", m_map, "",
                new Tiling.Size(8, 8), new Tiling.Size(8, 8));
            TileSheetPropertiesDialog tileSheetPropertiesDialog = new TileSheetPropertiesDialog(tileSheet);

            if (tileSheetPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            TileImageCache.Instance.Refresh(tileSheet);

            m_map.AddTileSheet(tileSheet);

            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = tileSheet;

            m_tilePicker.UpdatePicker();

            m_mapPanel.LoadTileSheet(tileSheet);
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

            if (m_map.DependsOnTileSheet(tileSheet))
            {
                MessageBox.Show(this,
                    "This Tile Sheet cannot be deleted until all tiles originating from this sheet are removed from the relevant layers.",
                    "Delete Tile Sheet \"" + tileSheet.Id + "\"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to delete this Tile Sheet?",
                "Delete Tile Sheet \"" + tileSheet.Id + "\"",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            m_map.RemoveTileSheet(tileSheet);

            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = null;
            m_selectedComponent = null;

            m_tileSheetPropertiesMenuItem.Enabled
                = m_tileSheetPropertiesButton.Enabled
                = m_tileSheetDeleteMenuItem.Enabled
                = m_tileSheetDeleteButton.Enabled = false;

            m_tilePicker.UpdatePicker();

            m_mapPanel.DisposeTileSheet(tileSheet);
        }

        private void OnPickerTileSelected(object sender, TilePickerEventArgs tilePickerEventArgs)
        {
            m_mapPanel.SelectedTileSheet = tilePickerEventArgs.TileSheet;
            m_mapPanel.SelectedTileIndex = tilePickerEventArgs.TileIndex;
        }

        private void OnEditSelectButton(object sender, EventArgs e)
        {
            m_mapPanel.EditTool = EditTool.Select;
            UpdateEditToolButtons();
        }

        private void OnEditSingleTile(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.SingleTile;
            UpdateEditToolButtons();
        }

        private void OnEditTileBlock(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.TileBlock;
            UpdateEditToolButtons();
        }

        private void OnEditEraser(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.Eraser;
            UpdateEditToolButtons();
        }

        private void OnEditDropper(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.Dropper;
            UpdateEditToolButtons();
        }

        private void OnTreeComponentChanged(object sender, MapTreeViewEventArgs mapTreeViewEventArgs)
        {
            Tiling.Component component = mapTreeViewEventArgs.Component;

            // enable/disable layer menu items as applicable
            bool layerSelected = component != null && component is Layer;

            m_layerPropertiesMenuItem.Enabled
                = m_layerPropertiesButton.Enabled
                = m_layerDeleteMenuItem.Enabled
                = m_layerDeleteButton.Enabled
                = layerSelected;

            if (layerSelected)
            {
                Layer layer = (Layer)component;
                int layerIndex = m_map.Layers.IndexOf(layer);

                m_layerBringForwardMenuItem.Enabled
                    = m_layerBringForwardButton.Enabled
                    = layerIndex < m_map.Layers.Count - 1;

                m_layerSendBackwardMenuItem.Enabled
                    = m_layerSendBackwardButton.Enabled
                    = layerIndex > 0;

                m_mapPanel.SelectedLayer = layer;
            }
            else
                m_layerBringForwardMenuItem.Enabled
                    = m_layerBringForwardButton.Enabled
                    = m_layerSendBackwardMenuItem.Enabled
                    = m_layerSendBackwardButton.Enabled
                    = false;


            // enable/disable tile sheet menu items as applicable
            m_tileSheetPropertiesMenuItem.Enabled
                = m_tileSheetDeleteMenuItem.Enabled
                = m_tileSheetPropertiesButton.Enabled
                = m_tileSheetDeleteButton.Enabled
                = component != null && component is TileSheet;

            m_selectedComponent = component;
        }

        private void OnMapTilePicked(MapPanelEventArgs mapPanelEventArgs)
        {
            Tile tile = mapPanelEventArgs.Tile;
            if (tile != null)
            {
                m_tilePicker.SelectedTileSheet = tile.TileSheet;
                m_tilePicker.SelectedTileIndex = tile.TileIndex;
            }

            UpdateEditToolButtons();
        }

        #endregion

        #region Public Methods

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion
    }
}
