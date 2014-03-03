using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Night
{
	public class Player
	{
		public Player(GraphicsDevice graphicsDevice)
		{
			_pixel = new Texture2D(graphicsDevice, 1, 1);
			_pixel.SetData(new [] { Color.White });
			_playerPosition = new Vector2(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height) / 2f;
		}

		public void Update(GameTime gameTime)
		{
			KeyboardState keyboard = Keyboard.GetState();
			float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (keyboard.IsKeyDown(Keys.Right)) _playerPosition += Vector2.UnitX * elapsed * PlayerMoveSpeed;
			if (keyboard.IsKeyDown(Keys.Left)) _playerPosition -= Vector2.UnitX * elapsed * PlayerMoveSpeed;
			if (keyboard.IsKeyDown(Keys.Up)) _playerPosition -= Vector2.UnitY * elapsed * PlayerMoveSpeed;
			if (keyboard.IsKeyDown(Keys.Down)) _playerPosition += Vector2.UnitY * elapsed * PlayerMoveSpeed;
			if (keyboard.IsKeyDown(Keys.A)) _playerRotation -= MathHelper.ToRadians(360f) * elapsed;
			if (keyboard.IsKeyDown(Keys.D)) _playerRotation += MathHelper.ToRadians(360f) * elapsed;
			if (keyboard.IsKeyDown(Keys.W)) _playerScale -= 1f * elapsed;
			if (keyboard.IsKeyDown(Keys.S)) _playerScale += 1f * elapsed;
			if (keyboard.IsKeyDown(Keys.Q)) _swordDistance -= 50f * elapsed;
			if (keyboard.IsKeyDown(Keys.E)) _swordDistance += 50f * elapsed;
			if (keyboard.IsKeyDown(Keys.Space)) _swordRotation += MathHelper.ToRadians(SwordRotationSpeed) * elapsed;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			// Draw Player
			spriteBatch.Draw(_pixel, _playerPosition, _playerSize, Color.Black, _playerRotation, _playerOrigin, _playerScale, SpriteEffects.None, 0f);

			// Calculate sword position in world space
			Vector2 localSword = new Vector2(0, _swordDistance);
			Matrix swordMatrix = Matrix.CreateRotationZ(_swordRotation) * GetPlayerWorldMatrix();
			Vector2 swordPosition = Vector2.Transform(localSword, swordMatrix);

			// Draw sword
			spriteBatch.Draw(_pixel, swordPosition, _swordSize, Color.Red, _playerRotation, _swordOrigin, _playerScale, SpriteEffects.None, 0f);
		}

		private Matrix GetPlayerWorldMatrix()
		{
			return Matrix.CreateScale(_playerScale, _playerScale, 1f) *
				Matrix.CreateRotationZ(_playerRotation) *
				Matrix.CreateTranslation(new Vector3(_playerPosition, 0f));
		}

		// Change these to control your player
		private Vector2 _playerPosition = Vector2.Zero;
		private float _playerRotation = 0f;
		private float _playerScale = 1f;

		// Change these to control the sword
		private float _swordDistance = 50f;
		private float _swordRotation = MathHelper.ToRadians(0);

		// Movement constants used in input handling
		private const float PlayerMoveSpeed = 200f;
		private const float SwordRotationSpeed = 720f;

		// Rendering only constants
		private readonly Rectangle _playerSize = new Rectangle(0, 0, 30, 30);
		private readonly Vector2 _playerOrigin = new Vector2(15, 15);
		private readonly Rectangle _swordSize = new Rectangle(0, 0, 10, 10);
		private readonly Vector2 _swordOrigin = new Vector2(5, 5);
		readonly Texture2D _pixel;
	}
}

