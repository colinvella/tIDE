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

using xTile.Dimensions;
using xTile.Tiles;

namespace xTile.Display
{
    /// <summary>
    /// Abstract representation of a display device. The device supports basic rendering
    /// functions related to tile sheet management and tile drawing
    /// </summary>
    public interface IDisplayDevice : IDisposable
    {
        #region Public Methods

        /// <summary>
        /// Loads resources assocaited with the given tile sheet
        /// </summary>
        /// <param name="tileSheet">Tile sheet to load</param>
        void LoadTileSheet(TileSheet tileSheet);

        /// <summary>
        /// Frees any resources associated with the given tile sheet
        /// </summary>
        /// <param name="tileSheet">Tile sheet to dispose</param>
        void DisposeTileSheet(TileSheet tileSheet);

        /// <summary>
        /// Performs any actions required to initialise rendering of a single frame
        /// </summary>
        void BeginScene();

        /// <summary>
        /// Sets the viewport of the display device. This method assumes the the
        /// graphics coordinate origin is shifted to match the top-left corner of
        /// the viewport.
        /// </summary>
        /// <param name="clippingRegion">Clipping region to apply</param>
        void SetViewport(Rectangle viewport);

        /// <summary>
        /// Draws the given tile at the given location
        /// </summary>
        /// <param name="tile">Tile to draw</param>
        /// <param name="location">Drawing location</param>
        void DrawTile(Tile tile, Location location);

        /// <summary>
        /// Performs any actions necessary to terminate rendering of the current frame
        /// </summary>
        void EndScene();

        #endregion
    }
}
