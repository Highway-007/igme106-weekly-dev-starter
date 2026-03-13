using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata.Ecma335;

namespace PE___Monogame_Drawing
{
    public class Game1 : Game
    {
        private const float CatScale = .1f;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D catImg;
        private SpriteFont bounceFont;
        private SpriteFont labelFont;

        private Rectangle catLoc;
        private Rectangle catSmall;
        private Vector2 movement;
        private KeyboardState previousState;
        private KeyboardState currState;
        private MouseState mouseState;
        private MouseState prevMouse;

        private int catSpeed;
        private int bounces;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;

            //Set Window to desired width/height
            _graphics.PreferredBackBufferWidth = 600;  
            _graphics.PreferredBackBufferHeight = 600;  
            _graphics.ApplyChanges();
            movement.X = 1;
            movement.Y = 1;
            catSpeed = 2;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Fonts
            bounceFont = Content.Load<SpriteFont>("BounceFont");
            labelFont = Content.Load<SpriteFont>("LabelFont");

            //Images
            catImg = Content.Load<Texture2D>("cat");
            catLoc = new Rectangle(25, 25, (int)(CatScale * catImg.Width), (int)(CatScale * catImg.Height));
            catSmall = new Rectangle(
                (int)(_graphics.PreferredBackBufferWidth * 0.5 - (catLoc.Width * 0.25)),
                (int)(_graphics.PreferredBackBufferHeight * 0.5 - (catLoc.Height * 0.25)),
                (int)(catLoc.Width * 0.5), 
                (int)(catLoc.Height * 0.5));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (catLoc.Right >= _graphics.PreferredBackBufferWidth)
            {
                movement.X = -1;
                bounces++;
            }

            if (catLoc.Left <= 0)
            {
                movement.X = 1;
                bounces++;
            }

            if (catLoc.Bottom >= _graphics.PreferredBackBufferHeight)
            {
                movement.Y = -1;
                bounces++;
            }

            if (catLoc.Bottom - catLoc.Height <= 0)
            {
                movement.Y = 1;
                bounces++;
            }

            catLoc.X += (int)movement.X;
            catLoc.Y += (int)movement.Y;

            ProcessInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleTurquoise);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
          
            //Draw the DVD cat and player Cat
            _spriteBatch.Draw(catImg, catLoc, Color.White);
            _spriteBatch.Draw(catImg, catSmall, Color.Chartreuse);

            //Draw Text
            _spriteBatch.DrawString(bounceFont, 
                $"{bounces}", 
                new Vector2(_graphics.PreferredBackBufferWidth * 0.5f, _graphics.PreferredBackBufferHeight * 0.5f), 
                Color.Black);
            _spriteBatch.DrawString(labelFont, 
                $"Evan Kreg     Loc: {catSmall.X}, {catSmall.Y}     Speed: {catSpeed}", 
                new Vector2(30, 30), 
                Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessInput()
        {
            currState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            //Cat Movment
            if (currState.IsKeyDown(Keys.W))
            {
                catSmall.Y -= catSpeed;
            }

            if (currState.IsKeyDown(Keys.S))
            {
                catSmall.Y += catSpeed;
            }

            if (currState.IsKeyDown(Keys.D))
            {
                catSmall.X += catSpeed;
            }

            if (currState.IsKeyDown(Keys.A))
            {
                catSmall.X -= catSpeed;
            }

            //increment the speed 
            if (previousState.IsKeyDown(Keys.Space) && currState.IsKeyUp(Keys.Space))
            {
                catSpeed += 2;
            }

            //Reset button
            if(prevMouse.RightButton == ButtonState.Pressed && mouseState.RightButton != ButtonState.Pressed)
            {
                bounces = 0;
                catLoc.X = 25;
                catLoc.Y = 25;
                movement.X = 1;
                movement.Y = 1;

                catSmall.X = (int)(_graphics.PreferredBackBufferWidth * 0.5 - (catLoc.Width * 0.25));
                catSmall.Y = (int)(_graphics.PreferredBackBufferHeight * 0.5 - (catLoc.Height * 0.25));
                catSpeed = 2;
            }

            previousState = currState;
            prevMouse = mouseState;
        }
    }
}
