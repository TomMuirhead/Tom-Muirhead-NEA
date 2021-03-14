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
		private PictureBox baseLayer;
		ContextMenuStrip contextMenu;

		public PictureBox mapBox;
		private int tileSize;
		private int mapWidth;
		private int mapLength;
		private Point tileCoord;

		//private int FormWidth;
		//private int FormHeight;

		public Map(PictureBox ground, int x, int y)
		{
			baseLayer = ground;
			tileSize = 48;
			mapWidth = x;
			mapLength = y;


			mapBox = new PictureBox()
			{
				Size = new Size(tileSize * mapWidth, tileSize * mapLength),
				BackColor = Color.ForestGreen,
			};
			baseLayer.Controls.Add(mapBox);
			CentreMap();

			GameContextMenu();

		}

		private ToolStripMenuItem unitMenu, buildingMenu;
		private void GameContextMenu()
		{
			contextMenu = new ContextMenuStrip();
			unitMenu = new ToolStripMenuItem("Units");
			buildingMenu = new ToolStripMenuItem("Buildings");

			ToolStripMenuItem[] units = new ToolStripMenuItem[]
			{
				new ToolStripMenuItem("Unit 1", null, MenuItemClicked), new ToolStripMenuItem("Unit 2", null, MenuItemClicked), new ToolStripMenuItem("Unit 3", null, MenuItemClicked),
				new ToolStripMenuItem("Unit 4", null, MenuItemClicked), new ToolStripMenuItem("Unit 5", null, MenuItemClicked), new ToolStripMenuItem("Unit 6", null, MenuItemClicked),
			};

			unitMenu.DropDownItems.AddRange(units);
		}


		private void MenuItemClicked(object sender, EventArgs e)
		{
			Unit unit = new Unit(sender, mapBox, tileCoord);
		}
		
		private void AddMenuItem(object sender)
		{
			if (sender == mapBox)
			{
				contextMenu.Items.Add(unitMenu);
				contextMenu.Items.Add(buildingMenu);
			}
		}
		public void ShowGameContextMenu(object sender)
		{
			contextMenu.Items.Clear();
			AddMenuItem(sender);
			contextMenu.Show(mapBox, tileCoord);
		}

		private void SelectTile(Point mouseLocation)
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
		public void MouseDown(object sender, MouseEventArgs e)
		{
			if(sender == baseLayer)
			{
				mouseDownLocation.X = e.X - mapBox.Left;
				mouseDownLocation.Y = e.Y - mapBox.Top;
			}
			else
			{
				mouseDownLocation = e.Location;
				if (e.Button == MouseButtons.Left)
				{
					SelectTile(mouseDownLocation);
					ShowGameContextMenu(sender);
				}
			}
		}
		public void MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (sender == mapBox)
				{
					mapBox.Left += e.X - mouseDownLocation.X;
					mapBox.Top += e.Y - mouseDownLocation.Y;
					CheckOnScreen();
				}
				else if (sender == baseLayer)
				{
					mapBox.Left += e.X - mapBox.Left - mouseDownLocation.X;
					mapBox.Top += e.Y - mapBox.Top - mouseDownLocation.Y;
					CheckOnScreen();
				}
			}
		}
		public void CentreMap() //Centres the pictureBox to middle of screen
		{
			mapBox.Left = (baseLayer.Width / 2) - (mapBox.Width / 2);
			mapBox.Top = (baseLayer.Height / 2) - (mapBox.Height / 2);
		}

		private void CheckOnScreen() // Called everytime the map is moved
		{	// The numbers +/- is used because the form coords are not exactly on the edge of the screen
			if (mapBox.Bottom < tileSize + 24) // Keeps one tile width on screen
			{
				// Resets the pictureBox to edge if it goes off screen
				mapBox.Top = tileSize - mapBox.Height + 24;
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
