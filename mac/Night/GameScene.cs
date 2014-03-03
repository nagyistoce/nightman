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
		Vector2 mousePosition;

		CrossHair crossHair;

		Archer archer;
		float playerMoveSpeed = 12.0f;

		// Textures Test ----

		TileMap tileMap;
		Soldier soldier;


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
		
			archer = new Archer ();
			soldier = new Soldier ();

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

			// CrossHair Loading
			crossHair.Texture = Content.Load<Texture2D>("crosshair");

			// Load the player resources
			Animation playerAnimation = new Animation();
			Texture2D playerTexture = Content.Load<Texture2D>("concept1");
			playerAnimation.Initialize(playerTexture, Vector2.Zero, 64, 64, 4, 30, Color.White, 1.0f, true);

			// Player loading
			Vector2 playerPosition = new Vector2 (0,0);
			archer.Initialize(playerAnimation, playerPosition);
			WeaponFactory.CreateWeapon (archer, Content);


			// Camera startup
			camera2d.Position = archer.Position;
			soldier.Initialize (graphics.GraphicsDevice);

			// Other
			tileMap.LoadFile ();
			WeaponFactory.LoadTextures (Content);
		}

		#endregion

		#region Update and Draw

		protected override void Update (GameTime gameTime)
		{
			//previousKeyboardState = currentKeyboardState;
			currentKeyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState ();
			mousePosition = camera2d.getWorldPosition(new Vector2 (mouseState.X, mouseState.Y));

			UpdateUnit (gameTime);
			UpdateCamera (gameTime);
			UpdateCrossHair ();

			soldier.Update (gameTime, mousePosition);

			base.Update (gameTime);
		}

		private void UpdateUnit(GameTime gameTime)
		{
			archer.Update(gameTime, mousePosition);

			// Fire only every interval we set as the fireTime
			if (currentKeyboardState.IsKeyDown(Keys.Space))
			{
				archer.Attack (gameTime.TotalGameTime);
			}

			// Use the Keyboard / Dpad
			if (currentKeyboardState.IsKeyDown(Keys.A)) {
				archer.Position.X -= playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.D)) {
				archer.Position.X += playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.W)) {
				archer.Position.Y -= playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.S)) {
				archer.Position.Y += playerMoveSpeed;
			}
		}

		private void UpdateCrossHair()
		{
			crossHair.Position = camera2d.getWorldPosition (new Vector2 (mouseState.X, mouseState.Y));
		}

		private void UpdateCamera(GameTime gameTime)
		{
			camera2d.Update (gameTime, archer.Position);
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

			soldier.Draw (spriteBatch);
			DrawUnit (spriteBatch);

			crossHair.Draw (spriteBatch);
			spriteBatch.End ();

			base.Draw (gameTime);
		}

		private void DrawUnit(SpriteBatch spriteBatch)
		{
			archer.Draw (spriteBatch);
			spriteBatch.Draw (Bow.arrowTexture, archer.WeaponPosition, null, Color.White, archer.Rotation, new Vector2 (36, 36), 0.5f, SpriteEffects.None, 0);  
		}
			
		private void DrawHUD ()
		{
			spriteBatch.Begin ();

			//Vector2 pos = new Vector2 (mouseState.X, mouseState.Y);
			//spriteBatch.Draw (cross, pos, null, Color.White, 0, new Vector2(cross.Width/2, cross.Height/2), 0.8f, SpriteEffects.None, 0);

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
