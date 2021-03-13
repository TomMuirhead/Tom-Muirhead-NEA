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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // When "New Game" button is clicked
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // Hide the Main Menu Screen
            // Create New Game Menu and Open
            this.Hide();
            Form form2 = new Form2();
            form2.ShowDialog();
        }
        
        // When "Settings" button is clicked
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Hide the Main Menu Screen
            // Create Settings Menu and Open
            this.Hide();
            Form form3 = new Form3();
            form3.ShowDialog();
        }
        
        // When "Quit" button is clicked
        private void QuitButton_Click(object sender, EventArgs e)
        {
            // Closes the program
            Application.Exit();
        }

    }
}
