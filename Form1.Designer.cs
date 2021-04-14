﻿
namespace AlgoVisualizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackbarValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSort = new System.Windows.Forms.Button();
            this.intTestLabel = new System.Windows.Forms.Label();
            this.algorithmBox = new System.Windows.Forms.ListBox();
            this.indexSwapsLabel = new System.Windows.Forms.Label();
            this.sortSpeedBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.speedLblTest = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortSpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Data";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(577, 594);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(613, 28);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackbarValueLabel
            // 
            this.trackbarValueLabel.AutoSize = true;
            this.trackbarValueLabel.Location = new System.Drawing.Point(674, 12);
            this.trackbarValueLabel.Name = "trackbarValueLabel";
            this.trackbarValueLabel.Size = new System.Drawing.Size(14, 15);
            this.trackbarValueLabel.TabIndex = 5;
            this.trackbarValueLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Array Size:";
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(756, 136);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 7;
            this.buttonSort.Text = "Start Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // intTestLabel
            // 
            this.intTestLabel.AutoSize = true;
            this.intTestLabel.Location = new System.Drawing.Point(614, 304);
            this.intTestLabel.Name = "intTestLabel";
            this.intTestLabel.Size = new System.Drawing.Size(74, 15);
            this.intTestLabel.TabIndex = 8;
            this.intTestLabel.Text = "Array Values";
            // 
            // algorithmBox
            // 
            this.algorithmBox.FormattingEnabled = true;
            this.algorithmBox.ItemHeight = 15;
            this.algorithmBox.Items.AddRange(new object[] {
            "Insertion Sort",
            "Bubble Sort",
            "Merge Sort",
            "Quick Sort",
            "Heap Sort",
            "Cocktail Shaker Sort"});
            this.algorithmBox.Location = new System.Drawing.Point(722, 12);
            this.algorithmBox.Name = "algorithmBox";
            this.algorithmBox.Size = new System.Drawing.Size(146, 109);
            this.algorithmBox.TabIndex = 12;
            // 
            // indexSwapsLabel
            // 
            this.indexSwapsLabel.AutoSize = true;
            this.indexSwapsLabel.Location = new System.Drawing.Point(751, 235);
            this.indexSwapsLabel.Name = "indexSwapsLabel";
            this.indexSwapsLabel.Size = new System.Drawing.Size(80, 15);
            this.indexSwapsLabel.TabIndex = 13;
            this.indexSwapsLabel.Text = "Index Swaps:";
            // 
            // sortSpeedBar
            // 
            this.sortSpeedBar.Location = new System.Drawing.Point(872, 560);
            this.sortSpeedBar.Maximum = 990;
            this.sortSpeedBar.Minimum = 10;
            this.sortSpeedBar.Name = "sortSpeedBar";
            this.sortSpeedBar.Size = new System.Drawing.Size(110, 45);
            this.sortSpeedBar.TabIndex = 14;
            this.sortSpeedBar.TickFrequency = 100;
            this.sortSpeedBar.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(884, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sorting Speed";
            // 
            // speedLblTest
            // 
            this.speedLblTest.AutoSize = true;
            this.speedLblTest.Location = new System.Drawing.Point(783, 560);
            this.speedLblTest.Name = "speedLblTest";
            this.speedLblTest.Size = new System.Drawing.Size(0, 15);
            this.speedLblTest.TabIndex = 16;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(722, 174);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(146, 23);
            this.stopButton.TabIndex = 17;
            this.stopButton.Text = "Stop Sorting";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(756, 207);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(76, 15);
            this.statusLabel.TabIndex = 18;
            this.statusLabel.Text = "Stop Status: ";
            // 
            // Form1
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(992, 618);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.speedLblTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sortSpeedBar);
            this.Controls.Add(this.indexSwapsLabel);
            this.Controls.Add(this.algorithmBox);
            this.Controls.Add(this.intTestLabel);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackbarValueLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortSpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label trackbarValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label intTestLabel;
        private System.Windows.Forms.ListBox algorithmBox;
        private System.Windows.Forms.Label indexSwapsLabel;
        private System.Windows.Forms.TrackBar sortSpeedBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label speedLblTest;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label statusLabel;
    }
}

