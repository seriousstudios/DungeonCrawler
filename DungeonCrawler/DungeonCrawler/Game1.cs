using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace DungeonCrawler
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D smileyImage;
        Vector2 smileyPosition;

        Thread mainThread;
        DungeonCrawlerMain.DungeonCrawlerMain main;
        MonoResponder responder;

        public Color BackgroundColour { get; set; } = Color.SteelBlue;

        // TODO: Move to external class (Constants) and call from there
        string gameWindowTitle = "Dungeon Crawler | #SeriousStudios | Development Build";

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // Setup the basic window function of the game
            Window.Title = gameWindowTitle;
            Window.AllowUserResizing = false;

            // Set the starting position of the smileyImage
            //smileyPosition = new Vector2(0.0f, 0.0f);
            smileyPosition = Vector2.Zero;


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loads the Smiley.png into the smileImage variable
            smileyImage = Content.Load<Texture2D>("Smiley");

            // Main thread
            main = new DungeonCrawlerMain.DungeonCrawlerMain();
            responder = new MonoResponder(this);
            mainThread = new Thread(new ThreadStart(MainThreadStart));
            // Start the thread
            mainThread.Start();
        }

        void MainThreadStart()
        {
            main.Run(responder);
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

            // Input : move to outside class (InputHandler) and call from there
            KeyboardState keyState = Keyboard.GetState();
            float moveSpeed = 100.0f;
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveAmount = moveSpeed * time;

            if (keyState.IsKeyDown(Keys.Down))
            {
                //smileyPosition.Y = smileyPosition.Y + 100f * (float) gameTime.ElapsedGameTime.TotalSeconds;
                smileyPosition.Y += moveAmount;
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                //smileyPosition.Y = smileyPosition.Y - 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                smileyPosition.Y -= moveAmount;
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                //smileyPosition.X = smileyPosition.X - 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                smileyPosition.X -= moveAmount;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                //smileyPosition.X = smileyPosition.X + 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                smileyPosition.X += moveAmount;
            }

            // The game loop

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColour);

            // Draw the smileyImage to the screen
            spriteBatch.Begin();
                spriteBatch.Draw(smileyImage, smileyPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
