using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grahpTest
{
    public partial class FormMain : Form
    {
        bool isPressed = false;
        int x1, y1, x2, y2;
        Bitmap snapshot, tempDraw; //снимки экрана

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(snapshot);
            Pen MyPen = new Pen(Color.Black, 5);
            g.DrawLine(MyPen, x1, y1, x2, y2);
            MyPen.Dispose();
            g.Dispose();
            x1 = x2;
            y1 = y2;
        }

        public FormMain()
        {
            InitializeComponent();
            snapshot = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
            tempDraw = (Bitmap)snapshot.Clone();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            x1 = e.X;
            y1 = e.Y;
            tempDraw = (Bitmap)snapshot.Clone();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            snapshot = (Bitmap)tempDraw.Clone();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (isPressed)
            {
                x2 = e.X;
                y2 = e.Y;
                pictureBox1.Invalidate();
                pictureBox1.Update();
            }

        }
    }
}
