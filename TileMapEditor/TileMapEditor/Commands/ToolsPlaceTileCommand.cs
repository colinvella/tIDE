using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class ToolsPlaceTileCommand: Command
    {
        private Layer m_layer; 
        private Tile m_newTile;
        private Location m_tileLocation;
        private Tile m_oldTile;

        public ToolsPlaceTileCommand(Layer layer, Tile newTile, Location tileLocation)
        {
            m_layer = layer;
            m_newTile = newTile;
            m_tileLocation = tileLocation;

            m_description = "Place tile \"" + m_newTile.TileSheet.Id + ":" + m_newTile.TileIndex 
                + "\" at " + m_tileLocation + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            m_oldTile = m_layer.Tiles[m_tileLocation];
            m_layer.Tiles[m_tileLocation]
                = m_newTile.Clone();
        }

        public override void Undo()
        {
            m_layer.Tiles[m_tileLocation] = m_oldTile;
        }
    }
}
