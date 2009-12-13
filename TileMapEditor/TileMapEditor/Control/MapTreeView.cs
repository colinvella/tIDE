using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

namespace TileMapEditor.Control
{
    public partial class MapTreeView : UserControl
    {
        #region Private Variables

        private Map m_map;

        #endregion

        #region Private Methods

        private void UpdateLayersSubTree(TreeNode layersNode)
        {
            layersNode.Nodes.Clear();

            int layerImageIndex = m_imageList.Images.IndexOfKey("Layer.png");
            foreach (Layer layer in m_map.Layers)
            {
                TreeNode layerNode = new TreeNode(layer.Id, layerImageIndex, layerImageIndex);
                layerNode.Tag = layer;
                layerNode.ContextMenuStrip = m_contextMenuLayer;
                layersNode.Nodes.Add(layerNode);
            }
        }

        private void UpdateTileSheetsSubTree(TreeNode tileSheetsNode)
        {
            tileSheetsNode.Nodes.Clear();

            int tileSheetImageIndex = m_imageList.Images.IndexOfKey("TileSheet.png");
            foreach (TileSheet tileSheet in m_map.TileSheets)
            {
                TreeNode tileSheetNode = new TreeNode(tileSheet.Id, tileSheetImageIndex, tileSheetImageIndex);
                tileSheetNode.Tag = tileSheet;
                tileSheetsNode.Nodes.Add(tileSheetNode);
            }
        }

        private void OnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            if (ComponentChanged != null)
            {
                TreeNode treeNode = m_treeView.SelectedNode;

                object tag = treeNode.Tag;
                Tiling.Component component = tag is Tiling.Component
                    ? (Tiling.Component)tag : null;

                ComponentChanged(this,
                    new MapTreeViewEventArgs(treeNode, component));
            }
        }

        private TreeNode SearchComponent(TreeNode rootNode, Tiling.Component component)
        {
            if (rootNode.Tag == component)
                return rootNode;

            foreach (TreeNode childNode in rootNode.Nodes)
            {
                TreeNode resultNode = SearchComponent(childNode, component);
                if (resultNode != null)
                    return resultNode;
            }

            return null;
        }

        private void OnContextMenuLayerOpening(object sender, CancelEventArgs cancelEventArgs)
        {
            Layer layer = (Layer)SelectedComponent;
            int layerIndex = m_map.Layers.IndexOf(layer);
            m_layerBringForwardMenuItem.Enabled = layerIndex < m_map.Layers.Count - 1;
            m_layerSendBackwardMenuItem.Enabled = layerIndex > 0;
        }

        private void OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            m_treeView.SelectedNode = m_treeView.GetNodeAt(mouseEventArgs.Location);
        }

        private void OnLayerNew(object sender, EventArgs eventArgs)
        {
            if (NewLayer != null)
                NewLayer(this, eventArgs);
        }

        private void OnLayerDeleteAll(object sender, EventArgs eventArgs)
        {
            if (DeleteAllLayers != null)
                DeleteAllLayers(this, eventArgs);
        }

        private void OnLayerProperties(object sender, EventArgs eventArgs)
        {
            if (LayerProperties != null)
                LayerProperties(this, eventArgs);
        }

        private void OnLayerBringForward(object sender, EventArgs eventArgs)
        {
            if (BringLayerForward != null)
                BringLayerForward(this, eventArgs);
        }

        private void OnLayerSendBackward(object sender, EventArgs eventArgs)
        {
            if (SendLayerBackward != null)
                SendLayerBackward(this, eventArgs);
        }

        private void OnLayerDelete(object sender, EventArgs eventArgs)
        {
            if (DeleteLayer != null)
                DeleteLayer(this, eventArgs);
        }

        #endregion

        #region Public Methods

        public MapTreeView()
        {
            InitializeComponent();
        }

        public void UpdateTree()
        {
            UpdateTree(false);
        }

        public void UpdateTree(bool refreshLayers)
        {
            if (m_map == null)
            {
                m_treeView.Nodes.Clear();
                return;
            }

            // map root node
            TreeNode mapNode = null;
            TreeNode layersNode = null;
            TreeNode tileSheetsNode = null;
            if (m_treeView.Nodes.Count == 0)
            {
                // create root map node
                int mapImageIndex = m_imageList.Images.IndexOfKey("Map.png");
                mapNode = new TreeNode(m_map.Id, mapImageIndex, mapImageIndex);
                mapNode.Tag = m_map;

                // create layer collection node
                int layerFolderImageIndex = m_imageList.Images.IndexOfKey("LayerFolder.png");
                layersNode = new TreeNode("Layers", layerFolderImageIndex, layerFolderImageIndex);
                layersNode.ContextMenuStrip = m_contextMenuLayers;
                layersNode.Tag = m_map.Layers;
                mapNode.Nodes.Add(layersNode);

                // create tilesheet collection node
                int tileSheetFolderImageIndex = m_imageList.Images.IndexOfKey("TileSheetFolder.png");
                tileSheetsNode = new TreeNode("Tile Sheets", tileSheetFolderImageIndex, tileSheetFolderImageIndex);
                tileSheetsNode.Tag = m_map.TileSheets;
                mapNode.Nodes.Add(tileSheetsNode);

                m_treeView.Nodes.Add(mapNode);

                m_treeView.SelectedNode = mapNode;
            }
            else
            {
                // determine update map node
                mapNode = m_treeView.Nodes[0];
                mapNode.Text = m_map.Id;
                mapNode.Tag = m_map;

                layersNode = mapNode.Nodes[0];

                if (refreshLayers)
                    layersNode.Nodes.Clear();

                tileSheetsNode = mapNode.Nodes[1];
            }

            // layers
            UpdateLayersSubTree(layersNode);

            // tile sheets
            UpdateTileSheetsSubTree(tileSheetsNode);
        }

        #endregion

        #region Public Properties

        [Description("The Map structure associated with this control"),
         Category("Data"), Browsable(true)
        ]
        public Map Map
        {
            get { return m_map; }
            set
            {
                m_map = value;
                UpdateTree();
            }
        }

        public Tiling.Component SelectedComponent
        {
            get
            {
                TreeNode treeNode = m_treeView.SelectedNode;
                if (treeNode == null || treeNode.Tag == null)
                    return null;
                if (!(treeNode.Tag is Tiling.Component))
                    return null;

                return (Tiling.Component)treeNode.Tag;
            }

            set
            {
                if (m_treeView.Nodes.Count == 0)
                    return;

                TreeNode matchingNode = SearchComponent(m_treeView.Nodes[0], value);

                m_treeView.SelectedNode = matchingNode;
            }
        }

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the selected component node is changed")]
        public event MapTreeViewEventHandler ComponentChanged;

        [Category("Behavior"), Description("Occurs when a new layer is requested from the context menu")]
        public event EventHandler NewLayer;

        [Category("Behavior"), Description("Occurs when Delete of all layers is requested from the context menu")]
        public event EventHandler DeleteAllLayers;

        [Category("Behavior"), Description("Occurs when layer properties are requested from the context menu")]
        public event EventHandler LayerProperties;

        [Category("Behavior"), Description("Occurs when a layer is requested to be brought forward from the context menu")]
        public event EventHandler BringLayerForward;

        [Category("Behavior"), Description("Occurs when a layer is requested to be sent backward from the context menu")]
        public event EventHandler SendLayerBackward;

        [Category("Behavior"), Description("Occurs when a layer deletion is requested from the context menu")]
        public event EventHandler DeleteLayer;

        #endregion
    }

    public class MapTreeViewEventArgs
    {
        private TreeNode m_treeNode;
        private Tiling.Component m_component;

        public MapTreeViewEventArgs(TreeNode treeNode, Tiling.Component component)
        {
            m_treeNode = treeNode;
            m_component = component;
        }

        public TreeNode TreeNode { get { return m_treeNode; } }

        public Tiling.Component Component { get { return m_component; } }
    }

    public delegate void MapTreeViewEventHandler(
        object sender, MapTreeViewEventArgs mapTreeViewEventArgs);
}
