using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        private InstalledFontCollection installFont;
        private Random random = new Random();
        private const string TextToDraw = "Paint Event";

        private Font CustomFont;
        private SolidBrush CustomBrush;

        private int NewRandomX = 0;
        private int NewRandomY = 0;

        public Form1()
        {
            InitializeComponent();
            this.ButtonDraw.Click += ButtonDraw_Click;
            this.Paint += new PaintEventHandler(Form1_Paint);

            installFont = new InstalledFontCollection();

            BackColor = Color.White;
        }

       

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            int clientWidth = ClientSize.Width;
            int clientHeight = ClientSize.Height;

            int buttonSafeHeight = ButtonDraw.Bottom + 10;

            NewRandomX = random.Next(Math.Max(1, clientWidth - 200));
            NewRandomY = random.Next(Math.Max(1, (clientHeight - buttonSafeHeight) - 150));
            NewRandomY += buttonSafeHeight;

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (CustomFont != null)
                CustomFont.Dispose();
            if (CustomBrush != null) 
                CustomBrush.Dispose();

            FontFamily[] FontFamilies = installFont.Families;
            if (FontFamilies.Length == 0)
                CustomFont = new Font("Arial", 20, FontStyle.Regular);
            else
            {
                FontFamily RandomFontFamily = FontFamilies[random.Next(FontFamilies.Length)];
                int FontSize = random.Next(10, 100);
                FontStyle fontStyle = FontStyle.Regular;

                CustomFont = new Font(RandomFontFamily, FontSize, fontStyle);
            }
            CustomBrush = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));

            SizeF TextSize = e.Graphics.MeasureString(TextToDraw, CustomFont);
            int clientWidth = ClientSize.Width;
            int clientHeight = ClientSize.Height;

            int ButtonSafeHeight = ButtonDraw.Bottom + 5;

            int FinalX = Math.Min(NewRandomX, clientWidth - (int)TextSize.Width);
            int FinalY = Math.Min(NewRandomY, clientHeight - (int)TextSize.Height);

            FinalX = Math.Max(0, FinalX);
            FinalY = Math.Max(ButtonSafeHeight, FinalY);

            e.Graphics.Clear(BackColor);
            e.Graphics.DrawString(TextToDraw, CustomFont, CustomBrush, FinalX, FinalY);
        }

        
    }
}
