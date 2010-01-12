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

        private void OnTileDragDrop(object sender, DragEventArgs dragEventArgs)
        {
            MessageBox.Show(dragEventArgs.Data.ToString());
        }

        public TileAnimationDialog(Map map, Layer layer, Location tileLocation)
        {
            InitializeComponent();

            m_map = map;
            m_layer = layer;
            m_tileLocation = tileLocation;

            Tile tile = m_layer.Tiles[m_tileLocation];
        }
    }
}
