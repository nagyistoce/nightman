using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Unit
	{
		#region Fields

		// Animation representing the unit
		public Animation UnitAnimation;

		// Position of the unit relative to the upper left side of the screen
		public Vector2 Position;

		// Position of the weapon referentiel
		public Vector2 WeaponPosition;

		// State of the unit
		public bool Active;

		// Amount of hit points that unit has
		public int Health;

		// Get the width of the unit ship
		public int Width
		{
			get { return UnitAnimation.FrameHeight; }
		}

		// Get the height of the unit ship
		public int Height
		{
			get { return UnitAnimation.FrameHeight; }
		}

		// Rotation angle
		public float Rotation;

		// Type (minion, warrior, etc.)
		public int UnitType;

		public RangedWeapon rangedWeapon;
		public MeleeWeapon meleeWeapon;
			
		#endregion

		public void Initialize(Animation animation, Vector2 position)
		{
			UnitAnimation = animation; 

			Position = position;
			Active = true;
			Health = 100;
			Rotation = 0.0f;
		}

		public void Update(GameTime gameTime, Vector2 mousePosition)
		{
			// Rotation angle according to crosshair position
			float dy = mousePosition.Y - Position.Y;
			float dx = mousePosition.X - Position.X;
			float angle = (float)Math.Atan2( dy, dx );
			Rotation = angle + (float)Math.PI/2;

			Vector2 localWeapon = new Vector2 (10, -20);
			Matrix swordMatrix = Matrix.CreateRotationZ(0) * GetWorldMatrix();
			WeaponPosition = Vector2.Transform(localWeapon, swordMatrix);

			UnitAnimation.Position = Position;
			UnitAnimation.Update(gameTime);
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{ 
			UnitAnimation.Draw (spriteBatch, Rotation);
		}

		private Matrix GetWorldMatrix()
		{
			return Matrix.CreateRotationZ(Rotation) *
				Matrix.CreateTranslation(new Vector3(Position, 0f));
		}
			
	}
}

