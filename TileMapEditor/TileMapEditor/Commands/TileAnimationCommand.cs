using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Layers;
using XTile.Tiles;

namespace TileMapEditor.Commands
{
    internal class TileAnimationCommand: Command
    {
        private Layer m_layer;
        private Location m_tileLocation;
        private Tile m_oldTile;
        private AnimatedTile m_animatedTile;

        public TileAnimationCommand(Layer layer, Location tileLocation, AnimatedTile animatedTile)
        {
            m_layer = layer;
            m_tileLocation = tileLocation;
            m_animatedTile = animatedTile;
            m_oldTile = null;
            m_description = "Set animated tile at " + tileLocation;
        }

        public override void Do()
        {
            m_oldTile = m_layer.Tiles[m_tileLocation];
            m_layer.Tiles[m_tileLocation] = m_animatedTile;
        }

        public override void Undo()
        {
            m_layer.Tiles[m_tileLocation] = m_oldTile;
        }
    }
}
