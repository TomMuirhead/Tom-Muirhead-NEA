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
		private int tileSize;
		private int mapWidth;
		private int mapLength;
		private Point tileCoord;
		private Bitmap tileMap;
		

		public Map(GameControl baseControl, int x, int y)
		{
			gameControl = baseControl;
			baseLayer = gameControl.baselayer;
			tileSize = 48;
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
			//gameMenu = new GameContextMenu(this);
		}

		private void drawMap() //Creates bitmap image to set as map in pictureBox
		{
			Tile tile = new Tile(mapWidth, mapLength);
			tileMap = tile.GetTileMap();
		}

		public void SelectTile(Point mouseLocation)// Gets tilecoord of selected tile
		{
			int x = mouseLocation.X / tileSize * tileSize;
			int y = mouseLocation.Y / tileSize * tileSize;
			tileCoord = new Point(x, y);
		}
		public Point GetTileCoord()
		{
			return tileCoord;
		}


		private Point mouseDownLocation;
		//public void MouseDown(object sender, MouseEventArgs e)
		//{
		//	if (e.Button == MouseButtons.Left)
		//	{
		//		if (sender == mapBox)
		//		{
		//			mouseDownLocation = e.Location;
		//			SelectTile(mouseDownLocation);
		//			gameMenu.ShowGameContextMenu(sender);
		//		}
		//		else if (sender == unit.unitBox)
		//		{
		//			mouseDownLocation = unit.GetTileCoord(sender);
		//		}
		//	}
		//	if (e.Button == MouseButtons.Right)
		//	{
		//		if (sender == baseLayer)
		//		{
		//			mouseDownLocation.X = e.X - mapBox.Left;
		//			mouseDownLocation.Y = e.Y - mapBox.Top;
		//		}
		//		else
		//		{
		//			mouseDownLocation = e.Location;
		//		}
		//	}

		//	//if(sender == baseLayer)
		//	//{
		//	//	mouseDownLocation.X = e.X - mapBox.Left;
		//	//	mouseDownLocation.Y = e.Y - mapBox.Top;
		//	//}
		//	//else
		//	//{
		//	//	mouseDownLocation = e.Location;
		//	//	if (e.Button == MouseButtons.Left)
		//	//	{
		//	//		SelectTile(mouseDownLocation);
		//	//		gameMenu.ShowGameContextMenu(sender);
		//	//	}
		//	//}
		//}
		//public void MouseMove(object sender, MouseEventArgs e)
		//{
		//	if (e.Button == MouseButtons.Right)
		//	{
		//		if (sender == mapBox)
		//		{
		//			mapBox.Left += e.X - mouseDownLocation.X;
		//			mapBox.Top += e.Y - mouseDownLocation.Y;
		//			CheckOnScreen();
		//		}
		//		else if (sender == baseLayer)
		//		{
		//			mapBox.Left += e.X - mapBox.Left - mouseDownLocation.X;
		//			mapBox.Top += e.Y - mapBox.Top - mouseDownLocation.Y;
		//			CheckOnScreen();
		//		}
		//	}
		//}
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
