using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Tiles;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XTile.Display
{
    class XnaDisplayDevice : IDisplayDevice
    {
        public XnaDisplayDevice(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            m_contentManager = contentManager;
            m_graphicsDevice = graphicsDevice;
            m_spriteBatchAlpha = new SpriteBatch(graphicsDevice);
            m_spriteBatchAdditive = new SpriteBatch(graphicsDevice);
            m_tileSheetTextures = new Dictionary<TileSheet, Texture2D>();
            m_destinationRectangle = new Microsoft.Xna.Framework.Rectangle();
        }

        public void LoadTileSheet(TileSheet tileSheet)
        {
            Texture2D texture2D = m_contentManager.Load<Texture2D>(tileSheet.ImageSource);
            m_tileSheetTextures[tileSheet] = texture2D;
        }

        public void DisposeTileSheet(TileSheet tileSheet)
        {
            m_tileSheetTextures.Remove(tileSheet);
        }

        public void BeginScene()
        {
            m_spriteBatchAlpha.Begin(SpriteBlendMode.AlphaBlend);
            m_spriteBatchAdditive.Begin(SpriteBlendMode.Additive);
        }

        public void SetClippingRegion(XTile.Dimensions.Rectangle clippingRegion)
        {
            m_graphicsDevice.ScissorRectangle = new Microsoft.Xna.Framework.Rectangle(
                clippingRegion.Location.X, clippingRegion.Location.Y,
                clippingRegion.Size.Width, clippingRegion.Size.Height);

            #if ZUNE
                // do nothing - RenderState not defined for Zune
            #else
                m_graphicsDevice.RenderState.ScissorTestEnable = true;
            #endif
        }

        public void DrawTile(Tile tile, Location location)
        {
            if (tile == null)
                return;

            SpriteBatch spriteBatch = tile.BlendMode == BlendMode.Alpha
                ? m_spriteBatchAlpha : m_spriteBatchAdditive;

            Texture2D texture2D = m_tileSheetTextures[tile.TileSheet];

            Size tileSize = tile.TileSheet.TileSize;
            m_destinationRectangle.X = location.X;
            m_destinationRectangle.Y = location.Y;
            m_destinationRectangle.Width = tileSize.Width;
            m_destinationRectangle.Height = tileSize.Height;

            spriteBatch.Draw(texture2D, m_destinationRectangle, Color.White);
        }

        public void EndScene()
        {
            m_spriteBatchAdditive.End();
            m_spriteBatchAlpha.End();
        }

        private ContentManager m_contentManager;
        private GraphicsDevice m_graphicsDevice;
        private SpriteBatch m_spriteBatchAlpha;
        private SpriteBatch m_spriteBatchAdditive;
        private Dictionary<TileSheet, Texture2D> m_tileSheetTextures;
        private Microsoft.Xna.Framework.Rectangle m_destinationRectangle;
    }
}
