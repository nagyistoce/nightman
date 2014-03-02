using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Night
{
	public static class CollisionManager
	{
//		public static void UpdateCollision(List<Enemy> enemies, Player player, List<Projectile> projectiles)
//		{
//			Rectangle rectangle1;
//			Rectangle rectangle2;
//
//			// Only create the rectangle once for the player
//			rectangle1 = new Rectangle((int)player.Position.X,
//				(int)player.Position.Y,
//				player.Width,
//				player.Height);
//
//			// Do the collision between the player and the enemies
//			for (int i = 0; i <enemies.Count; i++)
//			{
//				rectangle2 = new Rectangle((int)enemies[i].Position.X,
//					(int)enemies[i].Position.Y,
//					enemies[i].Width,
//					enemies[i].Height);
//
//				// Determine if the two objects collided 
//				if(rectangle1.Intersects(rectangle2))
//				{
//					player.Health -= enemies[i].Damage;
//					enemies[i].Health = 0;
//				
//					if (player.Health <= 0)
//						player.Active = false; 
//				}
//			}
//
//			// Projectile vs Enemy Collision
//			for (int i = 0; i < projectiles.Count; i++)
//			{
//				for (int j = 0; j < enemies.Count; j++)
//				{
//					// Create the rectangles we need to determine if we collided with each other
//					rectangle1 = new Rectangle((int)projectiles[i].Position.X - 
//						projectiles[i].Width / 2,(int)projectiles[i].Position.Y - 
//						projectiles[i].Height / 2,projectiles[i].Width, projectiles[i].Height);
//
//					rectangle2 = new Rectangle((int)enemies[j].Position.X - enemies[j].Width / 2,
//						(int)enemies[j].Position.Y - enemies[j].Height / 2,
//						enemies[j].Width, enemies[j].Height);
//
//					// Determine if the two objects collided with each other
//					if (rectangle1.Intersects(rectangle2))
//					{
//						enemies[j].Health -= projectiles[i].Damage;
//						projectiles[i].Active = false;
//					}
//				}
//			}
//		}
	}
}

