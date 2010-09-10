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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using xTile.Dimensions;
using xTile.Layers;

namespace xTile.Tiles
{
    /// <summary>
    /// Doubly-indexed tile array used to hold tiles within a Layer
    /// </summary>
    [Serializable]
    public class TileArray
    {
        #region Public Properties

        /// <summary>
        /// Tile accessor using horizontal and vertical coordinates
        /// </summary>
        /// <param name="x">Horizontal tile coordinate</param>
        /// <param name="y">Vertical tile coordinate</param>
        /// <returns></returns>
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

        /// <summary>
        /// Tile accessor using Location instance
        /// </summary>
        /// <param name="location">Tile location</param>
        /// <returns></returns>
        public Tile this[Location location]
        {
            get { return this[location.X, location.Y]; }
            set { this[location.X, location.Y] = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a TileArray for the given Layer and
        /// using the given 2d Tile array
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="tiles"></param>
        public TileArray(Layer layer, Tile[,] tiles)
        {
            m_layer = layer;
            m_tileSheets = m_layer.Map.TileSheets;
            m_tiles = tiles;
        }

        #endregion

        #region Private Variables

        private Layer m_layer;
        private ReadOnlyCollection<TileSheet> m_tileSheets;
        private Tile[,] m_tiles;

        #endregion
    }
}
