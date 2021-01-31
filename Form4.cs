using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Game
{
    public partial class Form4 : Form
    {
        private Form4 form4;
        private Random rnd = new Random();

        private PictureBox baseLayer;
        private Map map;

        public int FormWidth;
        public int FormHeight;

        private int mapWidth;
        private int mapLength;
        private int tileSize = 48;
        private int seed;
        private float scale = 1.0f;
        private int[] pNoiseArray;

        public Form4(string x, string y)
        {
            InitializeComponent();
            mapWidth = Convert.ToInt16(x);
            mapLength = Convert.ToInt16(y);
            form4 = this;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SelectResolution();
            this.Width = FormWidth;
            this.Height = FormHeight;

            baseLayer = new PictureBox()
            {
                Size = new Size(FormWidth, FormHeight),
            };
            Controls.Add(baseLayer);
            baseLayer.SendToBack();

            map = new Map(baseLayer, mapWidth, mapLength);

            menuStrip.BringToFront();

            CreateHandlers();
        }

        private void CreateHandlers()
        {
            baseLayer.MouseDown += map.MouseDown;
            baseLayer.MouseMove += map.MouseMove;
            map.mapBox.MouseDown += map.MouseDown;
            map.mapBox.MouseMove += map.MouseMove;
        }

		private void SelectResolution() //Sets screen size from selection in settings menu, (default 1280 x 960)
        {
            Form3 f3 = new Form3(); // ***Not currently working, returns null / goes to default
            switch (f3.GetResolution())
            {
                case 0:
                    FormWidth = 720;
                    FormHeight = 480;
                    break;
                case 1:
                    FormWidth = 800;
                    FormHeight = 600;
                    break;
                case 2:
                    FormWidth = 1024;
                    FormHeight = 768;
                    break;
                case 3:
                    FormWidth = 1152;
                    FormHeight = 864;
                    break;
                case 4:
                    FormWidth = 1280;
                    FormHeight = 800;
                    break;
                case 5:
                    FormWidth = 1280;
                    FormHeight = 960;
                    break;
                case 6:
                    FormWidth = 1280;
                    FormHeight = 1024;
                    break;
                case 7:
                    FormWidth = 1440;
                    FormHeight = 900;
                    break;
                case 8:
                    FormWidth = 1600;
                    FormHeight = 1200;
                    break;
                case 9:
                    FormWidth = 1680;
                    FormHeight = 1050;
                    break;
                case 10:
                    FormWidth = 1920;
                    FormHeight = 1080;
                    break;
                case 11:
                    FormWidth = 2715;
                    FormHeight = 1527;
                    break;
                case 12:
                    FormWidth = 3840;
                    FormHeight = 2160;
                    break;
                default:
                    FormWidth = 1280;
                    FormHeight = 960;
                    break;
            }
        }


        private void drawMap(int width, int length) //Creates bitmap image to set as map in pictureBox
        {
            seed = rnd.Next();
            for (float i = 0f; i < length; i++) //Loop through Perlin Noise algorithm to fill the array
            {
                for (float j = 0f; j < width; j++)
                {
                    float x = j + seed / width * scale;
                    float y = i + seed / length * scale;
                    //float pNoise = Mathf.PerlinNoise(x, y); //Perlin Noise Function, pass in x and y coord
                    int pNoise = rnd.Next(0, 100); //Temp code, without perlin function
                    pNoiseArray[(int)i * length + (int)j] = pNoise; //2d map to 1d array
                }
            }
        }



        private void centreToolStripMenuItem_Click(object sender, EventArgs e) //centre map
        {
            map.CentreMap();
        }
        private void right50ToolStripMenuItem_Click(object sender, EventArgs e) //move map right
        {
            
        }
        private void down50ToolStripMenuItem_Click(object sender, EventArgs e) //move map down
        {
            
        }

        private void createUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point tileCoord = new Point(rnd.Next(0, 432), rnd.Next(0, 432));
            Unit unit = new Unit(sender, map.mapBox, tileCoord);
        }
        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //Quit to main menu
        {
            this.Hide();
            Form form1 = new Form1();
            form1.ShowDialog();
        }

		
	}
}
