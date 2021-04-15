using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoVisualizer
{
    public partial class Form1 : Form
    {
        // Initializes size of the array.
        public int _arraySize;
        public int _countdown = 1;
        public bool _stopStatus = false;

        public Form1()
        {
            InitializeComponent();
  
        }

        public void UpdateBarChart(int[] selectedArray)
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

        private void buttonSort_Click(object sender, EventArgs e)
        {
            buttonSort.Enabled = false;
            _stopStatus = false;
            _arraySize = trackBar1.Value;
            NumberGenerator dataRandomizer = new NumberGenerator();
            int[] dataArray = dataRandomizer.Fill(_arraySize);
            UpdateBarChart(dataArray);
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
                    case "Quick Sort":
                        int arrayLength = dataArray.Length - 1;
                        QuickSort(dataArray, 0, arrayLength);
                        break;
                    case null:
                        break;
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _stopStatus = true;
            buttonSort.Enabled = true;
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            if (_countdown > 0)
            {
                _countdown -= 1;
                Console.WriteLine("_countdown subtractions");
            }
            else
            {
                testTimer.Stop();
                Console.WriteLine("timer stopped");
                _countdown = 1;
                return;
            }

        }

        public async void InsertionSort(int[] intArray)
        {
            int i = 1;
            int j = 1;
            int placeHolder = 1;
            while (i < intArray.Length && _stopStatus == false)
            {
                j = i;
                while (j > 0 && intArray[j - 1] > intArray[j])
                {
                    placeHolder = intArray[j];
                    intArray[j] = intArray[j - 1];
                    intArray[j - 1] = placeHolder;
                    j--;
                    UpdateBarChart(intArray);
                    await Task.Delay(sortSpeedBar.Value);
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
                    if (intArray[j] > intArray[j + 1] && _stopStatus == false)
                    {
                        int placeHolder = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = placeHolder;
                        UpdateBarChart(intArray);
                        
                        await Task.Delay(sortSpeedBar.Value);
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
                    if (intArray[i] > intArray[i + 1] & _stopStatus == false)
                    {
                        int placeHolder = intArray[i];
                        intArray[i] = intArray[i + 1];
                        intArray[i + 1] = placeHolder;
                        swapped = true;
                        UpdateBarChart(intArray);
                        
                        await Task.Delay(sortSpeedBar.Value);
                    }
                }

                if (swapped == false)
                    break;
                swapped = false;
                end = end - 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (intArray[i] > intArray[i + 1] && _stopStatus == false)
                    {
                        int temp = intArray[i];
                        intArray[i] = intArray[i + 1];
                        intArray[i + 1] = temp;
                        swapped = true;
                        UpdateBarChart(intArray);
                        
                        await Task.Delay(sortSpeedBar.Value);
                    }
                }
                start = start + 1;
            }
        }

        public void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            
        }

        /* This function takes last element as a pivot, places
        the pivot element at its correct position in sorted
        array, and places all smaller (smaller than pivot)
        to left of pivot and all greater elements to right
        of pivot */
        public int Partition(int[] arr, int low, int high)
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
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        /* The main function that implements QuickSort
        arr[] --> Array to be sorted,
        low --> Starting index,
        high --> Ending index
        */
        public void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = Partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
                UpdateBarChart(arr);
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

        static bool CheckSort(int[] data, int arrayLength)
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