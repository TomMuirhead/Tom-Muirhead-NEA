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
        Random rnd = new Random();
        private int FormWidth = 1280;
        private int FormHeight = 720;
        private int width;
        private int length;
        private int tileSize = 50;
        private int seed;
        private float scale = 1.0f;
        int[] pNoiseArray;
        PictureBox picBox;

        public Form4(string x, string y)
        {
            InitializeComponent();
            width = Convert.ToInt16(x);
            length = Convert.ToInt16(y);
            //FormWidth = ; Resize window options
            //FormHeight = ;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Width = FormWidth;
            this.Height = FormHeight;
            DrawPictureBox();
        }

        private void DrawPictureBox()
        {
            picBox = pictureBox1;
            picBox.Size = new Size(tileSize * width, tileSize * length);
            picBox.BackColor = Color.ForestGreen;
            CentreMap();
        }

        private void drawMap(int width, int length)
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

        private Point mouseDownLocation;
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                mouseDownLocation = e.Location;
            }
        }
        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && CheckOnScreen())
            {
                picBox.Left += (e.X - mouseDownLocation.X) / tileSize;
                picBox.Top += (e.Y - mouseDownLocation.Y) / tileSize;
            }
        }
        private bool CheckOnScreen()
        {
            bool onScreen;
            if
                (
                   (picBox.Bottom > tileSize)
                && (picBox.Top < (this.Height - tileSize))
                && (picBox.Right > tileSize)
                && (picBox.Left < (this.Width - tileSize))
                )
            {
                onScreen = true;
            }
            else
            {
                onScreen = false;
            }
            return onScreen;
        }

        private void centreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CentreMap();
        }
        private void CentreMap()
        {
            picBox.Left = (FormWidth / 2) - (picBox.Width / 2);
            picBox.Top = (FormHeight / 2) - (picBox.Height / 2);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1();
            form1.ShowDialog();
        }

        private void right50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheckOnScreen())
                picBox.Left += 50;
        }

        private void down50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheckOnScreen())
                picBox.Top += 50;
        }
    }
}
