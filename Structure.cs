using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NEA_Game
{
	class Structure
	{
		

		private GameControl gameControl;
		public PictureBox structureBox;
		private StructureType structureChoice;
		public enum StructureType
		{
			Unknown, City, Fish, Port, Farm, Lumber, Mine, Road,
		}
		public Point mapCoord;

		public Structure(object sender, GameControl baseControl, Point coord)//Create a sprite on the map at chosen tile location
		{
			gameControl = baseControl;
			structureChoice = GetStructure(sender);
			mapCoord = coord;
			structureBox = new PictureBox()
			{
				Size = new Size(gameControl.map.GetTileSize(), gameControl.map.GetTileSize()),
				Location = mapCoord,
				SizeMode = PictureBoxSizeMode.StretchImage,
				Image = GetSprite(),
				BackColor = Color.Transparent,
			};
			gameControl.map.mapBox.Controls.Add(structureBox);

			Handlers();
		}

		public void Handlers()
		{
			structureBox.MouseDown += gameControl.mouseControl.MouseDown;
			structureBox.MouseMove += gameControl.mouseControl.MouseMove;
		}

		public void Destroy(GameControl baseControl, Point tileCoord)
		{
			gameControl = baseControl;
			gameControl.map.mapBox.Controls.Remove(gameControl.structureArray[tileCoord.X, tileCoord.Y].structureBox);
			gameControl.structureArray[tileCoord.X, tileCoord.Y] = null;
		}

		private Bitmap GetSprite() //Get the sprite image based on the unitChoice
		{
			Bitmap sprite;

			switch (structureChoice)
			{
				case StructureType.City:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("City");
					break;
				case StructureType.Fish:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Fish");
					break;
				case StructureType.Port:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Port");
					break;
				case StructureType.Farm:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Farm");
					break;
				case StructureType.Lumber:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Lumber");
					break;
				case StructureType.Mine:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Mine");
					break;
				case StructureType.Road:
					sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Road");
					break;
				default:
					sprite = null;
					break;
			}

			return sprite;
		}

		private StructureType GetStructure(object sender) //Will return which unit should be drawn
		{
			StructureType inputChoice;
			string senderName = ((ToolStripMenuItem)sender).Text;
			switch (senderName)
			{
				case "City":
					inputChoice = StructureType.City;
					break;
				case "Fish":
					inputChoice = StructureType.Fish;
					break;
				case "Port":
					inputChoice = StructureType.Port;
					break;
				case "Farm":
					inputChoice = StructureType.Farm;
					break;
				case "Lumber":
					inputChoice = StructureType.Lumber;
					break;
				case "Mine":
					inputChoice = StructureType.Mine;
					break;
				case "Road":
					inputChoice = StructureType.Road;
					break;
				default:
					inputChoice = StructureType.Unknown;
					break;
			}

			return inputChoice;
		}

		public StructureType GetStructureType()
		{
			return structureChoice;
		}
	}
}
