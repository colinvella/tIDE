using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class TileAnimationDialog : Form
    {
        private Map m_map;
        private Layer m_layer;
        private Location m_tileLocation;
        private TileSheet m_draggedTileSheet;
        private int m_draggedTileIndex;

        private void AddTileFrame(TileSheet tileSheet, int tileIndex)
        {
            int imageListIndex = -1;
            foreach (ListViewItem listViewItem in m_animationListView.Items)
            {
                StaticTile tileFrame = (StaticTile)listViewItem.Tag;
                if (tileFrame.TileSheet == tileSheet
                    && tileFrame.TileIndex == tileIndex)
                {
                    imageListIndex = listViewItem.ImageIndex;
                    break;
                }
            }
            if (imageListIndex == -1)
            {
                Image tileImage = TileImageCache.Instance.GetTileBitmap(tileSheet, tileIndex);
                m_imageListAnimation.Images.Add(tileImage);
                imageListIndex = m_imageListAnimation.Images.Count - 1;
            }
            ListViewItem newListViewItem = new ListViewItem("Frame #" + m_animationListView.Items.Count, imageListIndex);
            newListViewItem.Tag = new StaticTile(m_layer, tileSheet, BlendMode.Alpha, tileIndex);
            m_animationListView.Items.Add(newListViewItem);
        }

        private void TileAnimationDialog_Load(object sender, EventArgs eventArgs)
        {
            m_tilePicker.Map = m_map;
            m_tilePicker.UpdatePicker();
        }

        private void OnTileDrag(object sender, TileDragEventArgs tileDragEventArgs)
        {
            m_draggedTileSheet = tileDragEventArgs.TileSheet;
            m_draggedTileIndex = tileDragEventArgs.TileIndex;
        }

        private void OnTileDragEnter(object sender, DragEventArgs dragEventArgs)
        {
            dragEventArgs.Effect = DragDropEffects.Copy;
        }

        private void OnTileDragDrop(object sender, DragEventArgs dragEventArgs)
        {
            AddTileFrame(m_draggedTileSheet, m_draggedTileIndex);
            m_draggedTileSheet = null;
            m_draggedTileIndex = -1;
        }

        public TileAnimationDialog(Map map, Layer layer, Location tileLocation)
        {
            InitializeComponent();

            m_map = map;
            m_layer = layer;
            m_tileLocation = tileLocation;

            Tile tile = m_layer.Tiles[m_tileLocation];
            if (tile != null)
            {
                if (tile is StaticTile)
                    AddTileFrame(tile.TileSheet, tile.TileIndex);
                else if (tile is AnimatedTile)
                {
                    foreach (StaticTile tileFrame in (tile as AnimatedTile).TileFrames)
                        AddTileFrame(tileFrame.TileSheet, tileFrame.TileIndex);
                }
            }
        }
    }
}
