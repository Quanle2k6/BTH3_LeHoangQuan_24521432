using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public ListBox listbox => listBox1;
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha construction.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm2();
        }
        public void ShowForm2()
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha activated.");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha deactivated.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha load");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha deactivated.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha closing.");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DateTime now = DateTime.Now;
            listBox1.Items.Add(now.ToString() + ": Form cha closed");

        }
    }
}
