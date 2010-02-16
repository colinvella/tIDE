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
        private BlendMode m_blendMode;
        private TileSheet m_tileSheet;
        private int m_tileIndex;

        public StaticTile(Layer layer, TileSheet tileSheet, BlendMode blendMode, int tileIndex)
            : base(layer)
        {
            if (!layer.Map.TileSheets.Contains(tileSheet))
                throw new Exception("The specified TileSheet is not in the parent map");

            m_blendMode = blendMode;

            m_tileSheet = tileSheet;

            if (tileIndex < 0 || tileIndex >= tileSheet.TileCount)
                throw new Exception("The specified Tile Index is out of range");

            m_tileIndex = tileIndex;
        }

        public override bool DependsOnTileSheet(TileSheet tileSheet)
        {
            return m_tileSheet == tileSheet;
        }

        public override Tile Clone()
        {
            return new StaticTile(this.Layer, this.TileSheet, this.BlendMode, m_tileIndex);
        }

        public override BlendMode BlendMode
        {
            get { return m_blendMode; }
            set { m_blendMode = value; }
        }

        public override TileSheet TileSheet { get { return m_tileSheet; } }

        public override int TileIndex { get { return m_tileIndex; } }

        public override string ToString()
        {
            return "Static TileIndex=" + m_tileIndex + " BlendMode=" + BlendMode;
        }
    }
}
