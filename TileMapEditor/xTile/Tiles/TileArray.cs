﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Layers;

namespace XTile.Tiles
{
    [Serializable]
    public class TileArray
    {
        private Layer m_layer;
        private ReadOnlyCollection<TileSheet> m_tileSheets;

        private Tile[,] m_tiles;

        public TileArray(Layer layer, Tile[,] tiles)
        {
            m_layer = layer;
            m_tileSheets = m_layer.Map.TileSheets;
            m_tiles = tiles;
        }

        public Tile this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= m_layer.LayerSize.Width
                    || y < 0 || y >= m_layer.LayerSize.Height)
                    throw new Exception("Tile indices out of bounds");
                return m_tiles[x, y];
            }

            set
            {
                if (x < 0 || x >= m_layer.LayerSize.Width
                    || y < 0 || y >= m_layer.LayerSize.Height)
                    throw new Exception("Tile indices out of bounds");

                if (value == null)
                {
                    m_tiles[x, y] = null;
                    return;
                }

                if (value.TileSheet.TileSize != m_layer.TileSize)
                    throw new Exception("Incompatible tile size");


                if (!(m_tileSheets.Contains(value.TileSheet)))
                    throw new Exception("The tile contains an invalid TileSheet reference");

                if (value.TileIndex < 0 || value.TileIndex >= value.TileSheet.TileCount)
                    throw new Exception("Invalid tile index");

                m_tiles[x, y] = value;
            }
        }

        public Tile this[Location location]
        {
            get { return this[location.X, location.Y]; }
            set { this[location.X, location.Y] = value; }
        }
    }
}