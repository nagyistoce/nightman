using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Projectile
	{
		// Image representing the Projectile
		public Texture2D Texture;

		// Position of the Projectile relative to the upper left side of the screen
		public Vector2 Position;

		public float Rotation;
		public float Scale;

		public bool Active;
		public int Damage;
		public float Range;

		// Get the width of the projectile ship
		public int Width
		{
			get { return Texture.Width; }
		}

		// Get the height of the projectile ship
		public int Height
		{
			get { return Texture.Height; }
		}

		float Speed;
		float Friction = -0.25f;
			
		public void Initialize(Texture2D texture, Vector2 position, int damage, float speed, float range, float angle, float scale)
		{
			Texture = texture;
			Position = position;
			Rotation = angle;
			Scale = scale;
			Range = range;

			Active = true;
			Damage = damage;
			Speed = speed;
		}

		public void Update(GameTime gameTime)
		{
			float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
			Range -= 50*dt*dt;

			// Move projectile
			Speed = (Speed > 0) ? Speed + (Friction) : Speed;
			Position = new Vector2 (Position.X + (float)( Speed * Math.Cos (Rotation) * dt), 
				Position.Y + (float)( Speed * Math.Sin (Rotation) * dt)); 

			if (Range <= 0 || Speed == 0)
				Active = false;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, null, Color.White, Rotation,
				new Vector2(Width / 2, Height / 2), Scale, SpriteEffects.None, 0f);
		}
	}
}

