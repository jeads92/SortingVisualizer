using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoVisualizer
{
    public partial class Form1 : Form
    {
        // Initializes size of the array.
        public int _arraySize;
        public int[] _currentArray;
        public int[] _currentIteration;
        public int _i = 1;
        public int _j = 1;
        public int _placeHolder = 1;
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


        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    Console.WriteLine("is not sorted");
                    return false;
                }
            }
            Console.WriteLine("This is sorted");
            return true;
        }

        public async void InsertionSort(int[] intArray)
        {
            int i = 1;
            int j = 1;
            int placeHolder = 1;
            while (i < intArray.Length)
            {
                j = i;
                while (j > 0 && intArray[j - 1] > intArray[j] && _stopStatus == false)
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