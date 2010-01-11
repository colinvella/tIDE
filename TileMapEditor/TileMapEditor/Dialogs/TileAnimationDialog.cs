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

namespace TileMapEditor.Dialogs
{
    public partial class TileAnimationDialog : Form
    {
        private Map m_map;
        private Layer m_layer;
        private Location m_tileLocation;

        private void TileAnimationDialog_Load(object sender, EventArgs eventArgs)
        {
            m_tilePicker.Map = m_map;
            m_tilePicker.UpdatePicker();
        }

        public TileAnimationDialog(Map map, Layer layer, Location tileLocation)
        {
            InitializeComponent();

            m_map = map;
            m_layer = layer;
            m_tileLocation = tileLocation;
        }
    }
}
