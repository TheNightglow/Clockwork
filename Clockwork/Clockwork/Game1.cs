using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;


namespace Clockwork
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// hi
    public class Game1 : Basics
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Texture2D background;
        public Vector2 backV = Vector2.Zero;
        public Vector2 frontV = Vector2.Zero;
        Decal backD;
        Decal backD2;
        PlatformX p;
        public Texture2D foreground;
        //     Bitmap blueprint = new Bitmap(@"C:\Users\Marcu\Desktop\Clockwork\Clockwork\Clockwork\Clockwork\bin\Blueprint.png");




        //Class Member
        Player player;
        public Vector2 start = new Vector2(20, 700);
        public Vector2 fore = new Vector2(0, 0);



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Window SIze
            graphics.PreferredBackBufferWidth = MapsizeX; 
            graphics.PreferredBackBufferHeight = MapsizeY;  
            graphics.ApplyChanges();
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
            background = this.Content.Load<Texture2D>("DoubleMap");
            foreground = this.Content.Load<Texture2D>("front");



            player = new Player(Content.Load<Texture2D>("player"), start);
            p = new PlatformX(Content.Load<Texture2D>("Platform"), new Vector2(100,355));
            //backD = new Decal(background, Vector2.Zero);
            backD = new Decal(background, new Vector2(0, 0 - MapsizeY));
            backD2 = new Decal(background, new Vector2(0,0-MapsizeY));




            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
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


            if (player.position.Y >= 400)
            {
                player.Update(backD, p);
            }
            else
            {
                player.Update(backD, p);
                backD.Update(player);
                backD2.Update(player);
            }

            p.Update(backD, player);



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(background, backV);
            backD2.Draw(spriteBatch);
            backD.Draw(spriteBatch);
            p.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.Draw(foreground, frontV);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
