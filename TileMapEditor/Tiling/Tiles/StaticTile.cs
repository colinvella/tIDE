using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Layers;

namespace Tiling.Tiles
{
    [Serializable]
    public class StaticTile : Tile
    {
        private int m_tileIndex;

        public StaticTile(Layer layer, TileSheet tileSheet, BlendMode blendMode, int tileIndex)
            : base(layer, tileSheet, blendMode)
        {
            if (tileIndex < 0 || tileIndex >= tileSheet.TileCount)
                throw new Exception("The specified Tile Index is out of range");

            m_tileIndex = tileIndex;
        }

        public override Tile Clone()
        {
            return new StaticTile(this.Layer, this.TileSheet, this.BlendMode, m_tileIndex);
        }

        public override int TileIndex { get { return m_tileIndex; } }

        public override string ToString()
        {
            return "Static TileIndex=" + m_tileIndex + " BlendMode=" + BlendMode;
        }
    }
}
