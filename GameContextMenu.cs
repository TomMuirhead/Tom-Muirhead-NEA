using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Game
{
	class GameContextMenu
	{
		ContextMenuStrip contextMenu;
		private ToolStripMenuItem unitMenu, buildingMenu, upgradeMenu, moveMenu;
		private GameControl gameControl;
		//Map map;
		//Unit unit;

		public GameContextMenu(GameControl baseControl)
		{
			gameControl = baseControl;


			contextMenu = new ContextMenuStrip();
			unitMenu = new ToolStripMenuItem("Units");
			buildingMenu = new ToolStripMenuItem("Buildings");
			upgradeMenu = new ToolStripMenuItem("Upgrade");
			moveMenu = new ToolStripMenuItem("Move");

			ToolStripMenuItem[] units = new ToolStripMenuItem[]
			{
				new ToolStripMenuItem("Unit 1", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 2", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 3", null, UnitMenuItemClicked),
				new ToolStripMenuItem("Unit 4", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 5", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 6", null, UnitMenuItemClicked),
			};
			unitMenu.DropDownItems.AddRange(units);

		}


		private void UnitMenuItemClicked(object sender, EventArgs e)
		{
			gameControl.unit = new Unit(sender, gameControl, gameControl.map, gameControl.map.GetTileCoord());
		}

		private void UpgradeMenuItemClicked(object sender, EventArgs e)
		{

		}

		private void AddMenuItem(object sender)
		{
			if (sender == gameControl.map.mapBox)
			{
				contextMenu.Items.Add(unitMenu);
				contextMenu.Items.Add(buildingMenu);
			}
			else if (sender == gameControl.unit.unitBox)
			{
				contextMenu.Items.Add(upgradeMenu);
				contextMenu.Items.Add(moveMenu);
			}
		}

		public void ShowGameContextMenu(object sender)
		{
			contextMenu.Items.Clear();
			AddMenuItem(sender);
			if (sender == gameControl.map.mapBox)
			{
				contextMenu.Show(gameControl.map.mapBox, gameControl.map.GetTileCoord());
			}
			else if (sender == gameControl.unit.unitBox)
			{
				contextMenu.Show(gameControl.map.mapBox, gameControl.unit.tileCoord);
			}
			
		}
	}
}
