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
		private PictureBox unitBox;
		private Bitmap unitSprite;
		private UnitType unitChoice;
		private enum UnitType
		{
			Unknown, Unit1, Unit2, Unit3, Unit4, Unit5, Unit6,
		}
		private bool ground;
		private Point tileCoord;
		private int tileSize;

		public Unit(object sender, PictureBox mapBox, Point tileCoord)//Create a sprite on the map at chosen tile location
		{
			Random rnd = new Random();
			unitChoice = GetUnit(sender);
			unitBox = new PictureBox()
			{
				Size = new Size(48, 48),//(tileSize, tileSize),
				Location = tileCoord,//tileCoord,
				SizeMode = PictureBoxSizeMode.StretchImage,
				Image = GetSprite(),
			};
			mapBox.Controls.Add(unitBox);
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


	}
}
