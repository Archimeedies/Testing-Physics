using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bouncy_balls
{
    public partial class Form1 : Form
    {
        // client size
        const int WIDTH = 800;
        const int HEIGHT = 600;

        // graphics
        private Bitmap offScreenBitmap;
        private Graphics offScreenGraphics;
        private Graphics graphics;

        // classes
        private Controller controller;
        public Form1()
        {
            InitializeComponent();
            this.Width = WIDTH;
            this.Height = HEIGHT;

            // initializing graphics
            offScreenBitmap = new Bitmap(this.Width, this.Height);
            offScreenGraphics = Graphics.FromImage(offScreenBitmap);
            graphics = this.CreateGraphics();
            controller = new Controller(offScreenGraphics, ClientSize);

            timer1.Interval = 20; // 16 should be approximately 60 FPS, set to 1 for more updates per second
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            offScreenGraphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
            controller.Update();
            graphics.DrawImage(offScreenBitmap, 0, 0);
        }
    }
}
