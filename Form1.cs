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
            int[] testArray = new int[] { 250, 500, 420 };
            var x = 0;
            var y = 0;
            var squareSide = 200;
            var buffer = 250;
            base.OnPaint(e);
            SolidBrush myBrush = new SolidBrush(Color.Red);
            SolidBrush myBrush2 = new SolidBrush(Color.Green);
            SolidBrush myBrush3 = new SolidBrush(Color.Black);
            SolidBrush[] brushArray = new SolidBrush[] { myBrush, myBrush2, myBrush3 };
            int count = 0;

            foreach (int data in testArray)
            {

                e.Graphics.FillRectangle(brushArray[count], new Rectangle(x, y, squareSide, data));
                count += 1;
                x += buffer;
            }
        }
    }

    public class ArrayObject
    {

        private int[] _myArray;
        public ArrayObject(int datasetSize)
        {
            Random number = new Random();
            _myArray = new int[datasetSize];
            for (int i = 0; i < datasetSize; i++)
            {
                _myArray[i] = number.Next(0, 99);
            }
        }

    }
}