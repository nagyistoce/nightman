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
		//SpriteFont font;
		Camera2D camera2d;

		// Keyboard states used to determine key presses
		KeyboardState currentKeyboardState;
		//KeyboardState previousKeyboardState;
		MouseState mouseState;
		

		CrossHair crossHair;

		Player player;

		Texture2D cross;

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
			crossHair = new CrossHair ();
		
			player = new Player ();

			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be use to draw textures.
			spriteBatch = new SpriteBatch (graphics.GraphicsDevice);

			// Create font batch
			//SpriteFont bla = Content.Load<SpriteFont>("myfont");

			// Camera loading
			Vector2 viewPort = new Vector2 (graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
			camera2d.Initialize (viewPort);
			camera2d.Zoom = 1.0f;

			// Tiles loading
			Tile.TileSetTexture = Content.Load<Texture2D>("part2_tileset");
			tileMap = new TileMap (viewPort);

			// CrossHair Loading
			crossHair.Texture = Content.Load<Texture2D>("crosshair");

			// Load the player resources
			Animation playerAnimation = new Animation();
			Texture2D playerTexture = Content.Load<Texture2D>("shipAnimation");
			playerAnimation.Initialize(playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 0.75f, true);

			// Player loading
			Vector2 playerPosition = new Vector2 (128*Tile.TileWidth/2, 800);
			player.Initialize(playerAnimation, playerPosition);
			camera2d.Position = playerPosition;

			//crossHair.CrossAnim = playerAnimation;

			// Other
			tileMap.LoadFile ();
		}

		#endregion

		#region Update and Draw

		protected override void Update (GameTime gameTime)
		{
			//previousKeyboardState = currentKeyboardState;
			currentKeyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState ();

			UpdatePlayer (gameTime);
			UpdateCamera (gameTime);
			UpdateCrossHair ();

			base.Update (gameTime);
		}

		private void UpdatePlayer(GameTime gameTime)
		{
			player.Update(gameTime);

			float playerMoveSpeed = 12.0f;

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

		private void UpdateCrossHair()
		{
			crossHair.Position = camera2d.getWorldPosition (new Vector2 (mouseState.X, mouseState.Y));
		}

		private void UpdateCamera(GameTime gameTime)
		{
			camera2d.Update (gameTime, player.Position);
		}
			
		protected override void Draw (GameTime gameTime)
		{
			// Clear the backbuffer
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.Deferred,
				BlendState.AlphaBlend,
				SamplerState.PointClamp, 
				null, null, null,
				camera2d.getTransformation());
				
			tileMap.Draw (spriteBatch, camera2d);

			player.Draw(spriteBatch);

			crossHair.Draw (spriteBatch);

			spriteBatch.End ();

			//DrawHUD ();

			//TODO: Add your drawing code here
			base.Draw (gameTime);
		}

		private void DrawHUD ()
		{
			spriteBatch.Begin ();

			Vector2 pos = new Vector2 (mouseState.X, mouseState.Y);
			spriteBatch.Draw (cross, pos, null, Color.White, 0, new Vector2(cross.Width/2, cross.Height/2), 0.8f, SpriteEffects.None, 0);

			spriteBatch.End ();
		}

//		private void DrawText()
//		{
//			spriteBatch.DrawString(font, "Mouse Pos: " + crossHair.Position.X + ", " + crossHair.Position.Y, new Vector2(camera2d.Position.X - camera2d.ViewPortSize.X/2 + 45 , 
//				camera2d.Position.Y - camera2d.ViewPortSize.Y/2 + 45 ), Color.White);
//		}

		#endregion
	}
}
