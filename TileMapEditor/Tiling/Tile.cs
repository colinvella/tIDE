using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public enum BlendMode
    {
        Alpha,
        Additive
    }

    public abstract class Tile: Component
    {
        private Layer m_layer;
        private TileSheet m_tileSheet;
        private BlendMode m_blendMode;

        public Tile(Layer layer, TileSheet tileSheet, BlendMode blendMode)
        {
            if (!layer.Map.TileSheets.Contains(tileSheet))
                throw new Exception("The specified TileSheet is not in the parent map");

            m_layer = layer;
            m_tileSheet = tileSheet;
            m_blendMode = blendMode;
        }

        public Layer Layer { get { return m_layer; } }

        public TileSheet TileSheet { get { return m_tileSheet; } }

        public BlendMode BlendMode
        {
            get { return m_blendMode; }
            set { m_blendMode = value; }
        }

        public abstract int TileIndex { get; }
    }
}
