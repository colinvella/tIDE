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

        public Tile(Layer layer)
        {
            m_layer = layer;
        }

        public Layer Layer { get { return m_layer; } }

        public abstract BlendMode BlendMode { get; set; }

        public abstract TileSheet TileSheet { get; }

        public abstract int TileIndex { get; }

        public abstract Tile Clone();
}
}
