using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Tiling;

namespace TileMapEditor
{
    public class TileImageCache
    {
        private static TileImageCache s_tileImageCache = new TileImageCache();

        private Dictionary<TileSheet, Bitmap[]> m_bitmapCache;

        private TileImageCache()
        {
            m_bitmapCache = new Dictionary<TileSheet, Bitmap[]>();
        }

        public static TileImageCache Instance { get { return s_tileImageCache; } }

        public void Refresh(TileSheet tileSheet)
        {
            Bitmap tileSheetBitmap = new Bitmap(tileSheet.ImageSource);

            int tileCount = tileSheet.TileCount;
            Bitmap[] tileBitmaps = new Bitmap[tileCount];
            Tiling.Size tileSize = tileSheet.TileSize;

            System.Drawing.Rectangle destRect
                = new System.Drawing.Rectangle(0, 0, tileSize.Width, tileSize.Height);

            System.Drawing.Rectangle srcRect
                = new System.Drawing.Rectangle(destRect.Location, destRect.Size);

            for (int tileIndex = 0; tileIndex < tileCount; tileIndex++)
            {
                Tiling.Rectangle tileRectangle = tileSheet.GetTileImageBounds(tileIndex);
                srcRect.X = tileRectangle.Location.X;
                srcRect.Y = tileRectangle.Location.Y;
                srcRect.Width = tileRectangle.Size.Width;
                srcRect.Height = tileRectangle.Size.Height;

                Bitmap tileBitmap = tileSheetBitmap.Clone(
                     srcRect, tileSheetBitmap.PixelFormat);
 
                tileBitmaps[tileIndex] = tileBitmap;
            }

            m_bitmapCache[tileSheet] = tileBitmaps;
        }

        public void Clear(TileSheet tileSheet)
        {
            m_bitmapCache.Remove(tileSheet);
        }

        public Bitmap GetTileBitmap(TileSheet tileSheet, int tileIndex)
        {
            return m_bitmapCache[tileSheet][tileIndex];
        }
    }
}
