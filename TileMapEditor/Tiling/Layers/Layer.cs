using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Display;
using Tiling.ObjectModel;
using Tiling.Tiles;

namespace Tiling.Layers
{
    [Serializable]
    public class Layer : DescribedComponent
    {
        #region Private Variables

        private Map m_map;
        private ReadOnlyCollection<TileSheet> m_tileSheets;
        private Size m_layerSize;
        private Size m_tileSize;
        private Tile[,] m_tiles;
        private TileArray m_tileArray;
        private bool m_visible;

        #endregion

        #region Public Methods

        public Layer(string id, Map map, Size layerSize, Size tileSize)
            : base(id)
        {
            m_map = map;
            m_tileSheets = map.TileSheets;
            m_layerSize = layerSize;
            m_tileSize = tileSize;
            m_tiles = new Tile[layerSize.Width, layerSize.Height];
            m_tileArray = new TileArray(this, m_tiles);
            m_visible = true;
        }

        public bool DependsOnTileSheet(TileSheet tileSheet)
        {
            for (int y = 0; y < m_layerSize.Height; y++)
                for (int x = 0; x < m_layerSize.Width; x++)
                {
                    Tile tile = m_tiles[x, y];
                    if (tile != null && tile.DependsOnTileSheet(tileSheet))
                        return true;
                }
            return false;
        }

        public Location GetTileLocation(Location layerDisplayLocation)
        {
            return new Location(
                layerDisplayLocation.X / m_tileSize.Width,
                layerDisplayLocation.Y / m_tileSize.Height);
        }

        public bool IsValidTileLocation(Location tileLocation)
        {
            return tileLocation.X >= 0 && tileLocation.X < m_layerSize.Width
                && tileLocation.Y >= 0 && tileLocation.Y < m_layerSize.Height;
        }

        public Rectangle ConvertMapToLayerViewport(Rectangle mapViewport)
        {
            Size mapDisplaySize = m_map.DisplaySize;

            return new Rectangle(
                ConvertMapToLayerLocation(
                    mapViewport.Location, mapViewport.Size),
                    mapViewport.Size);
        }

        public Location ConvertMapToLayerLocation(Location mapDisplayLocation, Size viewportSize)
        {
            Size mapDisplaySize = m_map.DisplaySize;
            Size layerDisplaySize = DisplaySize;

            int viewportWidth = viewportSize.Width;
            int viewportHeight = viewportSize.Height;

            int layerWidthDifference = layerDisplaySize.Width - viewportWidth;
            int layerHeightDifference = layerDisplaySize.Height - viewportHeight;

            int mapWidthDifference = mapDisplaySize.Width - viewportWidth;
            int mapHeightDifference = mapDisplaySize.Height - viewportHeight;

            int layerLocationX = mapWidthDifference >= 0
                ? mapDisplayLocation.X * layerWidthDifference / mapWidthDifference
                : 0;

            int layerLocationY = mapHeightDifference >= 0
                ? mapDisplayLocation.Y * layerHeightDifference / mapHeightDifference
                : 0;

            return new Location(layerLocationX, layerLocationY);
        }

        public Location ConvertLayerToMapLocation(Location layerDisplayLocation, Size viewportSize)
        {
            Size mapDisplaySize = m_map.DisplaySize;
            Size layerDisplaySize = DisplaySize;

            return new Location(
                (layerDisplayLocation.X * (mapDisplaySize.Width - viewportSize.Width)) / (layerDisplaySize.Width - viewportSize.Width),
                (layerDisplayLocation.Y * (mapDisplaySize.Height - viewportSize.Height)) / (layerDisplaySize.Height - viewportSize.Height));
        }

        public Rectangle GetTileDisplayRectangle(Rectangle mapViewport, Location tileLocation)
        {
            Location layerViewportLocation = ConvertMapToLayerLocation(mapViewport.Location, mapViewport.Size);

            Location tileDisplayLocation = new Location(
                tileLocation.X * m_tileSize.Width, tileLocation.Y * m_tileSize.Height);

            Location tileDisplayOffset = tileDisplayLocation - layerViewportLocation;

            return new Rectangle(tileDisplayOffset, m_tileSize);
        }

        public Tile PickTile(Location mapDisplayLocation, Size viewportSize)
        {
            Location tileLocation = ConvertMapToLayerLocation(mapDisplayLocation, viewportSize);
            if (IsValidTileLocation(tileLocation))
                return m_tiles[tileLocation.X, tileLocation.Y];
            else
                return null;
        }

        public void RemoveTileSheetDependency(TileSheet tileSheet)
        {
            for (int y = 0; y < m_layerSize.Height; y++)
                for (int x = 0; x < m_layerSize.Width; x++)
                {
                    Tile tile = m_tiles[x, y];
                    if (tile != null && tile.DependsOnTileSheet(tileSheet))
                        m_tiles[x, y] = null;
                }
        }

        public void Draw(IDisplayDevice displayDevice, Location displayOffset, Rectangle mapViewport)
        {
            if (BeforeDraw != null)
                BeforeDraw(new LayerEventArgs(this, mapViewport));

            // determine internal tile offset
            Location tileInternalOffset = new Location(
                mapViewport.Location.X % m_tileSize.Width,
                mapViewport.Location.Y % m_tileSize.Height);

            // determine tile-level viewport location
            int tileXMin = mapViewport.Location.X / m_tileSize.Width;
            int tileYMin = mapViewport.Location.Y / m_tileSize.Height;

            // determine tile-level viewport location limits
            if (tileXMin < 0)
            {
                displayOffset.X -= tileXMin * m_tileSize.Width;
                tileXMin = 0;
            }
            if (tileYMin < 0)
            {
                displayOffset.Y -= tileYMin * m_tileSize.Height;
                tileYMin = 0;
            }

            // determine tile-level viewport size
            int tileColumns = 1 + (mapViewport.Size.Width - 1) / m_tileSize.Width;
            int tileRows = 1 + (mapViewport.Size.Height - 1) / m_tileSize.Height;

            // increment tile-level viewport size if display not tile-aligned
            if (tileInternalOffset.X != 0)
                ++tileColumns;
            if (tileInternalOffset.Y != 0)
                ++tileRows;

            // determine tile-level viewport size limits
            int tileXMax = Math.Min(tileXMin + tileColumns, m_layerSize.Width);
            int tileYMax = Math.Min(tileYMin + tileRows, m_layerSize.Height);

            Location tileLocation = displayOffset - tileInternalOffset;

            for (int tileY = tileYMin; tileY < tileYMax; tileY++)
            {
                tileLocation.X = displayOffset.X - tileInternalOffset.X;
                for (int tileX = tileXMin; tileX < tileXMax; tileX++)
                {
                    Tile tile = m_tiles[tileX, tileY];

                    if (tile != null)
                        displayDevice.DrawTile(tile, tileLocation);

                    tileLocation.X += m_tileSize.Width;
                }
                tileLocation.Y += m_tileSize.Height;
            }

            if (AfterDraw != null)
                AfterDraw(new LayerEventArgs(this, mapViewport));
        }

        #endregion

        #region Public Properties

        public Map Map { get { return m_map; } }

        public Size LayerSize
        {
            get { return m_layerSize; }
            set
            {
                if (m_layerSize == value)
                    return;

                Tile[,] tiles = new Tile[value.Width, value.Height];

                int commonWidth = Math.Min(m_layerSize.Width, value.Width);
                int commonHeight = Math.Min(m_layerSize.Height, value.Height);
                for (int tileY = 0; tileY < commonHeight; tileY++)
                    for (int tileX = 0; tileX < commonWidth; tileX++)
                        tiles[tileX, tileY] = m_tiles[tileX, tileY];
                m_tiles = tiles;
                m_tileArray = new TileArray(this, m_tiles);

                m_layerSize = value;
            }
        }

        public Size TileSize
        {
            get { return m_tileSize; }
            set { m_tileSize = value; }
        }

        public Size DisplaySize
        {
            get
            {
                return new Size(
                    m_layerSize.Width * m_tileSize.Width,
                    m_layerSize.Height * m_tileSize.Height);
            }
        }

        public bool Visible
        {
            get { return m_visible; }
            set { m_visible = value; }
        }

        public TileArray Tiles { get { return m_tileArray; } }

        #endregion

        #region Public Events

        public event LayerEventHandler BeforeDraw;
        public event LayerEventHandler AfterDraw;

        #endregion
    }

    public delegate void LayerEventHandler(LayerEventArgs layerEventArgs);
}
