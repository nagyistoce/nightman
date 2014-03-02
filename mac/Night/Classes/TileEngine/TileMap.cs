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

		public int MapWidth = 128 +1;
		public int MapHeight = 164 +1;

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

			//reminder...
			//Rows[4].Columns[6].AddBaseTile(104);
		}

		// Read CVS map definition, obtained from Tiled
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
					Rows [y].Columns [x].TileID = Int32.Parse (ids [x]) -1;
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch, Camera2D cam)
		{
			Vector2 origin = new Vector2 (cam.getTopLeftView().X / Tile.TileWidth, cam.getTopLeftView().Y / Tile.TileHeight);
			int originX = (int)origin.X - 5;	// Offset to cover weird span
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
