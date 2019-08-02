using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ConsoleApp1;

namespace LevelDesignerGui
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    class Game1 : Game
    {
        CA consoleApp = new CA();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D gameBackround;
        SpriteFont font;
        int[,] map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;

        }
        public void DrawGrid(int[,] gameMap, SpriteBatch spriteBatch, SpriteFont f)
        {
            for (int x = 0; x < gameMap.GetLength(1); x++)
            {
                for (int y = 0; y < gameMap.GetLength(0); y++)
                {
                    spriteBatch.DrawString(f, y + " / " + x, new Vector2(x * 64, y * 64), Color.White);
                }

            }

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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {


            this.IsMouseVisible = true;
            gameBackround = Content.Load<Texture2D>("level_01_A");
            // Create a new SpriteBatch, which can be used to draw textures.
            //   for(int i =0;i<map1.Height:i++)
            //     for (int j=0;j<map1.Width;j++)

            Console.WriteLine(gameBackround.Width / 64);
            Console.WriteLine(gameBackround.Height / 64);
            map = new int[gameBackround.Width / 64, gameBackround.Height / 64];

            font = Content.Load<SpriteFont>("Fonts/Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                int x = Convert.ToInt32(ms.X) / 16;
                int y = Convert.ToInt32(ms.Y) / 16 + 1;
                //Console.WriteLine(x);
                //Console.WriteLine(y);
            }

            var mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                var xIndex = mouseState.X / 64;
                var yIndex = mouseState.Y / 64;

                if (xIndex >= 0 && xIndex < map.GetLength(0) && yIndex >= 0 && yIndex < map.GetLength(1))
                {
                    map[yIndex, xIndex] = 1;
                }
            }
            // TODO: Add your update logic here
            if (mouseState.RightButton == ButtonState.Pressed)
                consoleApp.run(map);
            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // TODO: Add your drawing code here

            spriteBatch.Draw(gameBackround, new Rectangle(0, -700, 3840, 1984), Color.White);
            DrawGrid(map, spriteBatch, font);

            base.Draw(gameTime);
            spriteBatch.End();
        }


    }

}