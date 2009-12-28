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
        private string m_description;

        public TileHistoryEntry(Layer layer, Location tileLocation,
            Tile oldTile, Tile newTile, string description)
        {
            m_layer = layer;
            m_tileLocation = tileLocation;
            m_oldTile = oldTile;
            m_newTile = newTile;
            m_description = description;
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
            get { return m_description; }
        }
    }
}
