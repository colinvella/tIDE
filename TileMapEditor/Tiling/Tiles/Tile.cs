using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.ObjectModel;
using Tiling.Layers;

namespace Tiling.Tiles
{
    [Serializable]
    public enum BlendMode
    {
        Alpha,
        Additive
    }

    [Serializable]
    public abstract class Tile: Component
    {
        private Layer m_layer;
        private BlendMode m_blendMode;

        public Tile(Layer layer, BlendMode blendMode)
        {
            m_layer = layer;
            m_blendMode = blendMode;
        }

        public Layer Layer { get { return m_layer; } }

        public BlendMode BlendMode
        {
            get { return m_blendMode; }
            set { m_blendMode = value; }
        }

        public abstract TileSheet TileSheet { get; }

        public abstract int TileIndex { get; }

        public abstract Tile Clone();
}
}
