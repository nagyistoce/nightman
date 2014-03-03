using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class MeleeWeapon : Weapon
	{
		// Animation representing the weapon
		public Animation WeaponAnimation;

		public bool Active {
			get { return _Active; }
			set { _Active = value; WeaponAnimation.Active = _Active; }
		}

		// State of the unit
		protected bool _Active;

		// Get the width of the weapon
		public int Width
		{
			get { return WeaponAnimation.FrameHeight; }
		}

		// Get the height of the weapon
		public int Height
		{
			get { return WeaponAnimation.FrameHeight; }
		}

		// Rotation center for swing (sword, axe, etc.)
		public Vector2 rotationCenter;

		public override void Update(GameTime gameTime)
		{
			WeaponAnimation.Position = Position;
			WeaponAnimation.Update(gameTime);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{ 
			WeaponAnimation.Draw (spriteBatch, Rotation , rotationCenter);
		}

		public virtual void Trigger ()
		{
			throw new NotImplementedException ();
		}
	}
}

