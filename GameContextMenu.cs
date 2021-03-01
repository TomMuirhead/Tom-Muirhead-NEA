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
		private GameControl gameControl;
		private ContextMenuStrip contextMenu;
		private ToolStripMenuItem unitMenu, buildingMenu, upgradeMenu, moveMenu, manageMenu;

		public GameContextMenu(GameControl baseControl)
		{
			gameControl = baseControl;

			contextMenu = new ContextMenuStrip();
			unitMenu = new ToolStripMenuItem("Units");
			buildingMenu = new ToolStripMenuItem("Buildings");
			upgradeMenu = new ToolStripMenuItem("Upgrade");
			moveMenu = new ToolStripMenuItem("Move", null, MoveItemClicked);
			manageMenu = new ToolStripMenuItem("Manage");

			FillDropDownMenu();
		}

		private void FillDropDownMenu()
		{
			ToolStripMenuItem[] units = new ToolStripMenuItem[]
			{
				new ToolStripMenuItem("Unit 1", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 2", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 3", null, UnitMenuItemClicked),
				new ToolStripMenuItem("Unit 4", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 5", null, UnitMenuItemClicked), new ToolStripMenuItem("Unit 6", null, UnitMenuItemClicked),
			};
			unitMenu.DropDownItems.AddRange(units);

			ToolStripMenuItem[] structures = new ToolStripMenuItem[]
			{
				new ToolStripMenuItem("City", null, BuildingMenuItemClicked), new ToolStripMenuItem("Fish", null, BuildingMenuItemClicked), new ToolStripMenuItem("Port", null, BuildingMenuItemClicked),
				new ToolStripMenuItem("Farm", null, BuildingMenuItemClicked), new ToolStripMenuItem("Lumber", null, BuildingMenuItemClicked), new ToolStripMenuItem("Mine", null, BuildingMenuItemClicked),
				new ToolStripMenuItem("Road", null, BuildingMenuItemClicked),
			};
			buildingMenu.DropDownItems.AddRange(structures);
		}
		private void FillUpgradeMenu()
		{
			ToolStripMenuItem[] options = new ToolStripMenuItem[]
			{
				new ToolStripMenuItem("Unit 1", null, UpgradeMenuItemClicked), new ToolStripMenuItem("Unit 2", null, UpgradeMenuItemClicked), new ToolStripMenuItem("Unit 3", null, UpgradeMenuItemClicked),
				new ToolStripMenuItem("Unit 4", null, UpgradeMenuItemClicked), new ToolStripMenuItem("Unit 5", null, UpgradeMenuItemClicked), new ToolStripMenuItem("Unit 6", null, UpgradeMenuItemClicked),
			};
			ToolStripMenuItem[] optionItems;

			//Shows the available upgrade options (>current unit type)
			switch (gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].GetUnitType())
			{
				case Unit.UnitType.Unit1:
					optionItems = new ToolStripMenuItem[]
					{
						options[1], options[2], options[3], options[4], options[5]
					};
					upgradeMenu.DropDownItems.AddRange(optionItems);
					break;
				case Unit.UnitType.Unit2:
					optionItems = new ToolStripMenuItem[]
					{
						options[2], options[3], options[4], options[5]
					};
					upgradeMenu.DropDownItems.AddRange(optionItems);
					break;
				case Unit.UnitType.Unit3:
					optionItems = new ToolStripMenuItem[]
					{
						options[3], options[4], options[5]
					};
					upgradeMenu.DropDownItems.AddRange(optionItems);
					break;
				case Unit.UnitType.Unit4:
					optionItems = new ToolStripMenuItem[]
					{
						options[4], options[5]
					};
					upgradeMenu.DropDownItems.AddRange(optionItems);
					break;
				case Unit.UnitType.Unit5:
					optionItems = new ToolStripMenuItem[]
					{
						options[5]
					};
					upgradeMenu.DropDownItems.AddRange(optionItems);
					break;
				case Unit.UnitType.Unit6:
					optionItems = new ToolStripMenuItem[]
					{
						new ToolStripMenuItem("Max")
					};
					upgradeMenu.DropDownItems.AddRange(optionItems);
					break;
				default:
					break;
			}
		}
		private void FillManageMenu()
		{
			ToolStripMenuItem[] options = new ToolStripMenuItem[]
			{
				new ToolStripMenuItem("Collect", null, CollectItemClicked), new ToolStripMenuItem("Destroy", null, DestroyItemClicked),
			};
			ToolStripMenuItem[] optionItems;

			//Shows available options based on type of structure
			switch (gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].GetStructureType())
			{
				case Structure.StructureType.City:
					optionItems = new ToolStripMenuItem[]
					{
						options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				case Structure.StructureType.Fish:
					optionItems = new ToolStripMenuItem[]
					{
						options[0], options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				case Structure.StructureType.Port:
					optionItems = new ToolStripMenuItem[]
					{
						options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				case Structure.StructureType.Farm:
					optionItems = new ToolStripMenuItem[]
					{
						options[0], options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				case Structure.StructureType.Lumber:
					optionItems = new ToolStripMenuItem[]
					{
						options[0], options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				case Structure.StructureType.Mine:
					optionItems = new ToolStripMenuItem[]
					{
						options[0], options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				case Structure.StructureType.Road:
					optionItems = new ToolStripMenuItem[]
					{
						options[1]
					};
					manageMenu.DropDownItems.AddRange(optionItems);
					break;
				default:
					break;
			}
		}

		private void UnitMenuItemClicked(object sender, EventArgs e)
		{
			gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] = new Unit(sender, gameControl, gameControl.map.GetMapCoord());
		}
		private void MoveItemClicked(object sender, EventArgs e)
		{
			gameControl.map.mapBox.MouseDown += gameControl.mouseControl.ClickTile;
			gameControl.map.mapBox.MouseDown -= gameControl.mouseControl.MouseDown;

			gameControl.SetActiveUnit(gameControl.map.SelectedTile());
		}
		private void UpgradeMenuItemClicked(object sender, EventArgs e)
		{
			gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].UpgradeUnit(sender, gameControl);
		}
		private void BuildingMenuItemClicked(object sender, EventArgs e)
		{
			gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] = new Structure(sender, gameControl, gameControl.map.GetMapCoord());
		}
		private void CollectItemClicked(object sender, EventArgs e)
		{

		}
		private void DestroyItemClicked(object sender, EventArgs e)
		{
			gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].Destroy(gameControl, gameControl.map.SelectedTile());
		}


		private void AddMenuItem(object sender)
		{
			contextMenu.Items.Clear();

			if (sender == gameControl.map.mapBox)
			{
				contextMenu.Items.Add(unitMenu);
				contextMenu.Items.Add(buildingMenu);
			}
			//else if (sender == gameControl.unitArray[gameControl.SelectedTile().X, gameControl.SelectedTile().Y].unitBox)
			//{
			//	contextMenu.Items.Add(upgradeMenu);
			//	upgradeMenu.DropDownItems.Clear();
			//	FillUpgradeMenu();
			//	contextMenu.Items.Add(moveMenu);
			//}
			else if (gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] != null)
			{
				if (sender == gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].unitBox)
				{
					contextMenu.Items.Add(upgradeMenu);
					upgradeMenu.DropDownItems.Clear();
					FillUpgradeMenu();
					contextMenu.Items.Add(moveMenu);
				}
			}
			else if (gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] != null)
			{
				if (sender == gameControl.structureArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].structureBox)
				{
					contextMenu.Items.Add(manageMenu);
					manageMenu.DropDownItems.Clear();
					FillManageMenu();
				}
			}
		}
		public void ShowGameContextMenu(object sender)
		{
			AddMenuItem(sender);
			contextMenu.Show(gameControl.map.mapBox, gameControl.map.GetMapCoord());
		}
	}
}
