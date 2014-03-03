using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Bow : RangedWeapon
	{
		public static Texture2D arrowTexture;

		const float range = 10.0f;
		const int damage = 5;
		const float speed = 1200.0f;
		const float scale = 1.0f;

		public Bow(){
			Projectiles = new List<Projectile> ();
			fireTime = TimeSpan.FromSeconds (.15f);
		}

		public override void Shoot(Vector2 origin, float rotation)
		{
			Projectile p = new Projectile ();
			p.Initialize (arrowTexture, origin, damage, speed, range, rotation, scale);
			Projectiles.Add (p);
		}
	}
}

