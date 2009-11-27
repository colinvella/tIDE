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
        private Map m_map;

        private void UpdateTileSheetsSubTree(TreeNode tileSheetsNode)
        {
            // remove nodes for deleted tile sheets
            for (int nodeIndex = 0; nodeIndex < tileSheetsNode.Nodes.Count; )
            {
                TreeNode tileSheetNode = tileSheetsNode.Nodes[nodeIndex];

                if (m_map.TileSheets.Contains((TileSheet)tileSheetNode.Tag))
                    ++nodeIndex;
                else
                    tileSheetsNode.Nodes.Remove(tileSheetNode);
            }

            // add nodes for new tile sheets, or update existing
            int tileSheetImageIndex = m_imageList.Images.IndexOfKey("TileSheet.png");
            foreach (TileSheet tileSheet in m_map.TileSheets)
            {
                bool bMatched = false;
                foreach (TreeNode tileSheetNode in tileSheetsNode.Nodes)
                    if (tileSheetNode.Tag == tileSheet)
                    {
                        bMatched = true;
                        tileSheetNode.Text = ((TileSheet)tileSheetNode.Tag).Id;
                        break;
                    }

                // add new node if needed
                if (!bMatched)
                {
                    TreeNode tileSheetNode = new TreeNode(tileSheet.Id, tileSheetImageIndex, tileSheetImageIndex);
                    tileSheetNode.Tag = tileSheet;
                    tileSheetsNode.Nodes.Add(tileSheetNode);

                    m_treeView.SelectedNode = tileSheetNode;
                }
            }
        }

        public MapTreeView()
        {
            InitializeComponent();
        }

        public void UpdateTree()
        {
            if (m_map == null)
            {
                m_treeView.Nodes.Clear();
                return;
            }

            // determine image list indices
            int mapImageIndex = m_imageList.Images.IndexOfKey("Map.png");
            int collectionImageIndex = m_imageList.Images.IndexOfKey("Collection.png");
            int layerImageIndex = m_imageList.Images.IndexOfKey("Layer.png");
            int tileSheetImageIndex = m_imageList.Images.IndexOfKey("TileSheet.png");

            // map root node
            TreeNode mapNode = null;
            TreeNode layersNode = null;
            TreeNode tileSheetsNode = null;
            if (m_treeView.Nodes.Count == 0)
            {
                // create root map node
                mapNode = new TreeNode(m_map.Id, mapImageIndex, mapImageIndex);
                mapNode.Tag = m_map;

                // create layer collection node
                layersNode = new TreeNode("Layers", collectionImageIndex, collectionImageIndex);
                layersNode.Tag = m_map.Layers;
                mapNode.Nodes.Add(layersNode);

                // create tilesheet collection node
                tileSheetsNode = new TreeNode("Tile Sheets", collectionImageIndex, collectionImageIndex);
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
                tileSheetsNode = mapNode.Nodes[1];
            }

            // tile sheets
            UpdateTileSheetsSubTree(tileSheetsNode);
        }

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

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the selected component node is changed")]
        public event MapTreeViewEventHandler ComponentChanged;

        #endregion

        private void m_treeView_AfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
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
