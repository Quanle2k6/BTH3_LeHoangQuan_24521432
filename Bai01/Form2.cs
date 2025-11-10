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
    public partial class Form2 : Form
    {
        private Form1 mainform;
        public Form2(Form1 form)
        {
            InitializeComponent();
            mainform = form;
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con construction.");
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con activated.");
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con deactivated.");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con load.");
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con shown.");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con closing.");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            DateTime now = DateTime.Now;
            mainform.listbox.Items.Add(now + ": Form con closed.");
        }
    }
}
