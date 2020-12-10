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
        private int width;
        private int length;
        private int seed;
        private float scale = 1.0f;
        int[] pNoiseArray;
        PictureBox picBox;

        public Form4(string x, string y)
        {
            InitializeComponent();
            width = Convert.ToInt16(x);
            length = Convert.ToInt16(y);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            drawPicBox(width, length);
        }

        private void drawPicBox(int width, int length)
        {
            picBox = new PictureBox
            {
                Size = new Size(50*width, 50*length),
                Location = new Point(60, 60),
            };
            picBox.BackColor = Color.ForestGreen;
            Controls.Add(picBox);
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

        private Point mouseDownLocation, mouseUpLocation;
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                mouseDownLocation = e.Location;
            }
        }
        private void Form4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mouseUpLocation = e.Location;
            }
        }
        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            picBox.Left += (mouseUpLocation.X - mouseDownLocation.X);
            picBox.Top += (mouseUpLocation.Y - mouseDownLocation.Y);
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1();
            form1.ShowDialog();
        }

        private void right50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picBox.Left += 50;
        }
    }
}
