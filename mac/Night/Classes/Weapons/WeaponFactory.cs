using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Night
{
	public static class WeaponFactory
	{
		public static void CreateWeapon(Unit unit, ContentManager content)
		{
			if (unit.UnitType == Hero.TYPE_WARRIOR) {
				Sword s = new Sword ();

				// Load the sword resources
				Animation swordAnimation = new Animation();
				Texture2D swordTexture = content.Load<Texture2D>("swords_1");
				swordAnimation.Initialize(swordTexture, Vector2.Zero, 64, 48, 4, 30, Color.White, 1.0f, true);

				s.Initialize (swordAnimation, unit.Position);
				unit.meleeWeapon = s;

			} else if (unit.UnitType == Hero.TYPE_ARCHER) {
				Bow b = new Bow ();
				unit.rangedWeapon = b;
			}

		}

		public static void LoadTextures(ContentManager content)
		{
			Bow.arrowTexture = content.Load<Texture2D>("logo");
		}
	}
}

