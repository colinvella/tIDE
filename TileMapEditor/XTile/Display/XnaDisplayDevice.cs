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

            m_tilePosition = new Vector2();
            m_sourceRectangle = new Microsoft.Xna.Framework.Rectangle();
            m_modulationColour = Color.White;
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

            XTile.Dimensions.Rectangle sourceRectangle
                = tile.TileSheet.GetTileImageBounds(tile.TileIndex);

            Texture2D texture2D = m_tileSheetTextures[tile.TileSheet];

            m_tilePosition.X = location.X;
            m_tilePosition.Y = location.Y;

            m_sourceRectangle.X = sourceRectangle.X;
            m_sourceRectangle.Y = sourceRectangle.Y;
            m_sourceRectangle.Width = sourceRectangle.Width;
            m_sourceRectangle.Height = sourceRectangle.Height;

            spriteBatch.Draw(texture2D, m_tilePosition, m_sourceRectangle, m_modulationColour);
        }

        public void EndScene()
        {
            m_spriteBatchAdditive.End();
            m_spriteBatchAlpha.End();
        }

        public Color ModulationColour
        {
            get { return m_modulationColour; }
            set { m_modulationColour = value; }
        }

        private ContentManager m_contentManager;
        private GraphicsDevice m_graphicsDevice;
        private SpriteBatch m_spriteBatchAlpha;
        private SpriteBatch m_spriteBatchAdditive;
        private Dictionary<TileSheet, Texture2D> m_tileSheetTextures;
        private Microsoft.Xna.Framework.Vector2 m_tilePosition;
        private Microsoft.Xna.Framework.Rectangle m_sourceRectangle;
        private Color m_modulationColour;
    }
}
