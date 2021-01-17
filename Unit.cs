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
		public enum UnitType
		{
			Unknown, Unit1, Unit2, Unit3, Unit4, Unit5, Unit6,
		}
		private bool ground;
		private Point tileCoord;
		private int tileSize;

		public Unit(UnitType inputChoice)//Create a sprite on the map at chosen tile location
		{
			unitChoice = inputChoice;
			unitBox = new PictureBox()
			{
				Size = new Size(tileSize, tileSize),
				Location = tileCoord,
				Image = GetSprite(),
			};
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

		private UnitType GetUnit() //Will return which unit should be drawn
		{
			//Get user input from public Getter
			return unitChoice;
		}


	}
}
