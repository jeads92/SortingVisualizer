using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AlgoVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int[] testArray = new int[] { 250, 500 };
            var x = 10;
            var y = 10;
            var squareSide = 20;
            var buffer = 20;
            base.OnPaint(e);
            SolidBrush myBrush = new SolidBrush(Color.Green);
            SolidBrush myBrush2 = new SolidBrush(Color.Red);

            e.Graphics.FillRectangle(myBrush2, new Rectangle(0, 0, 200, 100));
            e.Graphics.FillRectangle(myBrush, new Rectangle(700, 10, 200, 10));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Green);
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}