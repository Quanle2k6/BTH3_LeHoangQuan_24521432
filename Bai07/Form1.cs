using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class Form1 : Form
    {
        List<Button> buttonA = new List<Button>(5);
        List<Button> buttonB = new List<Button>(5);
        List<Button> buttonC = new List<Button>(5);


        public Form1()
        {
            InitializeComponent();

            buttonC.Add(button1);
            buttonC.Add(button2);
            buttonC.Add(button3);
            buttonC.Add(button4);
            buttonC.Add(button5);

            buttonB.Add(button6);
            buttonB.Add(button7);
            buttonB.Add(button8);
            buttonB.Add(button9);
            buttonB.Add(button10);

            buttonA.Add(button11);
            buttonA.Add(button12);
            buttonA.Add(button13);
            buttonA.Add(button14);
            buttonA.Add(button15);

            textBox1.Text = null;
        }
        private void buttonSeat_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Blue;
            }
            else if (button.BackColor == Color.Blue)
            {
                button.BackColor = Color.White;
            }
            else
                MessageBox.Show("Vi tri da duoc ban!\n");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            double price = 0;
            foreach(Button button in buttonA)
            {
                if (button.BackColor == Color.Blue)
                {
                    price += 5000; 
                    button.BackColor = Color.Yellow;
                }
            }
            foreach(Button button in buttonB)
            {
                if (button.BackColor == Color.Blue)
                {
                    price += 6500;
                    button.BackColor = Color.Yellow;
                }
            }
            foreach (Button button in buttonC)
            {
                if (button.BackColor == Color.Blue)
                {
                    price += 8000;
                    button.BackColor = Color.Yellow;
                }
            }
            textBox1.Text = $"{price}";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            foreach (Button button in buttonA)
            {
                if (button.BackColor == Color.Blue)
                    button.BackColor = Color.White;
            }
            foreach (Button Button in buttonB)
            {
                if (Button.BackColor == Color.Blue)
                    Button.BackColor = Color.White;
            }
            foreach(Button button in buttonC)
            {
                if (button.BackColor == Color.Blue)
                    button.BackColor = Color.White;
            }
            textBox1.Text = "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
