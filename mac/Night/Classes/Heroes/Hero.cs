using System;

namespace Night
{
	public abstract class Hero : Unit
	{
		public static int TYPE_WARRIOR = 0;
		public static int TYPE_ARCHER = 1;

		public abstract void ExectueAbility_1(float dt);
		public abstract void ExectueAbility_2(float dt);
		public abstract void ExectueAbility_3(float dt);
		public abstract void ExectueAbility_4(float dt);
		public abstract void ApplyPassive(float dt);
		public abstract void Attack(TimeSpan dt);
	}
}

