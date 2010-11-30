using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using xTile;
using xTile.Display;
using xTile.Dimensions;
using xTile.Tiles;

namespace Demo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class DemoGame : Microsoft.Xna.Framework.Game
    {
        #region Public Methods

        /// <summary>
        /// Constructs the game class
        /// </summary>
        public DemoGame()
        {
            m_graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // set window title (PC version, windowed mode only)
#if WINDOWS
            Window.Title = "xTile XNA Demo Application (Windows)";
#elif XBOX
            Window.Title = "xTile XNA Demo Application (XBOX 360)";
#elif ZUNE
            Window.Title = "xTile XNA Demo Application (Zune)";
#elif WINDOWS_PHONE
            Window.Title = "xTile XNA Demo Application (Windows Phone)";
#endif

            // set map viewport to match window size
            m_viewPort = new xTile.Dimensions.Rectangle(
                new xTile.Dimensions.Size(
                    GraphicsDevice.PresentationParameters.BackBufferWidth,
                    GraphicsDevice.PresentationParameters.BackBufferHeight));

            // set help panel size
#if WINDOWS
            m_panelRectangle = new Microsoft.Xna.Framework.Rectangle(
                0, m_viewPort.Height - 80, m_viewPort.Width, 80);
#else
            m_panelRectangle = new Microsoft.Xna.Framework.Rectangle(
                0, m_viewPort.Height - 56, m_viewPort.Width, 56);
#endif

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            m_xnaDisplayDevice = new XnaDisplayDevice(Content, GraphicsDevice);

            // load font for help text
            m_spriteFontDemo = Content.Load<SpriteFont>("Fonts/Demo");

            // load map from content pipeline and initialise it
            m_map = Content.Load<Map>("Maps\\Map01");
            m_map.LoadTileSheets(m_xnaDisplayDevice);

            // prepare translucent panel for help text
            m_texturePanel = new Texture2D(GraphicsDevice, 1, 1);
            m_texturePanel.SetData<Color>(new Color[] { new Color(Color.Black, 128) });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // dispose map resoures
            m_map.DisposeTileSheets(m_xnaDisplayDevice);
            m_map = null;

            // dispose other objects
            m_spriteFontDemo = null;
            m_texturePanel = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // get keyboard and gamepad states
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            GamePadButtons gamePadButtons = gamePadState.Buttons;
            Vector2 leftThumbStick = gamePadState.ThumbSticks.Left;
            KeyboardState keyboardState = Keyboard.GetState(PlayerIndex.One);

            // check for exit
            if (gamePadButtons.Back == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

#if WINDOWS
            // toggle window / fullscreen mode
            if (gamePadButtons.Y == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Space))
                m_graphicsDeviceManager.ToggleFullScreen();
#endif

            // movement via keyboard
            if (keyboardState.IsKeyDown(Keys.Left))
                m_viewPort.Location.X -= 2;

            if (keyboardState.IsKeyDown(Keys.Right))
                m_viewPort.Location.X += 2;

            if (keyboardState.IsKeyDown(Keys.Up))
                m_viewPort.Location.Y -= 2;

            if (keyboardState.IsKeyDown(Keys.Down))
                m_viewPort.Location.Y += 2;

            // stick movement
            m_viewPort.Location.X += (int)(leftThumbStick.X * 4.0f);
            m_viewPort.Location.Y += (int)(leftThumbStick.Y * 4.0f);

            // limit viewport to map
            m_viewPort.Location.X = Math.Max(0, m_viewPort.X);
            m_viewPort.Location.Y = Math.Max(0, m_viewPort.Y);
            m_viewPort.Location.X = Math.Min(
                m_map.DisplayWidth - m_viewPort.Width, m_viewPort.X);
            m_viewPort.Location.Y = Math.Min(
                m_map.DisplayHeight - m_viewPort.Height, m_viewPort.Y);

            // update map for animations etc.
            m_map.Update(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // draw map
            m_map.Draw(m_xnaDisplayDevice, m_viewPort);

            // draw help panel
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_texturePanel, m_panelRectangle, Color.White);
#if WINDOWS
            WriteText("Arrow keys / left gamepad thumbstick - navigate the map", 16, m_viewPort.Height - 72);
            WriteText("Esc key    / gamepad Back button     - exit the demo", 16, m_viewPort.Height - 48);
            WriteText("Space key  / gamepad Y button        - window / fullscreen toggle", 16, m_viewPort.Height - 24);
#else
            WriteText("Arrow keys / left gamepad thumbstick - navigate the map", 16, m_viewPort.Height - 48);
            WriteText("Esc key    / gamepad Back button     - exit the demo", 16, m_viewPort.Height - 24);
#endif
            m_spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Writes shadowed text at the given position
        /// </summary>
        /// <param name="text">Text to write</param>
        /// <param name="positionX">Horizontal coordinate</param>
        /// <param name="positionY">Vertical coordinate</param>
        private void WriteText(string text, int positionX, int positionY)
        {
            Vector2 textPosition = new Vector2(positionX + 1, positionY + 1);
            m_spriteBatch.DrawString(m_spriteFontDemo, text, textPosition, Color.Black);
            textPosition -= new Vector2(1, 1);
            m_spriteBatch.DrawString(m_spriteFontDemo, text, textPosition, Color.White);
        }

        #endregion

        #region Private Variables

        // XNA graphics device manager and sprite batch
        private GraphicsDeviceManager m_graphicsDeviceManager;
        private SpriteBatch m_spriteBatch;

        // XNA implementation of the IDisplayDevice interface
        private XnaDisplayDevice m_xnaDisplayDevice;

        // map and viewport
        private Map m_map;
        private xTile.Dimensions.Rectangle m_viewPort;

        // help panel objects
        private Microsoft.Xna.Framework.Rectangle m_panelRectangle;
        private Texture2D m_texturePanel;
        private SpriteFont m_spriteFontDemo;

        #endregion
    }
}
