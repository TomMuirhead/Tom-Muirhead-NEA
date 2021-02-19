using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Game
{
	class GameControl
	{
		public GameControl(PictureBox ground, int x, int y)
		{
			baselayer = ground;
			mapWidth = x; mapLength = y;

			mouseControl = new MouseControl(this);
			gameMenu = new GameContextMenu(this);
			map = new Map(this, mapWidth, mapLength);

			baselayer.MouseDown += mouseControl.MouseDown;
			baselayer.MouseMove += mouseControl.MouseMove;
		}

		private int mapWidth; private int mapLength;
		public PictureBox baselayer;  public Map map; public GameContextMenu gameMenu; public MouseControl mouseControl; public Unit unit;




	}
}
