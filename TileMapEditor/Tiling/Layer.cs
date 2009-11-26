using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class Layer: DescribedComponent
    {
        private Map m_map;
        private ReadOnlyCollection<TileSheet> m_tileSheets;
        private Size m_layerSize;
        private Size m_tileSize;
        private Tile[,] m_tiles;
        private TileArray m_tileArray;

        public Layer(string id, Map map, Size layerSize, Size tileSize)
            : base(id)
        {
            m_map = map;
            m_tileSheets = map.TileSheets;
            m_layerSize = layerSize;
            m_tileSize = tileSize;
            m_tiles = new Tile[layerSize.Width, layerSize.Height];
            m_tileArray = new TileArray(this, m_layerSize, m_tiles);
        }

        public bool DependsOnTileSheet(TileSheet tileSheet)
        {
            for (int y = 0; y < m_layerSize.Height; y++)
                for (int x = 0; x < m_layerSize.Width; x++)
                {
                    Tile tile = m_tiles[x, y];
                    if (tile != null && tile.TileSheet == tileSheet)
                        return true;
                }
            return false;
        }

        public void Draw(DisplayDevice displayDevice, Location displayOffset, Rectangle mapViewPort)
        {
            // determine internal tile offset
            Location tileInternalOffset = new Location(
                mapViewPort.Location.X % m_tileSize.Width,
                mapViewPort.Location.Y % m_tileSize.Height);

            // determine tile-level viewport location
            int tileXMin = mapViewPort.Location.X / m_tileSize.Width;
            int tileYMin = mapViewPort.Location.Y / m_tileSize.Height;

            // determine tile-level viewport size
            int tileColumns = mapViewPort.Size.Width / m_tileSize.Width;
            int tileRows = mapViewPort.Size.Height / m_tileSize.Height;

            // increment tile-level viewport size if display not tile-aligned
            if (tileInternalOffset.X != 0)
                ++tileColumns;
            if (tileInternalOffset.Y != 0)
                ++tileRows;

            // determine tile-level viewport limits
            int tileXMax = tileXMin + tileColumns;
            int tileYMax = tileYMin + tileRows;

            Location tileLocation = displayOffset - tileInternalOffset;

            for (int tileY = tileYMin; tileY < tileYMax; tileY++)
            {
                tileLocation.X = displayOffset.X - tileInternalOffset.X;
                for (int tileX = tileXMin; tileX < tileXMax; tileX++)
                {
                    Tile tile = m_tiles[tileX, tileY];

                    displayDevice.DrawTile(tile, tileLocation);

                    tileLocation.X += m_tileSize.Width;
                }
                tileLocation.Y += m_tileSize.Height;
            }

        }

        public Map Map { get { return m_map; } }

        public Size LayerSize { get { return m_layerSize; } }

        public Size TileSize { get { return m_tileSize; } }

        public TileArray Tiles { get { return m_tileArray; } }
    }
}
