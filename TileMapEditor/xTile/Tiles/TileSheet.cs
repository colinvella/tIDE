/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Public License (Ms-PL)                            //
//             http://www.opensource.org/licenses/ms-pl.html               //
//                                                                         //
//  AUTHOR     Colin Vella                                                 //
//                                                                         //
//  CODEBASE   http://tide.codeplex.com                                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.ObjectModel;

namespace XTile.Tiles
{
    /// <summary>
    /// Represents an indexed tile sheet based on a tile image source
    /// </summary>
    [Serializable]
    public class TileSheet : DescribedComponent
    {
        #region Public Properties

        /// <summary>
        /// Map to which this TileSheet is assigned
        /// </summary>
        public Map Map { get { return m_map; } }

        /// <summary>
        /// Reference to a tile image source. May be a disk path, URL,
        /// content pipeline reference etc. - subject to display
        /// device implementation in use
        /// </summary>
        public string ImageSource
        {
            get { return m_imageSource; }
            set { m_imageSource = value; }
        }

        /// <summary>
        /// Width and height of the TileSheet in tiles
        /// </summary>
        public Size SheetSize
        {
            get { return m_sheetSize; }
            set { m_sheetSize = value; }
        }

        /// <summary>
        /// Width and geight of the tiles in pixels for this TileSheet
        /// </summary>
        public Size TileSize
        {
            get { return m_tileSize; }
            set { m_tileSize = value; }
        }

        /// <summary>
        /// Left and top margin from the top-left corner of the image source
        /// </summary>
        public Size Margin
        {
            get { return m_margin; }
            set { m_margin = value; }
        }

        /// <summary>
        /// Horizontal and vertical padding in pixels between tiles in the
        /// image source
        /// </summary>
        public Size Spacing
        {
            get { return m_spacing; }
            set { m_spacing = value; }
        }

        /// <summary>
        /// Number of tiles within the sheet, computed from the source
        /// image size, margin, spacing and tile size
        /// </summary>
        public int TileCount
        {
            get
            {
                return m_sheetSize.Width * m_sheetSize.Height;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a TileSheet for the given map, image source, sheet size
        /// and tile size. An GUID-based ID is automatically assigned to the
        /// sheet
        /// </summary>
        /// <param name="map">Map associated with the tile sheet</param>
        /// <param name="imageSource">Reference to an image source</param>
        /// <param name="sheetSize">Size of the sheet in tiles</param>
        /// <param name="tileSize">Size of the tiles in pixels</param>
        public TileSheet(Map map, string imageSource, Size sheetSize, Size tileSize)
        {
            m_map = map;
            m_imageSource = imageSource;
            m_sheetSize = sheetSize;
            m_tileSize = tileSize;
            m_margin = m_spacing = Size.Zero;
        }

        /// <summary>
        /// Constructs a TileSheet for the given ID, map, image source, sheet
        /// size and tile size
        /// </summary>
        /// <param name="id">ID to assign to the tile sheet</param>
        /// <param name="map">Map associated with the tile sheet</param>
        /// <param name="imageSource">Reference to an image source</param>
        /// <param name="sheetSize">Size of the sheet in tiles</param>
        /// <param name="tileSize">Size of the tiles in pixels</param>
        public TileSheet(string id, Map map, string imageSource, Size sheetSize, Size tileSize)
            : base(id)
        {
            m_map = map;
            m_imageSource = imageSource;
            m_sheetSize = sheetSize;
            m_tileSize = tileSize;
            m_margin = m_spacing = Size.Zero;
        }

        /// <summary>
        /// Computes the bounds of a tile in pixels within this TileSheet
        /// given the tile index
        /// </summary>
        /// <param name="tileIndex">Tile index into this TileSheet</param>
        /// <returns>Tile bounds in pixels within this TileSheet</returns>
        public Rectangle GetTileImageBounds(int tileIndex)
        {
            int tileX = tileIndex % m_sheetSize.Width;
            int tileY = tileIndex / m_sheetSize.Width;
            Location location = new Location(
                m_margin.Width + (m_tileSize.Width + m_spacing.Width) * tileX,
                m_margin.Height + (m_tileSize.Height + m_spacing.Height) * tileY);

            return new Rectangle(location, m_tileSize);
        }

        /// <summary>
        /// Returns the index of the tile contining the given pixel
        /// location within this TileSheet
        /// </summary>
        /// <param name="pixelLocation">Pixel location for which to compute tile index</param>
        /// <returns>Tile index computed from the given pixel location</returns>
        public int GetTileIndex(Location pixelLocation)
        {
            int tileX = (pixelLocation.X - m_margin.Width) / (m_tileSize.Width + m_spacing.Width);
            int tileY = (pixelLocation.Y - m_margin.Height) / (m_tileSize.Height + m_spacing.Height);

            return tileY * m_sheetSize.Width + tileX;
        }

        #endregion

        #region Private Variables

        private Map m_map;
        private string m_imageSource;
        private Size m_sheetSize;
        private Size m_tileSize;
        private Size m_margin;
        private Size m_spacing;

        #endregion
    }
}
