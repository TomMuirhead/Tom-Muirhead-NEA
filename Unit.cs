using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;
using System.Drawing;

namespace NEA_Game
{
	class Unit
	{
		private GameControl gameControl;
		public PictureBox unitBox;
		private UnitType unitChoice;
		public enum UnitType
		{
			Unknown, Unit1, Unit2, Unit3, Unit4, Unit5, Unit6,
		}
		private bool ground;
		public Point mapCoord;

		public Unit(object sender, GameControl baseControl, Point coord)//Create a sprite on the map at chosen tile location
		{
			gameControl = baseControl;
			unitChoice = GetUnit(sender);
			mapCoord = coord;
			IsGround();
			unitBox = new PictureBox()
			{
				Size = new Size(gameControl.map.GetTileSize(), gameControl.map.GetTileSize()),
				Location = mapCoord,
				SizeMode = PictureBoxSizeMode.StretchImage,
				Image = GetSprite(),
				BackColor = Color.Transparent,
			};
			gameControl.map.mapBox.Controls.Add(unitBox);

			Handlers();
		}

		public void Handlers()
		{
			unitBox.MouseDown += gameControl.mouseControl.MouseDown;
			unitBox.MouseMove += gameControl.mouseControl.MouseMove;
		}


		public void MoveUnit(GameControl baseControl, Point newCoord)
		{
			gameControl = baseControl;
			Point prevTile = gameControl.GetActiveUnit();

			gameControl.unitArray[prevTile.X, prevTile.Y].unitBox.Location = newCoord;
			gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y] = gameControl.unitArray[prevTile.X, prevTile.Y];
			gameControl.unitArray[prevTile.X, prevTile.Y] = null;
		}

		public void UpgradeUnit(object sender, GameControl baseControl)
		{
			gameControl = baseControl;
			unitChoice = GetUnit(sender);
			IsGround();
			gameControl.unitArray[gameControl.map.SelectedTile().X, gameControl.map.SelectedTile().Y].unitBox.Image = GetSprite();
		}

		public void Kill(GameControl baseControl, Point tileCoord)
		{
			gameControl = baseControl;
			gameControl.map.mapBox.Controls.Remove(gameControl.structureArray[tileCoord.X, tileCoord.Y].structureBox);
			gameControl.structureArray[tileCoord.X, tileCoord.Y] = null;
		}

		private Bitmap GetSprite() //Get the sprite image based on the unitChoice
		{
			Bitmap sprite;

			switch (unitChoice)
			{
				case UnitType.Unit1:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Unit1");
					break;
				case UnitType.Unit2:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Unit2");
					break;
				case UnitType.Unit3:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Unit3");
					break;
				case UnitType.Unit4:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Unit4");
					break;
				case UnitType.Unit5:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Unit5");
					break;
				case UnitType.Unit6:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Unit6");
					break;
				default:
					sprite = null; //No error catch here, will be done in input side
					break;
			}
			return sprite;
		}

		private UnitType GetUnit(object sender) //Will return which unit should be drawn
		{
			UnitType inputChoice;
			string senderName = ((ToolStripMenuItem)sender).Text;
			switch (senderName)
			{
				case "Unit 1":
					inputChoice = UnitType.Unit1;
					break;
				case "Unit 2":
					inputChoice = UnitType.Unit2;
					break;
				case "Unit 3":
					inputChoice = UnitType.Unit3;
					break;
				case "Unit 4":
					inputChoice = UnitType.Unit4;
					break;
				case "Unit 5":
					inputChoice = UnitType.Unit5;
					break;
				case "Unit 6":
					inputChoice = UnitType.Unit6;
					break;
				default:
					inputChoice = UnitType.Unknown;
					break;
			}

			return inputChoice;
		}

		public UnitType GetUnitType()
		{
			return unitChoice;
		}

		private void IsGround()
		{
			switch (unitChoice)
			{
				case UnitType.Unit1:
					ground = true;
					break;
				case UnitType.Unit2:
					ground = true;
					break;
				case UnitType.Unit3:
					ground = true;
					break;
				case UnitType.Unit4:
					ground = true;
					break;
				case UnitType.Unit5:
					ground = false;
					break;
				case UnitType.Unit6:
					ground = false;
					break;
				default:
					break;
			}
		}

	}
}
