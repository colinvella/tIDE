using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class PlaceTileCommand: Command
    {
        private Layer m_layer; 
        private TileSheet m_tileSheet;
        private int m_tileIndex;
        private Location m_tileLocation;
        private Tile m_oldTile;

        public PlaceTileCommand(Layer layer, TileSheet tileSheet,
            int tileIndex, Location tileLocation)
        {
            m_layer = layer;
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
            m_tileLocation = tileLocation;
        }

        public override void Do()
        {
            m_oldTile = layer.Tiles[tileLocation];
            m_layer.Tiles[m_tileLocation]
                = new StaticTile(m_layer, m_tileSheet, BlendMode.Alpha, m_tileIndex];
        }

        public override void Undo()
        {
            m_layer.Tiles[m_tileLocation] = m_oldTile;
        }
    }
}
