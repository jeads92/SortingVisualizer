﻿// https://www.youtube.com/watch?v=UhBKeQj7vpI&t=198s
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

        // Initializes an array with a base starting point of 50.
        public int arraySize;
        Random numberGenerator = new Random();


        // Generates the array and links it to the chart for visualization.
        private void button2_Click(object sender, EventArgs e)
        {
            // the dataArray takes in the arraySize and returns an array
            // which is used to populate the chart.
            arraySize = trackBar1.Value;
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

        // updates the label to show the current value that trackBar1 has selected.
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbarValueLabel.Text = trackBar1.Value.ToString();
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
    class Algorithms
    {
        static void InsertionSort(int[] intArray)
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