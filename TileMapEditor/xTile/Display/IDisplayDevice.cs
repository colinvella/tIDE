using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Tiles;

namespace XTile.Display
{
    /// <summary>
    /// Abstract representation of a display device. The device supports basic rendering
    /// functions related to tile sheet management and tile drawing
    /// </summary>
    public interface IDisplayDevice
    {
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
        /// Sets the allowed drawing region associated with the device. This
        /// functionality is used to by the rendering engine according to the
        /// configured view port.
        /// </summary>
        /// <param name="clippingRegion">Clipping region to apply</param>
        void SetClippingRegion(Rectangle clippingRegion);

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
    }
}
