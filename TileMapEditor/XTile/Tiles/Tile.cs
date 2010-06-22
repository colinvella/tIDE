using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.ObjectModel;
using XTile.Layers;

namespace XTile.Tiles
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

        public abstract bool DependsOnTileSheet(TileSheet tileSheet);

        public abstract Tile Clone();

        public Layer Layer { get { return m_layer; } }

        public abstract BlendMode BlendMode { get; set; }

        public abstract TileSheet TileSheet { get; }

        public abstract int TileIndex { get; set; }
    }
}
