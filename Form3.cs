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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        // When "Back" button is clicked
        private void BackButton_Click(object sender, EventArgs e)
        {
            // Hide the Settings screen
            // Go back to Main Menu screen
            this.Hide();
            Form form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
