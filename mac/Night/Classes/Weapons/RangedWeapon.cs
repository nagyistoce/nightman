using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class RangedWeapon : Weapon
	{
		public bool Active { get; set; }
		public List<Projectile> Projectiles;

		public virtual void Shoot(Vector2 position, float rotation)
		{

		}
			
		public override void Update (GameTime gameTime)
		{
			for (int i = 0; i < Projectiles.Count; i++) {
				Projectile p = Projectiles [i];
				p.Update (gameTime);

				if (!p.Active)
					Projectiles.RemoveAt (i);
			}
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			for (int i = 0; i < Projectiles.Count; i++) {
				Projectile p = Projectiles [i];
				p.Draw (spriteBatch);
			}
		}
	}
}

