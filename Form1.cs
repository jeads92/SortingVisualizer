﻿using System;
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
        int timeRunning;

        public Form1()
        {
            InitializeComponent();
            UpdateLabel();
            testTimer.Start();
        }

        private void UpdateLabel()
        {
            // Adds the array to a label for the user to see.
            string arrayText = "";
            int newLineCount = 0;
            foreach (int element in _dataSet)
            {
                arrayText += element;
                arrayText += ",";
                newLineCount += 1;
                if (newLineCount == 10)
                {
                    arrayText += '\n';
                    newLineCount = 0;
                }
            }
            intTestLabel.Text = arrayText;
        }

        // Initializes size of the array.
        public int arraySize;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbarValueLabel.Text = trackBar1.Value.ToString();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            // Tests to see if the selection box has been selected.
            if (algorithmBox.SelectedItem is null)
            {
                return;
            }
            else
            {
                switch (algorithmBox.SelectedItem.ToString())
                {
                    case "Insertion Sort":
                        Sorting.Algorithms.InsertionSort(_dataSet);
                        break;
                    case "Bubble Sort":
                        Sorting.Algorithms.BubbleSort(_dataSet);
                        break;
                    case "Cocktail Shaker Sort":
                        Sorting.Algorithms.CocktailSort(_dataSet);
                        break;
                    case "Merge Sort":
                        Sorting.Algorithms.MergeSort MergeObject = new Sorting.Algorithms.MergeSort();
                        MergeObject.sort(_dataSet, 0, _dataSet.Length - 1);
                        break;
                    case null:
                        Console.WriteLine("object set to null reference");
                        break;
                }

                UpdateLabel();
            }
            

            // Clears the chart and then post the new array to the chart.
            chart1.Series["Data"].Points.Clear();
            int placement = 0;
            foreach (int point in _dataSet)
            {
                this.chart1.Series["Data"].Points.AddXY(placement, point);
                placement += 1;
            }
        }

        // Generates the array and links it to the chart for visualization.
        private void createArray_Click(object sender, EventArgs e)
        {
            // The dataArray takes in the arraySize and returns an array
            // which is used to populate the chart.
            arraySize = trackBar1.Value;
            NumberGenerator dataRandomizer = new NumberGenerator();
            int[] dataArray = dataRandomizer.Fill(arraySize);

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
            int placement = 0; // Replace with a for loop to reduce code lines.
            foreach (int dataPoint in _dataSet)
            {
                this.chart1.Series["Data"].Points.AddXY(placement, dataPoint);
                placement += 1;
            }

            UpdateLabel();
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            timeRunning += 1;
            timeLabel.Text = $"Time Running {Convert.ToString(timeRunning)} seconds.";
        }

        private void algorithmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameSpaceTest.Text = algorithmBox.SelectedItem.ToString();
        }
    }

    public class NumberGenerator
    {
        public int[] Fill(int datasetSize)
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
        }

        public static void BubbleSort(int[] intArray)
        {
            int n = intArray.Length;
            for(int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (intArray[j] > intArray[j+1])
                    {
                        int placeHolder = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = placeHolder;
                    }
                }
            }
        }

        public static void CocktailSort(int[] intArray)
        {
            bool swapped = true;
            int start = 0;
            int end = intArray.Length;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                { 
                    if (intArray[i] > intArray[i + 1])
                    {
                        int placeHolder = intArray[i];
                        intArray[i] = intArray[i + 1];
                        intArray[i + 1] = placeHolder;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
                swapped = false;
                end = end - 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (intArray[i] > intArray[i + 1])
                    {
                        int temp = intArray[i];
                        intArray[i] = intArray[i + 1];
                        intArray[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
        }

        public class MergeSort
        {
            public void merge(int[] arr, int l, int m, int r)
            {
                // Sizes of the two array that will be merged.
                int arraySizeOne = m - l + 1;
                int arraySizeTwo = r - m;

                // Temporary Arrays
                int[] tempArrayOne = new int[arraySizeOne];
                int[] tempArrayTwo = new int[arraySizeTwo];
                int firstArrayIndex, secondArrayIndex;

                // Copy data to temp arrays
                for (firstArrayIndex = 0; firstArrayIndex < arraySizeOne; ++firstArrayIndex)
                    tempArrayOne[firstArrayIndex] = arr[l + firstArrayIndex];
                for (secondArrayIndex = 0; secondArrayIndex < arraySizeTwo; ++secondArrayIndex)
                    tempArrayTwo[secondArrayIndex] = arr[m + 1 + secondArrayIndex];

                // Merge the temp arrays

                // Initial indexes of the sub arrays
                firstArrayIndex = 0;
                secondArrayIndex = 0;

                // Initial index of merged subarry array
                int subArrayIndex = l;
                while (firstArrayIndex < arraySizeOne && secondArrayIndex < arraySizeTwo)
                {
                    if (tempArrayOne[firstArrayIndex] <= tempArrayTwo[secondArrayIndex])
                    {
                        arr[subArrayIndex] = tempArrayOne[firstArrayIndex];
                        firstArrayIndex++;
                    }
                    else
                    {
                        arr[subArrayIndex] = tempArrayTwo[secondArrayIndex];
                        secondArrayIndex++;
                    }
                    subArrayIndex++;
                }

                // Copy remaining elements tempArrayOne
                while (firstArrayIndex < arraySizeOne)
                {
                    arr[subArrayIndex] = tempArrayOne[firstArrayIndex];
                    firstArrayIndex++;
                    subArrayIndex++;
                }

                // Copy remaining elements tempArrayTwo
                while (secondArrayIndex < arraySizeTwo)
                {
                    arr[subArrayIndex] = tempArrayTwo[secondArrayIndex];
                    secondArrayIndex++;
                    subArrayIndex++;
                }
            }

            // Primary sorting function.
            public void sort(int[] arr, int l, int r)
            {
                if (l < r)
                {
                    // This find the middle point
                    int m = l + (r - l) / 2;

                    // This sorts the first and second halves
                    sort(arr, l, m);
                    sort(arr, m + 1, r);

                    // Merges the sorted halves
                    merge(arr, l, m, r);
                }
            }
        }
    }
}