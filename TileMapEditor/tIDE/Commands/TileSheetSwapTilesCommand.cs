using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

namespace tIDE.Commands
{
    class TileSheetSwapTilesCommand : Command
    {
        private TileSheet m_tileSheet;
        private int m_tileIndex1;
        private int m_tileIndex2;

        private Bitmap LoadUnlockedBitmap(string filename)
        {
            Bitmap unlockedBitmap = null;
            using (Bitmap lockedBitmap = new Bitmap(filename))
            {
                unlockedBitmap = new Bitmap(lockedBitmap.Width, lockedBitmap.Height, lockedBitmap.PixelFormat);
                using (Graphics graphics = Graphics.FromImage(unlockedBitmap))
                {
                    graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    graphics.DrawImageUnscaled(lockedBitmap, 0, 0);
                }
            }
            return unlockedBitmap;
        }

        public TileSheetSwapTilesCommand(TileSheet tileSheet, int tileIndex1, int tileIndex2)
        {
            m_tileSheet = tileSheet;
            m_tileIndex1 = tileIndex1;
            m_tileIndex2 = tileIndex2;

            m_description = "Swap tile " + m_tileSheet.Id + ":" + m_tileIndex1 + " with tile " + m_tileSheet.Id + ":" + m_tileIndex2;
        }

        public override void Do()
        {
            Bitmap imageSourceBitmap = LoadUnlockedBitmap(m_tileSheet.ImageSource);

            xTile.Dimensions.Rectangle rectangle1 = m_tileSheet.GetTileImageBounds(m_tileIndex1);
            xTile.Dimensions.Rectangle rectangle2 = m_tileSheet.GetTileImageBounds(m_tileIndex2);

            System.Drawing.Rectangle source1 = new System.Drawing.Rectangle(rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height);
            System.Drawing.Rectangle source2 = new System.Drawing.Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
            Bitmap tileBitmap1 = imageSourceBitmap.Clone(source1, imageSourceBitmap.PixelFormat);
            Bitmap tileBitmap2 = imageSourceBitmap.Clone(source2, imageSourceBitmap.PixelFormat);

            Graphics graphics = Graphics.FromImage(imageSourceBitmap);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            graphics.SetClip(source1);
            graphics.Clear(Color.FromArgb(0, 0, 0, 0));
            graphics.DrawImageUnscaled(tileBitmap2, source1.Location);

            graphics.SetClip(source2);
            graphics.Clear(Color.FromArgb(0, 0, 0, 0));
            graphics.DrawImageUnscaled(tileBitmap1, source2.Location);

            imageSourceBitmap.Save(m_tileSheet.ImageSource);

            TileImageCache.Instance.Refresh(m_tileSheet);

            Map map = m_tileSheet.Map;

            foreach (Layer layer in map.Layers)
            {
                Location tileLocation = new Location();
                for (tileLocation.Y = 0; tileLocation.Y < layer.LayerHeight; tileLocation.Y++)
                {
                    for (tileLocation.X = 0; tileLocation.X < layer.LayerWidth; tileLocation.X++)
                    {
                        Tile tile = layer.Tiles[tileLocation];
                        if (tile == null)
                            continue;
                        if (tile.TileSheet != m_tileSheet)
                            continue;

                        if (tile is StaticTile)
                        {
                            if (tile.TileIndex == m_tileIndex1)
                                tile.TileIndex = m_tileIndex2;
                            else if (tile.TileIndex == m_tileIndex2)
                                tile.TileIndex = m_tileIndex1;
                        }
                        else if (tile is AnimatedTile)
                        {
                            AnimatedTile animatedTile = (AnimatedTile)tile;
                            foreach (StaticTile tileFrame in animatedTile.TileFrames)
                            {
                                if (tileFrame.TileIndex == m_tileIndex1)
                                    tileFrame.TileIndex = m_tileIndex2;
                                else if (tileFrame.TileIndex == m_tileIndex2)
                                    tileFrame.TileIndex = m_tileIndex1;
                            }
                        }
                    }
                }
            }
        }

        public override void Undo()
        {
            Do();
        }
    }
}
