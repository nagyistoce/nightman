using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Archer : Hero
	{
		public new void Initialize(Animation animation, Vector2 position )
		{
			base.Initialize (animation, position);
			UnitType = Hero.TYPE_ARCHER;
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			rangedWeapon.Draw (spriteBatch);
			base.Draw (spriteBatch);
		}

		public new void Update(GameTime gameTime, Vector2 mousePosition)
		{
			rangedWeapon.Update (gameTime);
			base.Update(gameTime, mousePosition);
		}

		public override void Attack(TimeSpan dt)
		{
			if (dt - rangedWeapon.previousFireTime > rangedWeapon.fireTime) {
				rangedWeapon.Shoot (WeaponPosition, Rotation - (float)Math.PI/2);
				rangedWeapon.previousFireTime = dt;
			}
		}

		public override void ExectueAbility_1(float dt)
		{

		}

		public override void ExectueAbility_2(float dt)
		{

		}

		public override void ExectueAbility_3(float dt)
		{

		}

		public override void ExectueAbility_4(float dt)
		{

		}

		public override void ApplyPassive(float dt)
		{

		}
	}
}

