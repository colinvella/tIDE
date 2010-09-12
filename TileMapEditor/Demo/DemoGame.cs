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
        SpriteFont m_spriteFontDemo;

        Microsoft.Xna.Framework.Rectangle m_panelRectangle;
        Texture2D m_texturePanel;

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

            m_viewPort = new xTile.Dimensions.Rectangle(
                new xTile.Dimensions.Size(
                    GraphicsDevice.PresentationParameters.BackBufferWidth,
                    GraphicsDevice.PresentationParameters.BackBufferHeight));

            m_panelRectangle = new Microsoft.Xna.Framework.Rectangle(
                0, m_viewPort.Height - 56, m_viewPort.Width, 56);

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
            m_spriteFontDemo = Content.Load<SpriteFont>("Fonts/Demo");

            m_map = Content.Load<Map>("Maps\\Map01");
            foreach (TileSheet tileSheet in m_map.TileSheets)
                m_xnaDisplayDevice.LoadTileSheet(tileSheet);

            // prepare translucent panel for text
            m_texturePanel = new Texture2D(GraphicsDevice, 1, 1);
            m_texturePanel.SetData<Color>(new Color[] { new Color(Color.Black, 128) });
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
            m_spriteFontDemo = null;
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

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_texturePanel, m_panelRectangle, Color.White);
            WriteText("Use the arrow keys or left gamepad thumbstick to navigate the map", 16, m_viewPort.Height - 48);
            WriteText("Press the Esc key or the gamepad Back button to exit the demo", 16, m_viewPort.Height - 24);
            m_spriteBatch.End();

            base.Draw(gameTime);
        }

        private void WriteText(string text, int positionX, int positionY)
        {
            Vector2 textPosition = new Vector2(positionX + 1, positionY + 1);
            m_spriteBatch.DrawString(m_spriteFontDemo, text, textPosition, Color.Black);
            textPosition -= new Vector2(1, 1);
            m_spriteBatch.DrawString(m_spriteFontDemo, text, textPosition, Color.White);
        }
    }
}
