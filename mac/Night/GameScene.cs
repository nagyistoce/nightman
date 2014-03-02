#region File Description
//-----------------------------------------------------------------------------
// NightGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

#endregion
namespace Night
{
	public class GameScene : Game
	{
		#region Fields

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Camera2D camera2d;

		// Keyboard states used to determine key presses
		KeyboardState currentKeyboardState;
		//KeyboardState previousKeyboardState;

		Player player;

		// Textures Test ----

		TileMap tileMap;


		#endregion

		#region Initialization

		public GameScene ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			graphics.IsFullScreen = false;
		}
			
		protected override void Initialize ()
		{
			graphics.PreferredBackBufferWidth = 1440;
			graphics.PreferredBackBufferHeight = 900;


			camera2d = new Camera2D ();

		
			player = new Player ();

			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be use to draw textures.
			spriteBatch = new SpriteBatch (graphics.GraphicsDevice);

			// Camera loading
			Vector2 viewPort = new Vector2 (graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
			camera2d.Initialize (viewPort);
			camera2d.Zoom = 1.0f;

			// Tiles loading
			Tile.TileSetTexture = Content.Load<Texture2D>("part2_tileset");
			tileMap = new TileMap (viewPort);

			// Load the player resources
			Animation playerAnimation = new Animation();
			Texture2D playerTexture = Content.Load<Texture2D>("shipAnimation");
			playerAnimation.Initialize(playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 0.75f, true);

			// Player loading
			Vector2 playerPosition = new Vector2 (900, 550);
			player.Initialize(playerAnimation, playerPosition);
			camera2d.Position = playerPosition;

			// Other
			tileMap.LoadFile ();
		}

		#endregion

		#region Update and Draw

		protected override void Update (GameTime gameTime)
		{
			//previousKeyboardState = currentKeyboardState;
			currentKeyboardState = Keyboard.GetState();

			UpdatePlayer (gameTime);

			camera2d.Update (gameTime);
			camera2d.Focus = player.Position;

			base.Update (gameTime);
		}

		private void UpdatePlayer(GameTime gameTime)
		{
			player.Update(gameTime);
			float playerMoveSpeed = 6.0f;

			// Use the Keyboard / Dpad
			if (currentKeyboardState.IsKeyDown(Keys.Left)) {
				player.Position.X -= playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.Right)) {
				player.Position.X += playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.Up)) {
				player.Position.Y -= playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.Down)) {
				player.Position.Y += playerMoveSpeed;
			}
		}
			
		protected override void Draw (GameTime gameTime)
		{
			// Clear the backbuffer
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.BackToFront,
				BlendState.AlphaBlend,
				SamplerState.PointClamp, 
				null, null, null,
				camera2d.getTransformation());

			tileMap.Draw (spriteBatch, camera2d);

			player.Draw(spriteBatch);
			spriteBatch.End ();

			//TODO: Add your drawing code here
			base.Draw (gameTime);
		}

		#endregion
	}
}
