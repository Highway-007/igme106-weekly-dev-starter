using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace PE_MG_Buttons
{
    public class Game1 : Game
    {
        // Fields created by the MG template
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The list of buttons and setup for random bg color
        private SpriteFont font;
        private List<Button> buttons = new List<Button>();
        private Color bgColor = Color.White;
        private Random rng = new Random();

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: ADD Your new fields here!
        //   COMPLETE
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private int leftClicks;
        private int rightClicks;
        private int stacyNum;
        private int currStacy;
        private List<Texture2D> stacyImages;
        private Rectangle stacyLoc;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            leftClicks = 0;
            rightClicks = 0;   
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("buttonFont");

            //Load list of stacy images
            stacyImages = new List<Texture2D> { Content.Load<Texture2D>("stacyHead0"), Content.Load<Texture2D>("stacyHead1"), Content.Load<Texture2D>("stacyHead2") };
            currStacy = 0;

            // Create a few 100x200 buttons down the left side
            buttons.Add(new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 40, 200, 100),
                    "Random Color",
                    font,
                    Color.LightBlue));
            buttons[0].OnLeftButtonClick += this.RandomizeBackground;
            buttons[0].OnRightButtonClick += this.RandomizeBackground;

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add your additional button setup code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Button to Spawn an image of Stacy
            buttons.Add(new Button(
                _graphics.GraphicsDevice,
                new Rectangle(10, 160, 200, 100),
                "Spawn/Replace Stacy",
                font,
                Color.Aquamarine));
            buttons[1].OnLeftButtonClick += this.SpawnStacy;
            buttons[1].OnRightButtonClick += this.SpawnStacy;

            buttons.Add(new Button(
                _graphics.GraphicsDevice,
                new Rectangle(10, 280, 200, 100),
                "Change Stacy's Look",
                font,
                Color.Lavender));
            buttons[2].OnLeftButtonClick += this.ChangeStacy;
            buttons[2].OnRightButtonClick += this.ChangeStacy;
        }

        // There is no need to add anything to Game1's Update method!
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Button b in buttons)
            {
                b.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add your additional drawing code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


            // Draw the buttons last.
            foreach (Button b in buttons)
            {
                b.Draw(_spriteBatch);
            }

            if (!stacyLoc.IsEmpty)
            {
                _spriteBatch.Draw(stacyImages[currStacy],
                    stacyLoc,
                    Color.White);

                _spriteBatch.DrawString(font,
                    $"Stacy #{stacyNum} is sourced from the Mewgenics Wikipedia Page",
                    new Vector2(25, _graphics.PreferredBackBufferHeight - 50),
                    Color.Black);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // #################################################################################
        // Button click handlers!
        // #################################################################################

        /// <summary>
        /// LEAVE THIS ONE ALONE
        /// Randomizes the saved background color
        /// </summary>
        public void RandomizeBackground()
        {
            bgColor = new Color(rng.Next(0, 200), rng.Next(0, 200), rng.Next(0, 200));
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: Add your new button click handlers here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Spawns Stacy at a random on screen location
        /// </summary>
        public void SpawnStacy()
        {
            stacyLoc = new Rectangle(
                (int)(_graphics.PreferredBackBufferWidth * 0.5 - (stacyImages[currStacy].Width * .25) + rng.Next(0, _graphics.PreferredBackBufferWidth /3)),
                (int)(_graphics.PreferredBackBufferHeight * 0.5 - (stacyImages[currStacy].Height * .25) + rng.Next(0, _graphics.PreferredBackBufferHeight /2) - 150),
                (int)(stacyImages[0].Width * 0.33),
                (int)(stacyImages[0].Height * 0.33));
            stacyNum = rng.Next(1000, 100000);
        }

        /// <summary>
        /// Cycles the stacy image on screen
        /// </summary>
        public void ChangeStacy()
        {
            currStacy++;

            if(currStacy >= stacyImages.Count)
            {
                currStacy = 0;
            }
        }
    }
}
