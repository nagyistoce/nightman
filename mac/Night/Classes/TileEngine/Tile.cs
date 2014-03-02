using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	static public class Tile
	{
		static public Texture2D TileSetTexture;

		static public int TileWidth = 64;
		static public int TileHeight = 64;

		static public Rectangle GetSourceRectangle(int tileIndex)
		{
			int tileY = tileIndex / (TileSetTexture.Width / TileWidth);
			int tileX = tileIndex % (TileSetTexture.Width / TileWidth);

			return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
		}
	}
}

