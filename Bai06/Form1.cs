using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        private double MemNum = 0;
        private double ResultValue = 0;
        private string operationPerform;
        private bool isOperationPerformed = false;
        private bool isSpecialNum = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void number_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || isOperationPerformed || isSpecialNum)
                textBox1.Clear();

            isOperationPerformed = false;
            isSpecialNum = false; 

            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + ".";
            }
            else
                textBox1.Text += button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (operationPerform != null)
            {
                button19.PerformClick();
            }
            else
            {
                if (Double.TryParse(textBox1.Text, out double currentValue))
                {
                    ResultValue = currentValue;
                }
            }

            operationPerform = button.Text;
            label1.Text = ResultValue.ToString() + " " + operationPerform; 
            isOperationPerformed = true;
            isSpecialNum = false;
        }

        private void button19_Click(object sender, EventArgs e) 
        {
            if (!Double.TryParse(textBox1.Text, out double secondOperand))
            {
                ResultValue = 0;
                operationPerform = null;
                label1.Text = "";
                return;
            }

            if (operationPerform == null)
            {
                label1.Text = "";
                return;
            }


            switch (operationPerform)
            {
                case "+":
                    textBox1.Text = (ResultValue + secondOperand).ToString();
                    break;
                case "-":
                    textBox1.Text = (ResultValue - secondOperand).ToString();
                    break;
                case "x":
                    textBox1.Text = (ResultValue * secondOperand).ToString();
                    break;
                case "/":
                    if (secondOperand == 0)
                    {
                        textBox1.Text = "Cannot divide by zero";
                        ResultValue = 0;
                        isOperationPerformed = false;
                        label1.Text = "";
                        operationPerform = null; 
                        return;
                    }
                    textBox1.Text = (ResultValue / secondOperand).ToString();
                    break;
            }

            if (Double.TryParse(textBox1.Text, out double finalResult))
            {
                ResultValue = finalResult;
            }

            label1.Text = "";
            operationPerform = null; 
            isSpecialNum = false;
            isOperationPerformed = true; 
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox1.Text, out double currentValue))
            {
                if (currentValue < 0)
                {
                    textBox1.Text = "Invalid input"; 
                }
                else
                {
                    textBox1.Text = Math.Sqrt(currentValue).ToString();
                }
                isSpecialNum = true;
            }
        }

        private void button9_Click(object sender, EventArgs e) 
        {
            if (Double.TryParse(textBox1.Text, out double currentValue))
            {
                textBox1.Text = (currentValue / 100).ToString();
                isSpecialNum = true;
            }
        }

        private void button14_Click(object sender, EventArgs e) 
        {
            if (Double.TryParse(textBox1.Text, out double currentValue))
            {
                if (currentValue == 0)
                {
                    textBox1.Text = "Cannot divide by zero";
                }
                else
                {
                    textBox1.Text = (1 / currentValue).ToString();
                }
                isSpecialNum = true;
            }
        }

        private void button22_Click(object sender, EventArgs e) // +/-
        {
            if (Double.TryParse(textBox1.Text, out double currentValue))
            {
                textBox1.Text = (currentValue * -1).ToString();
                isSpecialNum = true;
            }
        }


        private void button25_Click(object sender, EventArgs e) 
        {
            if (Double.TryParse(textBox1.Text, out double currentValue))
            {
                MemNum = currentValue;
            }
        }

        private void button26_Click(object sender, EventArgs e) 
        {
            textBox1.Text = MemNum.ToString();
        }

        private void button27_Click(object sender, EventArgs e) 
        {
            MemNum = 0;
        }

        private void button24_Click(object sender, EventArgs e) 
        {
            if (Double.TryParse(textBox1.Text, out double currentValue))
            {
                MemNum += currentValue;
            }
        }


        private void button1_Click(object sender, EventArgs e) 
        {
            if (isSpecialNum || !Double.TryParse(textBox1.Text, out _))
            {
                textBox1.Text = "0";
                isSpecialNum = false;
                return;
            }

            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            textBox1.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            textBox1.Text = "0";
            ResultValue = 0;
            operationPerform = null; 
            label1.Text = " ";      
            isOperationPerformed = false;
            isSpecialNum = false;
        }
    }
}
