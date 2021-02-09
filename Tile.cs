using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NEA_Game
{
	class Tile
	{
		public TileType tileType;
		public enum TileType
		{
			Unknown, Ocean, Sea, Beach, Plain, Forest, Hill, Mountain, Snow,
		}
		private TileType[,] tileArray;

		private Bitmap tileMap;


		public Tile(int x, int y)
		{
			tileArray = new TileType[x, y];
			PerlinNoise perlinNoise = new PerlinNoise();
			tileMap = new Bitmap(x*48, y*48);

			//Fill TileType Array
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					// Get tileType from noiseValue
					switch (perlinNoise.GetNoise(i, j))
					{
						case float n when n >= 0 && n <= 0.125:
							tileArray[i, j] = TileType.Ocean;
							break;
						case float n when n > 0.125 && n <= 0.25:
							tileArray[i, j] = TileType.Sea;
							break;
						case float n when n > 0.25 && n <= 0.375:
							tileArray[i, j] = TileType.Beach;
							break;
						case float n when n > 0.375 && n <= 0.5:
							tileArray[i, j] = TileType.Plain;
							break;
						case float n when n > 0.5 && n <= 0.625:
							tileArray[i, j] = TileType.Forest;
							break;
						case float n when n > 0.625 && n <= 0.75:
							tileArray[i, j] = TileType.Hill;
							break;
						case float n when n > 0.75 && n <= 0.875:
							tileArray[i, j] = TileType.Mountain;
							break;
						case float n when n > 0.875 && n <= 0.1:
							tileArray[i, j] = TileType.Snow;
							break;
						default:
							tileArray[i, j] = TileType.Unknown;
							break;
					}
				}
			}
		}
	}
}
