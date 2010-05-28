using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Dimensions;
using Tiling.Tiles;

namespace TileMapEditor
{
    public class TileImageCache
    {
        private static TileImageCache s_tileImageCache = new TileImageCache();

        private Dictionary<TileSheet, System.Drawing.Bitmap[]> m_bitmapCache;

        private TileImageCache()
        {
            m_bitmapCache = new Dictionary<TileSheet, System.Drawing.Bitmap[]>();
        }

        public static TileImageCache Instance { get { return s_tileImageCache; } }

        public void Refresh(TileSheet tileSheet)
        {
            try
            {
                using (System.Drawing.Bitmap tileSheetBitmap
                    = new System.Drawing.Bitmap(tileSheet.ImageSource))
                {

                    int tileCount = tileSheet.TileCount;
                    System.Drawing.Bitmap[] tileBitmaps = new System.Drawing.Bitmap[tileCount];
                    Size tileSize = tileSheet.TileSize;

                    System.Drawing.Rectangle destRect
                        = new System.Drawing.Rectangle(0, 0, tileSize.Width, tileSize.Height);

                    System.Drawing.Rectangle srcRect
                        = new System.Drawing.Rectangle(destRect.Location, destRect.Size);

                    for (int tileIndex = 0; tileIndex < tileCount; tileIndex++)
                    {
                        Rectangle tileRectangle = tileSheet.GetTileImageBounds(tileIndex);
                        srcRect.X = tileRectangle.Location.X;
                        srcRect.Y = tileRectangle.Location.Y;
                        srcRect.Width = tileRectangle.Size.Width;
                        srcRect.Height = tileRectangle.Size.Height;

                        System.Drawing.Bitmap tileBitmap = tileSheetBitmap.Clone(
                             srcRect, tileSheetBitmap.PixelFormat);

                        tileBitmaps[tileIndex] = tileBitmap;
                    }

                    m_bitmapCache[tileSheet] = tileBitmaps;
                }
            }
            catch (Exception innerException)
            {
                Exception exception = new Exception(
                    "Unable to load tile sheet '" + tileSheet.Id + "' with image source '" + tileSheet.ImageSource + "'",
                    innerException);
                throw exception;
            }
        }

        public void Clear(TileSheet tileSheet)
        {
            m_bitmapCache.Remove(tileSheet);
        }

        public System.Drawing.Bitmap GetTileBitmap(TileSheet tileSheet, int tileIndex)
        {
            return m_bitmapCache[tileSheet][tileIndex];
        }
    }
}
