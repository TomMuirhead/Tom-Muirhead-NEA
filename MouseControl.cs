using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NEA_Game
{
	class MouseControl
	{
		public MouseControl(GameControl baseControl)
		{
			gameControl = baseControl;
		}

		private GameControl gameControl;

		private Point mouseDownLocation;
		public void MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				//Gets position of the cursor relative to the Top-Left of map
				
				mouseDownLocation = gameControl.map.MousePosition();
				gameControl.map.CalcCoord();

				//If map was clicked, call context menu
				if (sender == gameControl.map.mapBox)
				{
					gameControl.gameMenu.ShowGameContextMenu(sender);
				}
				//If unit or structure was clicked, call context menu
				else if (gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] != null)
				{
					if (sender == gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].unitBox)
					{
						gameControl.gameMenu.ShowGameContextMenu(sender);
					}
				}
				else if (gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] != null)
				{
					if (sender == gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].structureBox)
					{
						gameControl.gameMenu.ShowGameContextMenu(sender);
					}
				}
			}
			if (e.Button == MouseButtons.Right)
			{
				if (sender == gameControl.baselayer)
				{
					mouseDownLocation.X = e.X - gameControl.map.mapBox.Left;
					mouseDownLocation.Y = e.Y - gameControl.map.mapBox.Top;
				}
				else
				{
					mouseDownLocation = e.Location;
				}
			}
		}
		public void MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (sender == gameControl.baselayer)
				{
					gameControl.map.mapBox.Left += e.X - gameControl.map.mapBox.Left - mouseDownLocation.X;
					gameControl.map.mapBox.Top += e.Y - gameControl.map.mapBox.Top - mouseDownLocation.Y;
					gameControl.map.CheckOnScreen();
				}
				//if (sender == gameControl.map.mapBox)
				else
				{
					gameControl.map.mapBox.Left += e.X - mouseDownLocation.X;
					gameControl.map.mapBox.Top += e.Y - mouseDownLocation.Y;
					gameControl.map.CheckOnScreen();
				}
			}
		}
		public void ClickTile(object sender, MouseEventArgs e)
		{
			//if (gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] != null)
			//{
			//	if (sender == gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].unitBox)
			//	{
			//	}
			//}
			if (Control.MouseButtons == MouseButtons.Left)
			{
				mouseDownLocation = gameControl.map.MousePosition();
				gameControl.map.CalcCoord();

				Point prevTile = gameControl.GetActiveUnit();
				Point mapCoord = gameControl.map.GetMapCoord();
				gameControl.unitArray[prevTile.X, prevTile.Y].MoveUnit(gameControl, mapCoord);

			}
			gameControl.map.mapBox.MouseDown -= gameControl.mouseControl.ClickTile;
			gameControl.map.mapBox.MouseDown += gameControl.mouseControl.MouseDown;
		}
	}
}
