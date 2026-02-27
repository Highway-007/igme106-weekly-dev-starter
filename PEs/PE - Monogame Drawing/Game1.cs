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
        private Rectangle catLoc;
        private Rectangle catSmall;
        private Vector2 movement;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            //Set Window to desired width/height
            _graphics.PreferredBackBufferWidth = 600;  
            _graphics.PreferredBackBufferHeight = 600;  
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            switch (catLoc)
            {
                //case _graphics.PreferredBackBufferWidth:
                 //   break;

                default:
                    movement.X = 1;
                    movement.Y = 1;
                    break;
            }
            catLoc.X += (int)movement.X;
            catLoc.Y += (int)movement.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleTurquoise);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
          
            _spriteBatch.Draw(catImg, catLoc, Color.White);
            _spriteBatch.Draw(catImg, catSmall, Color.Chartreuse);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
