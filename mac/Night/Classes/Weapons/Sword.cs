using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Sword : MeleeWeapon
	{
		const float MaxAngle = (float)Math.PI;
		const float StartAngle = (float)Math.PI/4;

		public float currentAngle;

		public void Initialize(Animation animation, Vector2 position)
		{
			WeaponAnimation = animation; 

			Active = true;
			fireTime = TimeSpan.FromSeconds(.15f);

		}

		public override void Update(GameTime gameTime)
		{
			base.Update (gameTime);
		}

		public override void Trigger()
		{
			currentAngle = StartAngle;
			Active = true;
		}
	}
}

