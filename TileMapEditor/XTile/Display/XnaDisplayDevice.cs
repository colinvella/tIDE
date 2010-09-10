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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace xTile.Display
{
    /// <summary>
    /// XNA implementation of the display device. In this implementation,
    /// the tile sheet image sources are loaded from the content pipeline
    /// and alpha and additive blend modes are supported via dedicated
    /// sprite batch instances
    /// </summary>
    class XnaDisplayDevice : IDisplayDevice
    {
        #region Public Properties

        /// <summary>
        /// Colour modulation property. This is set to White by default
        /// 
        /// NOTE: This property is specific to this implementation
        /// </summary>
        public Color ModulationColour
        {
            get { return m_modulationColour; }
            set { m_modulationColour = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs an XNA displat device using the given content manager and
        /// XNA graphics device
        /// </summary>
        /// <param name="contentManager">Content manager to use for resource access</param>
        /// <param name="graphicsDevice">Underlying XNA graphics device</param>
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

        /// <summary>
        /// Loads the given tile sheet. The image source is loaded from the
        /// content pipeline by stripping any extension from the image source
        /// and using the resulting path into the content pipeline
        /// </summary>
        /// <param name="tileSheet">Tile sheet to load</param>
        public void LoadTileSheet(TileSheet tileSheet)
        {
            Texture2D texture2D = m_contentManager.Load<Texture2D>(tileSheet.ImageSource);
            m_tileSheetTextures[tileSheet] = texture2D;
        }

        /// <summary>
        /// Frees the tile sheet resources
        /// </summary>
        /// <param name="tileSheet">Tile sheet to dispose</param>
        public void DisposeTileSheet(TileSheet tileSheet)
        {
            m_tileSheetTextures.Remove(tileSheet);
        }

        /// <summary>
        /// Prepares the device for rendering
        /// </summary>
        public void BeginScene()
        {
            m_spriteBatchAlpha.Begin(SpriteBlendMode.AlphaBlend);
            m_spriteBatchAdditive.Begin(SpriteBlendMode.Additive);
        }

        /// <summary>
        /// Sets the clipping region.
        /// 
        /// NOTE: This function is not supported on the Zune platform.
        /// </summary>
        /// <param name="clippingRegion">Clipping region to apply</param>
        public void SetClippingRegion(xTile.Dimensions.Rectangle clippingRegion)
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

        /// <summary>
        /// Draws the givne tile at the given location
        /// </summary>
        /// <param name="tile">Tile to draw</param>
        /// <param name="location">Drawing location</param>
        public void DrawTile(Tile tile, Location location)
        {
            if (tile == null)
                return;

            SpriteBatch spriteBatch = tile.BlendMode == BlendMode.Alpha
                ? m_spriteBatchAlpha : m_spriteBatchAdditive;

            xTile.Dimensions.Rectangle sourceRectangle
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

        /// <summary>
        /// Terminates rendering of the current frame and commits drawing instructions
        /// to the underlying XNA graphics pipeline
        /// </summary>
        public void EndScene()
        {
            m_spriteBatchAdditive.End();
            m_spriteBatchAlpha.End();
        }

        #endregion

        #region Private Variables

        private ContentManager m_contentManager;
        private GraphicsDevice m_graphicsDevice;
        private SpriteBatch m_spriteBatchAlpha;
        private SpriteBatch m_spriteBatchAdditive;
        private Dictionary<TileSheet, Texture2D> m_tileSheetTextures;
        private Microsoft.Xna.Framework.Vector2 m_tilePosition;
        private Microsoft.Xna.Framework.Rectangle m_sourceRectangle;
        private Color m_modulationColour;

        #endregion
    }
}
