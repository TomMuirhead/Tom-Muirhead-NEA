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
    public partial class Form2 : Form
    {
        private bool validInput1 = false, validInput2 = false;
        private Color invalidColor = Color.Red;

        public Form2()
        {
            InitializeComponent();
        }
        
        // When "Play" Button is clicked
        private void PlayButton_Click(object sender, EventArgs e)
        {
            // Check to see if all inputs are valid before starting game
            if (validInput1 == true && validInput2 == true)
            {
                // Hide the Menu Screen
                // Creates new Game Screen and pass the inputs as arguements to create the map size
                this.Hide();
                Form form4 = new Form4(textBox1.Text, textBox2.Text);
                form4.ShowDialog();
            }
            else
            {
                // "Invalid Input" Text appears
                // Doesn't allow user to play
                label3.Visible = true;
            }
        }
        
        // When "Back" button is clicked
        private void BackButton_Click(object sender, EventArgs e)
        {
            // Hide the Menu Screen
            // Go back to Main Menu Screen
            this.Hide();
            Form form1 = new Form1();
            form1.ShowDialog();
        }
        
        // Called whenever text is changed
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validInput1 = CheckInput(textBox1);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validInput2 = CheckInput(textBox2);
        }
        
        // Checks if input is valid
        private bool CheckInput(TextBox textbox)
        {
            bool validInput = false;
            textbox.BackColor = default(Color); // reset textbox colour to default
            if (textbox.Text != "") // Do nothing if there is no text
            {
                int InputNum;
                bool validNum = Int32.TryParse(textbox.Text, out InputNum);
                if (!validNum) // Check if input is not a number
                {
                    textbox.BackColor = invalidColor;
                    validInput = false;
                }
                else if (InputNum < 1 || InputNum > 100) // Check if input is number out of range
                {
                    textbox.BackColor = invalidColor;
                    validInput = false;
                }
                else // Otherwise input is valid
                {
                    validInput = true;
                }
            }
            // return if input for the changed textbox is valid
            return validInput;
        }
    }
}
