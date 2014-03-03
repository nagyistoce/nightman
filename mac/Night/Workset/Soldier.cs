using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Night
{
	public class Soldier
	{
		public Vector2 Position;
		public float Rotation;
		public float Scale;

		// Temp
		float swordRotation = MathHelper.ToRadians(0);
		float swordDistance = 50.0f;
		float swordDistance2 = 60.0f;
		float swordDistance3 = 40.0f;
		Vector2 origin;

		private readonly Rectangle _playerSize = new Rectangle(0, 0, 30, 30);
		private readonly Rectangle _swordSize = new Rectangle(0, 0, 10, 50);
		private readonly Vector2 _swordOrigin = new Vector2(5, 25);
		private Texture2D pixel;
		public Animation UnitAnimation;

		public void Initialize (GraphicsDevice graphicsDevice )
		{
			pixel = new Texture2D(graphicsDevice, 1, 1);
			pixel.SetData(new [] { Color.White });
			Position = new Vector2(0, 0);
			Scale = 1.0f;
			origin = new Vector2 (15, 15);
		}

		public void Update(GameTime gameTime, Vector2 mousePosition)
		{
			//Rotation angle according to crosshair position
			float dy = mousePosition.Y - Position.Y;
			float dx = mousePosition.X - Position.X;
			float angle = (float)Math.Atan2( dy, dx );
			Rotation =  angle + (float)Math.PI/2;

			KeyboardState keyboard = Keyboard.GetState();
			float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (keyboard.IsKeyDown(Keys.Right)) Position += Vector2.UnitX * elapsed * 200;
			if (keyboard.IsKeyDown(Keys.Left)) Position -= Vector2.UnitX * elapsed * 200;
			if (keyboard.IsKeyDown(Keys.Up)) Position -= Vector2.UnitY * elapsed * 200;
			if (keyboard.IsKeyDown(Keys.Down)) Position += Vector2.UnitY * elapsed * 200;
			if (keyboard.IsKeyDown(Keys.A)) Rotation -= MathHelper.ToRadians(360f) * elapsed;
			if (keyboard.IsKeyDown(Keys.D)) Rotation += MathHelper.ToRadians(360f) * elapsed;
			if (keyboard.IsKeyDown(Keys.W)) Scale -= 1f * elapsed;
			if (keyboard.IsKeyDown(Keys.S)) Scale += 1f * elapsed;
			if (keyboard.IsKeyDown(Keys.Space)) swordRotation += MathHelper.ToRadians(720) * elapsed;


		}

		private Matrix GetPlayerWorldMatrix()
		{
			return Matrix.CreateScale(Scale, Scale, 1f) *
				Matrix.CreateRotationZ(Rotation) *
				Matrix.CreateTranslation(new Vector3(Position, 0f));
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			// Draw Player
			spriteBatch.Draw(pixel, Position, _playerSize, Color.Black, Rotation, origin, Scale, SpriteEffects.None, 0f);

			// Calculate sword position in world space
			Vector2 localSword = new Vector2(0, swordDistance);
//			Vector2 localSword2 = new Vector2(0, swordDistance2);
//			Vector2 localSword3 = new Vector2(0, swordDistance3);

			Matrix swordMatrix = Matrix.CreateRotationZ(swordRotation) * GetPlayerWorldMatrix();
			Vector2 swordPosition = Vector2.Transform(localSword, swordMatrix);
//			Vector2 swordPosition2 = Vector2.Transform(localSword2, swordMatrix);
//			Vector2 swordPosition3 = Vector2.Transform(localSword3, swordMatrix);


			// Draw sword
			spriteBatch.Draw(pixel, swordPosition, _swordSize, Color.Red, Rotation, _swordOrigin, Scale, SpriteEffects.None, 0f);
//			spriteBatch.Draw(pixel, swordPosition2, _swordSize, Color.Red, Rotation, _swordOrigin, Scale, SpriteEffects.None, 0f);
//			spriteBatch.Draw(pixel, swordPosition3, _swordSize, Color.Red, Rotation, _swordOrigin, Scale, SpriteEffects.None, 0f);


		}
	}
}

