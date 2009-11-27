using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Tiling;

namespace TileMapEditor
{
    class GdiPlusDisplayDevice: DisplayDevice
    {
        private Graphics m_graphics;
        private Dictionary<TileSheet, Bitmap> m_tileSheetBitmaps;

        #region Public Methods

        public GdiPlusDisplayDevice()
        {
            m_graphics = null;
            m_tileSheetBitmaps = new Dictionary<TileSheet, Bitmap>();
        }

        public void LoadTileSheet(TileSheet tileSheet)
        {
            Bitmap bitmap = new Bitmap(tileSheet.ImageSource);
            m_tileSheetBitmaps[tileSheet] = bitmap;
        }

        public void DisposeTileSheet(TileSheet tileSheet)
        {
            m_tileSheetBitmaps.Remove(tileSheet);
        }

        public void BeginScene()
        {
        }

        public void SetClippingRegion(Tiling.Rectangle clippingRegion)
        {
            m_graphics.SetClip(new RectangleF(
                    clippingRegion.Location.X, clippingRegion.Location.Y,
                    clippingRegion.Size.Width, clippingRegion.Size.Height));
        }

        public void DrawTile(Tile tile, Location location)
        {
            Tiling.Rectangle imageBounds = tile.TileSheet.GetTileImageBounds(tile.TileIndex);
            Bitmap bitmap = m_tileSheetBitmaps[tile.TileSheet];
            System.Drawing.Rectangle imageBoundsGDIP = new System.Drawing.Rectangle(
                imageBounds.Location.X, imageBounds.Location.Y,
                imageBounds.Size.Width, imageBounds.Size.Height);
            m_graphics.DrawImage(bitmap, location.X, location.Y, imageBoundsGDIP, GraphicsUnit.Pixel);
        }

        public void EndScene()
        {
        }

        #endregion

        #region Public Properties

        public Graphics Graphics
        {
            get { return m_graphics; }
            set { m_graphics = value; }
        }

        #endregion
    }
}
