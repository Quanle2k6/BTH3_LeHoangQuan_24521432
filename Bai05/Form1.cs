using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            double num1, num2;
            if (string.IsNullOrEmpty(textBox1.Text))
                num1 = 0;
            else
                num1 = Convert.ToDouble(textBox1.Text);

            if (string.IsNullOrEmpty(textBox2.Text))
                num2 = 0;
            else
                num2 = Convert.ToDouble(textBox2.Text);

            double num3 = num1 + num2;

            textBox3.Text = Convert.ToString(num3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double num1, num2;
            if (string.IsNullOrEmpty(textBox1.Text))
                num1 = 0;
            else
                num1 = Convert.ToDouble(textBox1.Text);

            if (string.IsNullOrEmpty(textBox2.Text))
                num2 = 0;
            else
                num2 = Convert.ToDouble(textBox2.Text);

            double num3 = num1 - num2;

            textBox3.Text = Convert.ToString(num3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double num1, num2;
            if (string.IsNullOrEmpty(textBox1.Text))
                num1 = 0;
            else
                num1 = Convert.ToDouble(textBox1.Text);

            if (string.IsNullOrEmpty(textBox2.Text))
                num2 = 0;
            else
                num2 = Convert.ToDouble(textBox2.Text);

            double num3 = num1 * num2;

            textBox3.Text = Convert.ToString(num3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double num1, num2;
            if (string.IsNullOrEmpty(textBox1.Text))
                num1 = 0;
            else
                num1 = Convert.ToDouble(textBox1.Text);

            if (string.IsNullOrEmpty(textBox2.Text))
                num2 = 0; 
            else
                num2 = Convert.ToDouble(textBox2.Text);

            if (num2 == 0)
            {
                textBox3.Text = "Cannot divide by zero";
                return;
            }
            double num3 = num1 / num2;

            textBox3.Text = Convert.ToString(num3);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '-')
            {
                if (textBox.SelectionStart == 0 && !textBox2.Text.Contains("-"))
                    return;
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.')
            {
                if (!textBox.Text.Contains("."))
                    return;
                e.Handled = true;
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox2 = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '-')
            {
                if (textBox2.SelectionStart == 0 && !textBox2.Text.Contains("-"))
                    return;
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.')
            {
                if (!textBox2.Text.Contains("."))
                    return;
                e.Handled = true;
                return;
            }
            e.Handled = true;

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrEmpty(tb.Text))
            {
                errorInput1.SetError(textBox1, string.Empty);
                return;
            }
            if (double.TryParse(tb.Text, out double d))
            {
                errorInput1.SetError(textBox1, string.Empty);
                return;
            }
            else
            {
                errorInput1.SetError(textBox1, "Nhập không đúng số thực!");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb1 = sender as TextBox;
            if (string.IsNullOrEmpty(tb1.Text))
            {
                errorInput1.SetError(textBox2, string.Empty);
                return;
            }
            if (double.TryParse(tb1.Text, out double d))
            {
                errorInput1.SetError(textBox2, string.Empty);
                return;
            }
            else
            {
                errorInput1.SetError(textBox2, "Nhập không đúng số thực!");
            }
        }
    }
}
