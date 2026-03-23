using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


// ****************************************************************************
// *** Do not modify anywhere except where marked with TODO comments! ***
// ****************************************************************************

// TODO: Assignment summary
// In addition to /// class & method headers, every assignment should have a
// header like this in the primary file (Game1 for MG projects, Program.cs
// for console apps).
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Evan Kreg
// 3/23/26
// PE Write-up: https://docs.google.com/document/d/1TzHh7sb5lrnJOO7QyeJhEsM2koJzPTDvWSzKKCAjrEI/edit?usp=sharing
// Notes: (Release notes, things to remember, etc.)
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
namespace PE_CollisionDetection
{
    /// <summary>
    /// Used for switching between Circle and Square mode in the Collisions PE
    /// </summary>
    public enum SimulationState
    {
        Instructions,
        Circle,
        Square
    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Fields for the Collision PE
        // Random object for use throughout class
        private Random rng;

        // Textures for Squares and Circles
        private Texture2D squareTexture;
        private Texture2D circleTexture;

        // Lists of all Squares and Circles
        private List<SquareEntity> squareList;
        private List<CircleEntity> circleList;

        // Player-controlled Square and Circle
        private SquareEntity playerSquare;
        private CircleEntity playerCircle;

        // Text positioning
        private SpriteFont arial20;
        private Vector2 textPosition;
        private Vector2 instructionPosition;

        // Window size information
        private int windowWidth;
        private int windowHeight;

        // Keyboard State for first-key-pressed
        private KeyboardState previousKBState;

        // State for the FSM
        private SimulationState currentState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
        protected override void Initialize()
        {
            // Get window size information
            windowWidth = GraphicsDevice.Viewport.Width;
            windowHeight = GraphicsDevice.Viewport.Height;

            // Start the game in Square mode
            currentState = SimulationState.Instructions;

            // Instantiate Random for use throughout game
            rng = new Random();

            // Initialize list of Squares and Circles
            squareList = new List<SquareEntity>();
            circleList = new List<CircleEntity>();

            // Init previous so its not null
            previousKBState = Keyboard.GetState();

            base.Initialize();
        }

        /// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the 2 textures for the game
            squareTexture = Content.Load<Texture2D>("Square");
            circleTexture = Content.Load<Texture2D>("Circle");

            // Get SpriteFont and text positions ready
            arial20 = Content.Load<SpriteFont>("arial20");
            textPosition = new Vector2(20, 400);
            instructionPosition = new Vector2(20, 100);

            // Initialize and position random circles and squares
            for (int i = 0; i < 10; i++)
            {
                squareList.Add(
                    new SquareEntity(
                        squareTexture, 
                        rng.Next(100, windowWidth - 100), 
                        rng.Next(0, windowHeight - 100), 
                        rng.Next(5, 100)));
                circleList.Add(
                    new CircleEntity(
                        circleTexture, 
                        rng.Next(100, windowWidth - 100), 
                        rng.Next(0, windowHeight - 100), 
                        rng.Next(5, 50)));
            }

            // Get player-controlled units ready
            playerSquare = new SquareEntity(squareTexture, 0, 0, 100);
            playerCircle = new CircleEntity(circleTexture, 50, 50, 50);
        }

        /// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Get the current state of the keyboard
            KeyboardState currentKBState = Keyboard.GetState();

            // ****************************************************************
            // TODO: Implement Finite State Machine here!
            // The basic structure is set up for you.
            switch (currentState)
            {
                case SimulationState.Instructions:
                    //Transfer to Square state when pressing 1
                    if (currentKBState.IsKeyUp(Keys.NumPad1) && previousKBState.IsKeyDown(Keys.NumPad1))
                    {
                        currentState = SimulationState.Square;
                    }

                    //Transfer to Circle state when pressing 2
                    if (currentKBState.IsKeyUp(Keys.NumPad2) && previousKBState.IsKeyDown(Keys.NumPad2))
                    {
                        currentState = SimulationState.Circle;
                    }
                    break;

                case SimulationState.Square:
                    //Transfer to Circle state when pressing 2
                    if (currentKBState.IsKeyUp(Keys.NumPad2) && previousKBState.IsKeyDown(Keys.NumPad2))
                    {
                        currentState = SimulationState.Circle;
                    }

                    //Move player left 5 pixels on left arrow press
                    if (currentKBState.IsKeyDown(Keys.Left))
                    {
                        playerSquare.X -= 5;
                    }

                    //Move player right 5 pixels on right arrow press
                    if (currentKBState.IsKeyDown(Keys.Right))
                    {
                        playerSquare.X += 5;
                    }

                    //Move player Down 5 pixels on Down arrow press
                    if (currentKBState.IsKeyDown(Keys.Down))
                    {
                        playerSquare.Y += 5;
                    }

                    //Move player Up 5 pixels on Up arrow press
                    if (currentKBState.IsKeyDown(Keys.Up))
                    {
                        playerSquare.Y -= 5;
                    }
                    break;

                case SimulationState.Circle:
                    //Transfer to Square state when pressing 1
                    if (currentKBState.IsKeyUp(Keys.NumPad1) && previousKBState.IsKeyDown(Keys.NumPad1))
                    {
                        currentState = SimulationState.Square;
                    }

                    //Move player left 5 pixels on left arrow press
                    if (currentKBState.IsKeyDown(Keys.Left))
                    {
                        playerCircle.X -= 5;
                    }

                    //Move player right 5 pixels on right arrow press
                    if (currentKBState.IsKeyDown(Keys.Right))
                    {
                        playerCircle.X += 5;
                    }

                    //Move player Down 5 pixels on Down arrow press
                    if (currentKBState.IsKeyDown(Keys.Down))
                    {
                        playerCircle.Y += 5;
                    }

                    //Move player Up 5 pixels on Up arrow press
                    if (currentKBState.IsKeyDown(Keys.Up))
                    {
                        playerCircle.Y -= 5;
                    }
                    break;
            }
            // ****************************************************************


            // Get the current state of the keyboard
            previousKBState = currentKBState;

            base.Update(gameTime);
        }

        private bool SingleKeyPress(KeyboardState currentKBState, Keys key)
        {
            return currentKBState.IsKeyDown(key) && previousKBState.IsKeyUp(key);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Check the current simulation state to determine what to render
            // to the game window.
            switch (currentState)
            {
                // ----- Instructions state -----------------------------------
                case SimulationState.Instructions:

                    // Draw user instructions to the game window
                    string instructions = 
                        "Begin the simulation:" +
                        "\nPress 1 to see Square mode" +
                        "\nPress 2 to see Circle mode";

                    _spriteBatch.DrawString(
                        arial20, 
                        instructions, 
                        instructionPosition, 
                        Color.White);
                    break;

                // ----- Square shape state -----------------------------------
                case SimulationState.Square:

                    // Draw current mode to the game window
                    _spriteBatch.DrawString(arial20, "Intersects", textPosition, Color.White);

                    // ********************************************************
                    // TODO: Draw intersecting squares in red, otherwise white/blue
                    // Are any of the game objectse intersecting with the player square?
                    // If so, draw both the Player and that intersecting square in red.
                    // Otherwise, draw the player blue and the other objects white.
                    //   COMPLETE
                    // ********************************************************

                    playerSquare.Draw(_spriteBatch,
                    Color.Blue);

                    foreach (SquareEntity s in squareList)
                    {
                        if (playerSquare.Intersects(s))
                        {
                            playerSquare.Draw(_spriteBatch, 
                                Color.Red);

                            s.Draw(_spriteBatch, 
                                Color.Red);
                        }
                        else 
                        {
                            s.Draw(_spriteBatch, 
                                Color.White);
                        }
                    }

                        break;

                // ----- Circle shape state -----------------------------------
                case SimulationState.Circle:

                    // Draw current mode to the game window
                    _spriteBatch.DrawString(arial20, "Circle-Circle", textPosition, Color.White);

                    // ********************************************************
                    // TODO: Draw intersecting circles in red, otherwise white/blue
                    // Are any of the game objects intersecting with the player circle?
                    // If so, draw both the Player and that intersecting circle in red.
                    // Otherwise, draw the player blue and the other objects white.
                    //   COMPLETE
                    // ********************************************************

                    playerCircle.Draw(_spriteBatch,
                    Color.Blue);

                    foreach (CircleEntity c in circleList)
                    {
                        if (playerCircle.Intersects(c))
                        {
                            playerCircle.Draw(_spriteBatch,
                                Color.Red);

                            c.Draw(_spriteBatch, 
                                Color.Red);
                        }
                        else
                        {
                            c.Draw(_spriteBatch, 
                                Color.White);
                        }
                    }

                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}