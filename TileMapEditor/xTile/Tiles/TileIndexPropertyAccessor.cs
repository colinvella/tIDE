using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile.ObjectModel;

namespace xTile.Tiles
{
    /// <summary>
    /// Accessor class for tile index properties, associated with
    /// a specific tile sheet
    /// </summary>
    public class TileIndexPropertyAccessor
    {
        #region Ppublic Properties

        /// <summary>
        /// The property collection associated with a given tile index
        /// </summary>
        /// <param name="tileIndex">Tile index for which to access the properties</param>
        /// <returns>a property collection for the given tile index</returns>
        public IPropertyCollection this[int tileIndex]
        {
            get
            {
                if (tileIndex < 0 || tileIndex >= m_tileSheet.TileCount)
                    throw new IndexOutOfRangeException(
                        "Tile index #" + tileIndex + " is out of range");
                return new TileIndexPropertyCollection(m_tileSheet, tileIndex);
            }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Constructs an accessor for the given tile sheet
        /// </summary>
        /// <param name="tileSheet">Tile sheet associated with the accessor</param>
        internal TileIndexPropertyAccessor(TileSheet tileSheet)
        {
            m_tileSheet = tileSheet;
        }

        #endregion

        #region Private Fields

        private TileSheet m_tileSheet;

        #endregion
    }
}
