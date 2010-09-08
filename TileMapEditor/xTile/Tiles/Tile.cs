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

using XTile.ObjectModel;
using XTile.Layers;

namespace XTile.Tiles
{
    /// <summary>
    /// Tile Blending Mode
    /// </summary>
    [Serializable]
    public enum BlendMode
    {
        /// <summary>
        /// Alpha blending based on alpha channel
        /// </summary>
        Alpha,

        /// <summary>
        /// Additive blending
        /// </summary>
        Additive
    }

    /// <summary>
    /// Partially abstract, base implementation for all tile types
    /// </summary>
    [Serializable]
    public abstract class Tile: Component
    {
        #region Public Properties

        /// <summary>
        /// Layer containing the tile
        /// </summary>
        public Layer Layer { get { return m_layer; } }

        /// <summary>
        /// Tile blending mode
        /// </summary>
        public abstract BlendMode BlendMode { get; set; }

        /// <summary>
        /// Tile sheet from which the tile originates. May vary over time
        /// for animated tiles
        /// </summary>
        public abstract TileSheet TileSheet { get; }

        /// <summary>
        /// Tile's index into the associated tile sheet. For an animated
        /// tile, the sheet may vary according to the current animation
        /// frame
        /// </summary>
        public abstract int TileIndex { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a new tile for the given layer
        /// </summary>
        /// <param name="layer">Layer to which the tile is assigned</param>
        public Tile(Layer layer)
        {
            m_layer = layer;
        }

        /// <summary>
        /// Tests if this tile depends on the given tile sheet
        /// </summary>
        /// <param name="tileSheet">tile sheet to test</param>
        /// <returns>True if the tile depends on the given tile sheet, False otherwise</returns>
        public abstract bool DependsOnTileSheet(TileSheet tileSheet);

        /// <summary>
        /// Clones this tile for the given layer
        /// </summary>
        /// <param name="layer">Layer to assign to the new tile</param>
        /// <returns>Cloned tile implementation</returns>
        public abstract Tile Clone(Layer layer);

        #endregion

        #region Private Variables

        private Layer m_layer;

        #endregion
    }
}
