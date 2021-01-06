using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DrawRectangleInt(PaintEventArgs e)
        {

            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 200;

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
        }

    }

    public class VisualizerControl : Control
    {
        private Color[] _colors;
        public Color[] Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
                // Redraw if the array is changed to a new one.
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            // Draw the background.
            g.Clear(BackColor);

            // If the array's null or too small, don't try to draw it.
            if (Colors == null || Colors.Length == 0)
            {
                return;
            }

            // Start drawing squares at (10, 10), moving horizontally
            // for each one, with 5px between them.
            var x = 10;
            var y = 10;
            var squareSide = 20;
            var buffer = 5;

            foreach (var color in Colors)
            {
                using (var b = new SolidBrush(color))
                {
                    g.FillRectangle(b, x, y, squareSide, squareSide);

                    // "move" to the next square
                    x += squareSide + buffer;
                }
            }
        }
    }

}