using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NEA_Game
{
	class Map
	{
		private GameControl gameControl;

		private PictureBox baseLayer;

		public PictureBox mapBox;
		private const int tileSize = 48;
		public int GetTileSize()
		{
			return tileSize;
		}
		private int mapWidth;
		private int mapLength;
		public int GetMapWidth()
		{
			return mapWidth;
		}
		public int GetMapLength()
		{
			return mapLength;
		}

		private Point mapCoord;
		private Bitmap tileMap;

		private Point mousePosition;
		public Point MousePosition() //mouse position relative to map
		{
			mousePosition = mapBox.PointToClient(Control.MousePosition);
			return mousePosition;
		}

		public Map(GameControl baseControl, int x, int y)
		{
			gameControl = baseControl;
			baseLayer = gameControl.baselayer;
			mapWidth = x;
			mapLength = y;

			drawMap();

			mapBox = new PictureBox()
			{
				Size = new Size(tileSize * mapWidth, tileSize * mapLength),
				BackgroundImage = tileMap,
				Image = tileMap,
			};
			baseLayer.Controls.Add(mapBox);
			CentreMap();


			mapBox.MouseDown += gameControl.mouseControl.MouseDown;
			mapBox.MouseMove += gameControl.mouseControl.MouseMove;

			
		}

		private void drawMap() //Creates bitmap image to set as map in pictureBox
		{
			Tile tile = new Tile(mapWidth, mapLength);
			tileMap = tile.GetTileMap();
		}

		public void CalcCoord()// Gets tilecoord of selected tile
		{
			//mousePosition = MousePosition();
			int x = mousePosition.X / tileSize * tileSize;
			int y = mousePosition.Y / tileSize * tileSize;
			mapCoord = new Point(x, y);
		}

		public Point GetMapCoord()
		{
			CalcCoord();
			return mapCoord;
		}
		public Point SelectedTile() // Gets the index of tile
		{
			CalcCoord();
			int x = mapCoord.X / tileSize;
			int y = mapCoord.Y / tileSize;
			return new Point(x, y);
		}

		public void CentreMap() //Centres the pictureBox to middle of screen
		{
			mapBox.Left = (baseLayer.Width / 2) - (mapBox.Width / 2);
			mapBox.Top = (baseLayer.Height / 2) - (mapBox.Height / 2);
		}

		public void CheckOnScreen()
		{
			if (mapBox.Bottom < tileSize + 24) //Keeps one tile width on screen
			{
				mapBox.Top = tileSize - mapBox.Height + 24; //Resets the pictureBox to edge of screen if it goes off screen
			}
			if (mapBox.Top > baseLayer.Height - tileSize - 40)
			{
				mapBox.Top = baseLayer.Height - tileSize - 40;
			}
			if (mapBox.Right < tileSize)
			{
				mapBox.Left = tileSize - mapBox.Width;
			}
			if (mapBox.Left > baseLayer.Width - tileSize - 16)
			{
				mapBox.Left = baseLayer.Width - tileSize - 16;
			}
		}
	}
}
