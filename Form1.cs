// https://www.youtube.com/watch?v=UhBKeQj7vpI&t=198s
// https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/varieties-of-custom-controls?view=netframeworkdesktop-4.8

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

        // ArraySize needs to be linked to a scroll wheel or textbox.
        public int arraySize = 50;
        public int[] dataArray = new int[50];
        Random numberGenerator = new Random();

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayObject dataGenerator = new ArrayObject();
            int[] dataArray = dataGenerator.GenerateData(arraySize);

            chart1.Series["Data"].Points.Clear();

            int placement = 0;
            foreach (int dataPoint in dataArray)
            {
                this.chart1.Series["Data"].Points.AddXY(placement, dataPoint);
                placement += 1;
            }
        }
    }




    public class ArrayObject
    {
        public int[] GenerateData(int datasetSize)
        {
            Random number = new Random();
            int[] dataArray = new int[datasetSize];
            for (int i = 0; i < datasetSize; i++)
            {
                dataArray[i] = number.Next(0, 99);
            }

            return dataArray;
        }
    }
}