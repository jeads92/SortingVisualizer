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

        private void BigClicken(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text) && !listBox.Items.Contains(textBox))
            {
                listBox.Items.Add(textBox.Text);
            }
        }

        private void StartSort_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Index"].Points.AddXY("bill", 1000);
        }
    }
}
