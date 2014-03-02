using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class MapRow
	{
		public List<MapCell> Columns = new List<MapCell>();
	}

	public class TileMap
	{
		public List<MapRow> Rows = new List<MapRow>();

		public int MapWidth = 75;
		public int MapHeight = 220;

		int visibleWidth;
		int visibleHeight;

		public TileMap(Vector2 viewPort)
		{
			//visibleWidth = (int)viewPort.X / Tile.TILE_SIZE;
			//visibleHeight = (int)viewPort.Y / Tile.TILE_SIZE;

			visibleWidth = 46;
			visibleHeight = 30;


			for (int y = 0; y < MapHeight; y++) {
				MapRow row = new MapRow();
				for (int x = 0; x < MapWidth; x++) {
					row.Columns.Add(new MapCell(0, new Vector2(x, y)));
				}
				Rows.Add(row);
			}

			// Create Sample Map Data
			Rows[0].Columns[0].TileID = 3;
			Rows[0].Columns[4].TileID = 3;
			Rows[0].Columns[5].TileID = 1;
			Rows[0].Columns[6].TileID = 1;
			Rows[0].Columns[7].TileID = 1;

			Rows[1].Columns[3].TileID = 3;
			Rows[1].Columns[4].TileID = 1;
			Rows[1].Columns[5].TileID = 1;
			Rows[1].Columns[6].TileID = 1;
			Rows[1].Columns[7].TileID = 1;

			Rows[2].Columns[2].TileID = 3;
			Rows[2].Columns[3].TileID = 1;
			Rows[2].Columns[4].TileID = 1;
			Rows[2].Columns[5].TileID = 1;
			Rows[2].Columns[6].TileID = 1;
			Rows[2].Columns[7].TileID = 1;

			Rows[3].Columns[2].TileID = 3;
			Rows[3].Columns[3].TileID = 1;
			Rows[3].Columns[4].TileID = 1;
			Rows[3].Columns[5].TileID = 2;
			Rows[3].Columns[6].TileID = 2;
			Rows[3].Columns[7].TileID = 2;

			Rows[4].Columns[2].TileID = 3;
			Rows[4].Columns[3].TileID = 1;
			Rows[4].Columns[4].TileID = 1;
			Rows[4].Columns[5].TileID = 2;
			Rows[4].Columns[6].TileID = 2;
			Rows[4].Columns[7].TileID = 2;

			Rows[5].Columns[2].TileID = 3;
			Rows[5].Columns[3].TileID = 1;
			Rows[5].Columns[4].TileID = 1;
			Rows[5].Columns[5].TileID = 2;
			Rows[5].Columns[6].TileID = 2;
			Rows[5].Columns[7].TileID = 2;

			Rows[3].Columns[5].AddBaseTile(30);
			Rows[4].Columns[5].AddBaseTile(27);
			Rows[5].Columns[5].AddBaseTile(28);

			Rows[3].Columns[6].AddBaseTile(25);
			Rows[5].Columns[6].AddBaseTile(24);

			Rows[3].Columns[7].AddBaseTile(31);
			Rows[4].Columns[7].AddBaseTile(26);
			Rows[5].Columns[7].AddBaseTile(29);

			Rows[4].Columns[6].AddBaseTile(104);
		}

		public void LoadFile()
		{
			var reader = new StreamReader(TitleContainer.OpenStream("Maps/map.cvs"));
			List<string> listA = new List<string>();
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				listA.Add(line);
			}

			for(int y = 0; y < listA.Count; y++)
			{
				string line = listA [y];
				string[] ids = line.Split (',');
				for (int x = 0; x < ids.Length - 1; x++) 
				{
					Rows [y].Columns [x].TileID = Int32.Parse (ids [x]);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch, Camera2D cam)
		{
			Vector2 origin = new Vector2 ((cam.Position.X - (cam.ViewPortSize.X / 2))/Tile.TileWidth, (cam.Position.Y - (cam.ViewPortSize.Y / 2))/Tile.TileHeight);
			int originX = (int)origin.X - 5;
			int originY = (int)origin.Y - 3;

			for (int j = 0; j < visibleHeight; j++) {
				for (int i = 0; i < visibleWidth; i++) {
					try{ 
						MapCell cell = Rows [j + originY].Columns [i + originX]; 						
							spriteBatch.Draw(
								Tile.TileSetTexture,
								new Vector2 ((int)cell.Position.X * Tile.TileWidth, (int)cell.Position.Y * Tile.TileHeight),
								Tile.GetSourceRectangle (cell.TileID),
								Color.White);
					} catch {}
				}
			}
		}
	}
}
