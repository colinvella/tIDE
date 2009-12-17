using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Tiles;

namespace TileMapEditor.Control
{
    public class MapPanelEventArgs
    {
        private Tile m_tile;

        public MapPanelEventArgs(Tile tile)
        {
            m_tile = tile;
        }

        public Tile Tile { get { return m_tile; } }
    }
}
