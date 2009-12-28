using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class EraseTileCommand: Command
    {
        private Layer m_layer; 
        private Location m_tileLocation;
        private Tile m_oldTile;

        public EraseTileCommand(Layer layer, Location tileLocation)
        {
            m_layer = layer;
            m_tileLocation = tileLocation;

            m_description = "Erase tile at " + m_tileLocation
                + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            m_oldTile = m_layer.Tiles[m_tileLocation];
            m_layer.Tiles[m_tileLocation] = null;
        }

        public override void Undo()
        {
            m_layer.Tiles[m_tileLocation] = m_oldTile;
        }
    }
}
