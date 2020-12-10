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

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (validInput1 == true && validInput2 == true)
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1();
            form1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validInput1 = CheckInput(textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validInput2 = CheckInput(textBox2);
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
                else if (InputNum < 1 || InputNum > 100)
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
