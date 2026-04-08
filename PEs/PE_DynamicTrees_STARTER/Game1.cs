using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_DynamicTrees
{
    /// <summary>
    /// DO NOT MODIFY EXCEPT WHERE MARKED "TODO"!
    /// 
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// The three trees
		Tree treeRed;
		Tree treeGreen;
		Tree treeBlue;

		//Random
		Random rng;

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

			//create a random for the trees
			rng = new Random();

			// Create the three trees
			treeRed = new Tree(Color.Red);
			treeGreen = new Tree(Color.Green);
			treeBlue = new Tree(Color.DodgerBlue);

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// TODO: Add logic to insert data into the red tree
			//   -Needs to sprawl out in all directions
			//   - Just needs to be random, with an average root node
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			//   - COMPLETED

			//Average Node size for root
			treeRed.Insert(100);
			for(int i = 0; i < 100; i++)
			{
				//Random Node data
				treeRed.Insert(rng.Next(0, 200));
			}

			//Notes: Larger max keeps the tree more centrally based, as there is a lesser chance for a super high or super low number

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// TODO: Add logic to insert data into the green tree
			//   -Needs to be a circle
			//   - Add 1 value, 1 value greater than it, 1 greater than that, and repeat.
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			//   - COMPLETE

			for(int i = 0; i < 100; i++)
			{
				treeGreen.Insert(i);
			}

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add logic to insert data into the blue tree
            //   -Needs to sprawl Right
            //   - If the node is very small, not much will be less than it
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //   - COMPLETED

            for (int i = 0;  i < 30; i++)
			{
				//Increases the value of the maximum over time, meaning the root will be very small
				// and subsequent nodes will have a much higher likelihood of being large
				treeBlue.Insert(rng.Next(0, i * 5));
			}
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

			// TODO: If you want to play:
			//	AFTER you have the rest of the assignment working:
			//  What happens if you insert a new piece of 
			//  data into the trees each frame (or maybe every few frames)?

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// Draw the trees
			treeRed.Draw(new Vector2(150, 400), GraphicsDevice);
			treeGreen.Draw(new Vector2(300, 300), GraphicsDevice);
			treeBlue.Draw(new Vector2(600, 400), GraphicsDevice);

			base.Draw(gameTime);
		}
	}
}
