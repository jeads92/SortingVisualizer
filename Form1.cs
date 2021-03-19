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
        protected int[] _dataSet = new int[100];

        public Form1()
        {
            InitializeComponent();
            // Adds the array to a label for the user to see.
            string arrayText = "";
            foreach(int element in _dataSet)
            {
                arrayText += element;
                arrayText += ",";
            }
            intTestLabel.Text = arrayText;
        }
        // Initializes size of the array.
        public int arraySize;

        // updates the label to show the current value that trackBar1 has selected.
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbarValueLabel.Text = trackBar1.Value.ToString();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            Sorting.Algorithms.InsertionSort(_dataSet);
            string arrayText = "";
            foreach (int element in _dataSet)
            {
                arrayText += element;
                arrayText += ",";
            }
            intTestLabel.Text = arrayText;

            chart1.Series["Data"].Points.Clear();
            int placement = 0;
            foreach (int dataPoint in _dataSet)
            {
                this.chart1.Series["Data"].Points.AddXY(placement, dataPoint);
                placement += 1;
            }
        }

        // Generates the array and links it to the chart for visualization.
        private void createArray_Click(object sender, EventArgs e)
        {
            // The dataArray takes in the arraySize and returns an array
            // which is used to populate the chart.
            arraySize = trackBar1.Value;
            ArrayObject dataGenerator = new ArrayObject();
            int[] dataArray = dataGenerator.GenerateData(arraySize);

            int replaceIndex = 0; // Could probably use for loop to write this in one line below.
            foreach(int replacePoint in _dataSet)
            {
                _dataSet[replaceIndex] = 0;
                replaceIndex += 1;
            }

            // updates the primary array with the randomly generated values.
            int count = 0; // could use for loop to condense.
            foreach(int point in dataArray)
            {
                _dataSet[count] = point;
                count += 1;
            }

            // clears the chart and updates it with the new array.
            chart1.Series["Data"].Points.Clear();
            int placement = 0;
            foreach (int dataPoint in _dataSet)
            {
                this.chart1.Series["Data"].Points.AddXY(placement, dataPoint);
                placement += 1;
            }

            // updates the label. This will be removed later. For debugging purposes only.
            string arrayText = "";
            foreach (int element in _dataSet)
            {
                arrayText += element;
                arrayText += ",";
            }
            intTestLabel.Text = arrayText;
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


namespace Sorting
{
    public class Algorithms
    {
        public static void InsertionSort(int[] intArray)
        {
            foreach (int number in intArray)
            {
                Console.Write(number);
                Console.Write(", ");
            }

            Console.WriteLine();
            int i = 1;
            int j = 1;
            int placeHolder = 1;
            while (i < intArray.Length)
            {
                j = i;
                while (j > 0 && intArray[j - 1] > intArray[j])
                {
                    placeHolder = intArray[j];
                    intArray[j] = intArray[j - 1];
                    intArray[j - 1] = placeHolder;
                    j--;
                }
                i++;
            }
            foreach (int item in intArray)
            {
                Console.Write(item);
                Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}