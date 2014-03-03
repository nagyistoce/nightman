using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Warrior : Hero
	{
		public new void Initialize(Animation animation, Vector2 position)
		{
			base.Initialize (animation, position);
			UnitType = Hero.TYPE_WARRIOR;
		}

		public override void Attack(TimeSpan dt)
		{
			if (dt - meleeWeapon.previousFireTime > meleeWeapon.fireTime) {
				//Weapon.Shoot ();
				meleeWeapon.previousFireTime = dt;
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

