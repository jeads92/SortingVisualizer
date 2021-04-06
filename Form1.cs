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
        // Initializes size of the array.
        public int arraySize;

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateLabel(int[] selectedArray)
        {
            // Adds the array to a label for the user to see.
            string arrayText = "";
            int newLineCount = 0;
            foreach (int element in selectedArray)
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


        public void updateBarChart(int[] selectedArray)
        {
            chart1.Series["Data"].Points.Clear();
            int placement = 0;
            foreach (int point in selectedArray)
            {
                this.chart1.Series["Data"].Points.AddXY(placement, point);
                placement += 1;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbarValueLabel.Text = trackBar1.Value.ToString();
        }

        public async void InsertionSort(int[] intArray)
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
                    updateBarChart(intArray);
                    UpdateLabel(intArray);
                    await Task.Delay(100);
                }
                i++;
            }
        }

        public async void BubbleSort(int[] intArray)
        {
            int n = intArray.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        int placeHolder = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = placeHolder;
                        updateBarChart(intArray);
                        UpdateLabel(intArray);
                        await Task.Delay(100);
                    }

                }
            }
        }

        public async void CocktailSort(int[] intArray)
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
                        updateBarChart(intArray);
                        UpdateLabel(intArray);
                        await Task.Delay(100);
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
                        updateBarChart(intArray);
                        UpdateLabel(intArray);
                        await Task.Delay(100);
                    }
                }
                start = start + 1;
            }
        }

        public async void heapSort(int[] intArray)
        {
            int n = intArray.Length;

            // This builds the heap and rearranges the array.
            // n / 2 - 1 focuses on heapifying all nodes except the leaf nodes.
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(intArray, n, i);
                updateBarChart(intArray);
                UpdateLabel(intArray);
                await Task.Delay(100);
            }


            // This extracts an element from the heap.
            for (int i = n - 1; i > 0; i--)
            {
                // This moves the current root to end.
                int temp = intArray[0];
                intArray[0] = intArray[i];
                intArray[i] = temp;
                updateBarChart(intArray);
                UpdateLabel(intArray);
                await Task.Delay(100);

                // This calls max heapify on the reduced heap.
                heapify(intArray, i, 0);
            }
        }

        // To heapify a subtree with node i as the root
        // n = size of the heap.
        void heapify(int[] arr, int n, int i)
        {
            int largestNode = i; // Initialize largest as root
            int left = 2 * i + 1; // left = 2*i + 1
            int right = 2 * i + 2; // right = 2*i + 2

            // Replaces the largest value as the left node.
            if (left < n && arr[left] > arr[largestNode])
                largestNode = left;

            // Replaces the largest value as the right node.
            if (right < n && arr[right] > arr[largestNode])
                largestNode = right;

            // This updates the value for the largest node
            // if there was a swap with one of the child nodes.
            if (largestNode != i)
            {
                int swap = arr[i];
                arr[i] = arr[largestNode];
                arr[largestNode] = swap;

                // Recursively heapify any sub trees that
                // underwent a change.
                heapify(arr, n, largestNode);
            }
        }





        private void buttonSort_Click(object sender, EventArgs e)
        {
            //buttonSort.Enabled = false;
            arraySize = trackBar1.Value;
            NumberGenerator dataRandomizer = new NumberGenerator();
            int[] dataArray = dataRandomizer.Fill(arraySize);
            updateBarChart(dataArray);
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
                        InsertionSort(dataArray);
                        break;
                    case "Bubble Sort":
                        BubbleSort(dataArray);
                        break;
                    case "Cocktail Shaker Sort":
                        CocktailSort(dataArray);
                        break;
                    case "Merge Sort":
                        Sorting.Algorithms.MergeSort MergeObject = new Sorting.Algorithms.MergeSort();
                        MergeObject.sort(dataArray, 0, dataArray.Length - 1);
                        break;
                    case "Quick Sort":
                        Sorting.Algorithms.QuickSort quickObject = new Sorting.Algorithms.QuickSort();
                        int arrayLength = dataArray.Length - 1;
                        Sorting.Algorithms.QuickSort.quickSort(dataArray, 0, arrayLength);
                        break;
                    case "Heap Sort":
                        heapSort(dataArray);
                        break;
                    case null:
                        break;
                }
            }
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

        static bool checkSort(int[] data, int arrayLength)
        {
            // Checks if the array is of size 0 or 1.
            if (arrayLength == 0 || arrayLength == 1)
            {
                return true;
            }

            for (int i = 1; i < arrayLength; i++)
            {
                // Returns false if the value to the 
                // right of the index is less than
                // our initial value that we are analyzing.
                if (data[i] > data[i + 1])
                    return false;
            }
            // Indicates a sorted array.
            return true;
        }

    }

}



namespace Sorting
{
    public class Algorithms
    {

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

        public class QuickSort
        {
            // A utility function to swap two elements
            public static void swap(int[] arr, int i, int j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            /* This function takes last element as pivot, places
            the pivot element at its correct position in sorted
            array, and places all smaller (smaller than pivot)
            to left of pivot and all greater elements to right
            of pivot */
            public static int partition(int[] arr, int low, int high)
            {
                // pivot
                int pivot = arr[high];

                // Index of smaller element and
                // indicates the right position
                // of pivot found so far
                int i = (low - 1);

                for (int j = low; j <= high - 1; j++)
                {

                    // If current element is smaller
                    // than the pivot
                    if (arr[j] < pivot)
                    {

                        // Increment index of
                        // smaller element
                        i++;
                        swap(arr, i, j);
                    }
                }
                swap(arr, i + 1, high);
                return (i + 1);
            }

            /* The main function that implements QuickSort
            arr[] --> Array to be sorted,
            low --> Starting index,
            high --> Ending index
            */
            public static void quickSort(int[] arr, int low, int high)
            {
                if (low < high)
                {

                    // pi is partitioning index, arr[p]
                    // is now at right place
                    int pi = partition(arr, low, high);

                    // Separately sort elements before
                    // partition and after partition
                    quickSort(arr, low, pi - 1);
                    quickSort(arr, pi + 1, high);
                }
            }

        }

        public class HeapSort
        {
            public void sort(int[] arr)
            {
                int n = arr.Length;

                // This builds the heap and rearranges the array.
                // n / 2 - 1 focuses on heapifying all nodes except the leaf nodes.
                for (int i = n / 2 - 1; i >= 0; i--)
                    heapify(arr, n, i);

                // This extracts an element from the heap.
                for (int i = n - 1; i > 0; i--)
                {
                    // This moves the current root to end.
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;

                    // This calls max heapify on the reduced heap.
                    heapify(arr, i, 0);
                }
            }

            // To heapify a subtree with node i as the root
            // n = size of the heap.
            void heapify(int[] arr, int n, int i)
            {
                int largestNode = i; // Initialize largest as root
                int left = 2 * i + 1; // left = 2*i + 1
                int right = 2 * i + 2; // right = 2*i + 2

                // Replaces the largest value as the left node.
                if (left < n && arr[left] > arr[largestNode])
                    largestNode = left;

                // Replaces the largest value as the right node.
                if (right < n && arr[right] > arr[largestNode])
                    largestNode = right;

                // This updates the value for the largest node
                // if there was a swap with one of the child nodes.
                if (largestNode != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largestNode];
                    arr[largestNode] = swap;

                    // Recursively heapify any sub trees that
                    // underwent a change.
                    heapify(arr, n, largestNode);
                }
            }

        }
    }
}