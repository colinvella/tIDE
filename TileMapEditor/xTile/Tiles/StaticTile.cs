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

using xTile.Layers;

namespace xTile.Tiles
{
    /// <summary>
    /// Static tile implementation
    /// </summary>
    public class StaticTile : Tile
    {
        #region Public Properties

        /// <summary>
        /// Tile blending mode
        /// </summary>
        public override BlendMode BlendMode
        {
            get { return m_blendMode; }
            set { m_blendMode = value; }
        }

        /// <summary>
        /// Tile sheet from which the tile originates
        /// </summary>
        public override TileSheet TileSheet { get { return m_tileSheet; } }

        /// <summary>
        /// Index of the tile in the associated tile sheet
        /// </summary>
        public override int TileIndex
        {
            get { return m_tileIndex; }
            set { m_tileIndex = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a static tile for the given layer, tile sheet, blend
        /// mode and tile index
        /// </summary>
        /// <param name="layer">Layer to assign the tile to</param>
        /// <param name="tileSheet">Tile sheet associated with the tile</param>
        /// <param name="blendMode">Tile blend mode</param>
        /// <param name="tileIndex">Index of the tile in the given tile sheet</param>
        public StaticTile(Layer layer, TileSheet tileSheet, BlendMode blendMode, int tileIndex)
            : base(layer)
        {
            if (!layer.Map.TileSheets.Contains(tileSheet))
                throw new Exception("The specified TileSheet is not in the parent map");

            m_blendMode = blendMode;

            m_tileSheet = tileSheet;

            if (tileIndex < 0 || tileIndex >= tileSheet.TileCount)
                throw new Exception("The specified Tile Index is out of range");

            m_tileIndex = tileIndex;
        }

        /// <summary>
        /// Tests if this tile depends on the given tile sheet
        /// </summary>
        /// <param name="tileSheet">Tile sheet to test</param>
        /// <returns>True if this tile depends on the sheet, False otherwise</returns>
        public override bool DependsOnTileSheet(TileSheet tileSheet)
        {
            return m_tileSheet == tileSheet;
        }

        /// <summary>
        /// Clones the tile for the given Layer
        /// </summary>
        /// <param name="layer">Layer to assigned to the cloned tile</param>
        /// <returns>Cloned static tile</returns>
        public override Tile Clone(Layer layer)
        {
            return new StaticTile(layer, this.TileSheet, this.BlendMode, m_tileIndex);
        }

        /// <summary>
        /// Generates and returns a string representation of the tile
        /// </summary>
        /// <returns>String representation of the tile</returns>
        public override string ToString()
        {
            return "Static Tile Index=" + m_tileIndex + " BlendMode=" + BlendMode;
        }

        #endregion

        #region Private Variables

        private BlendMode m_blendMode;
        private TileSheet m_tileSheet;
        private int m_tileIndex;

        #endregion
    }
}
