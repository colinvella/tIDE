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
        GraphicsDeviceManager m_graphicsDeviceManager;
        SpriteBatch m_spriteBatch;

        XnaDisplayDevice m_xnaDisplayDevice;
        Map m_map;
        xTile.Dimensions.Rectangle m_viewPort;

        public DemoGame()
        {
            m_graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "xTile XNA Demo Application";

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

            // TODO: use this.Content to load your game content here
            m_map = Content.Load<Map>("Maps\\Map01");
            foreach (TileSheet tileSheet in m_map.TileSheets)
                m_xnaDisplayDevice.LoadTileSheet(tileSheet);

            m_viewPort = new xTile.Dimensions.Rectangle(
                new xTile.Dimensions.Size(
                    GraphicsDevice.PresentationParameters.BackBufferWidth,
                    GraphicsDevice.PresentationParameters.BackBufferHeight));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            foreach (TileSheet tileSheet in m_map.TileSheets)
                m_xnaDisplayDevice.DisposeTileSheet(tileSheet);

            m_map = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            GamePadButtons gamePadButtons = gamePadState.Buttons;
            Vector2 leftThumbStick = gamePadState.ThumbSticks.Left;

            KeyboardState keyboardState = Keyboard.GetState(PlayerIndex.One);

            // check for exit
            if (gamePadButtons.Back == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

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
            m_viewPort.Location.X = Math.Max(0, m_viewPort.Location.X);
            m_viewPort.Location.Y = Math.Max(0, m_viewPort.Location.Y);
            m_viewPort.Location.X = Math.Min(m_map.DisplaySize.Width - m_viewPort.Width, m_viewPort.Location.X);
            m_viewPort.Location.Y = Math.Min(m_map.DisplaySize.Height - m_viewPort.Height, m_viewPort.Location.Y);

            m_map.Update(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            m_map.Draw(m_xnaDisplayDevice, m_viewPort);

            base.Draw(gameTime);
        }
    }
}
