using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.History
{
    internal class TileHistoryEntry: HistoryEntry
    {
        private Layer m_layer;
        private Location m_tileLocation;
        private Tile m_oldTile;
        private Tile m_newTile;

        public TileHistoryEntry(Layer layer, Location tileLocation,
            Tile oldTile, Tile newTile)
        {
            m_layer = layer;
            m_tileLocation = tileLocation;
            m_oldTile = oldTile;
            m_newTile = newTile;
        }

        public override void Undo()
        {
            m_layer.Tiles[m_tileLocation] = m_oldTile;
        }

        public override void Redo()
        {
            m_layer.Tiles[m_tileLocation] = m_newTile;
        }

        public override string Description
        {
            get
            {
                return "Replace tile at " + m_tileLocation
                    + " in layer " + m_layer;
            }
        }
    }
}
