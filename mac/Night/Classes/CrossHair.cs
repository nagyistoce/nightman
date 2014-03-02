using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class CrossHair
	{
		// Animation representing the player
		public Texture2D Texture;
		public Animation CrossAnim;

		// Position of the Player relative to the upper left side of the screen
		public Vector2 Position;

		public CrossHair ()
		{

		}

		public void Draw(SpriteBatch batcher)
		{
			batcher.Draw (Texture, Position, null, Color.White, 0, new Vector2(Texture.Width/2, Texture.Height/2), 0.8f, SpriteEffects.None, 0);
		}
	}
}

