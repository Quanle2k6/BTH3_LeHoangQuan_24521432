using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            BackColor = Color.White;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }
    }
}
