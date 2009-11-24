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

        public MapTreeView()
        {
            InitializeComponent();
        }

        public void Rebuild()
        {
            m_treeView.Nodes.Clear();

            if (m_map == null)
                return;

            int mapImageIndex =  m_imageList.Images.IndexOfKey("Map.png");
            TreeNode mapNode = new TreeNode("Map - " + m_map.Id, mapImageIndex, mapImageIndex);

            int collectionImageIndex = m_imageList.Images.IndexOfKey("Collection.png");
            TreeNode layersNode = new TreeNode("Layers", collectionImageIndex, collectionImageIndex);
            mapNode.Nodes.Add(layersNode);
            TreeNode tileSheetsNode = new TreeNode("Tile Sheets", collectionImageIndex, collectionImageIndex);
            mapNode.Nodes.Add(tileSheetsNode);

            m_treeView.Nodes.Add(mapNode);
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
                Rebuild();
            }
        }

        #endregion
    }
}
