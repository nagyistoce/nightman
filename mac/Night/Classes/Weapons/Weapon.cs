using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public abstract class Weapon
	{
		public static int TYPE_MELEE;
		public static int TYPE_RANGED;

		#region Fields

		// Position of the unit relative to the upper left side of the screen
		public Vector2 Position;

		// Rotation angle
		public float Rotation;

		// Type melee or ranged
		public int Type;

		// Interval of attacks
		public TimeSpan fireTime;
		public TimeSpan previousFireTime;

		#endregion

		public abstract void Update (GameTime gameTime);

		public abstract void Draw (SpriteBatch spriteBatch);
	}
}

