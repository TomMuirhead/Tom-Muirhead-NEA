using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Play_menu_validation_fail
{
    public partial class Form1 : Form
    {
        private bool validInput = false;
        private Color invalidColor = Color.Red;

        public Form1()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (validInput == true)
            {
                this.Hide();
                Form form4 = new Form4(textBox1.Text, textBox2.Text);
                form4.ShowDialog();
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validInput = CheckInput(textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validInput = CheckInput(textBox2);
        }

        private bool CheckInput(TextBox textbox)
        {
            bool validInput = false;
            textbox.BackColor = default(Color);
            if (textbox.Text != "")
            {
                int InputNum;
                bool validNum = Int32.TryParse(textbox.Text, out InputNum);
                if (!validNum)
                {
                    textbox.BackColor = invalidColor;
                    validInput = false;
                }
                else if (InputNum < 10 || InputNum > 100)
                {
                    textbox.BackColor = invalidColor;
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            }
            return validInput;
        }
    }
}
