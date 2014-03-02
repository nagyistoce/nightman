using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Night
{
	public class MapCell
	{
		public List<int> BaseTiles = new List<int>();
		public int TileID
		{
			get { return BaseTiles.Count > 0 ? BaseTiles[0] : 0; }
			set
			{
				if (BaseTiles.Count > 0)
					BaseTiles[0] = value;
				else
					AddBaseTile(value);
			}
		}

		public Vector2 Position;

		public MapCell(int tileID, Vector2 pos)
		{
			TileID = tileID;
			Position = pos;
		}

		public void AddBaseTile(int tileID)
		{
			BaseTiles.Add(tileID);
		}
	}
}

