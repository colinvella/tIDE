using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Dimensions;
using xTile.Tiles;

namespace tIDE.Controls
{
    public class MapPanelEventArgs: EventArgs
    {
        private Tile m_tile;
        private Location m_location;

        public MapPanelEventArgs(Tile tile, Location location)
        {
            m_tile = tile;
            m_location = location;
        }

        public Tile Tile
        {
            get { return m_tile; }
        }

        public Location Location
        {
            get { return m_location; }
        }
    }
}
