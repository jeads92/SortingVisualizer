
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PrimeButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StartSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // PrimeButton
            // 
            this.PrimeButton.Location = new System.Drawing.Point(113, 13);
            this.PrimeButton.Name = "PrimeButton";
            this.PrimeButton.Size = new System.Drawing.Size(115, 23);
            this.PrimeButton.TabIndex = 1;
            this.PrimeButton.Text = "Press to add to lsit";
            this.PrimeButton.UseVisualStyleBackColor = true;
            this.PrimeButton.Click += new System.EventHandler(this.BigClicken);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 53);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(212, 20);
            this.textBox.TabIndex = 2;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(16, 95);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(212, 95);
            this.listBox.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 196);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Index";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(212, 159);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // StartSort
            // 
            this.StartSort.Location = new System.Drawing.Point(16, 369);
            this.StartSort.Name = "StartSort";
            this.StartSort.Size = new System.Drawing.Size(212, 23);
            this.StartSort.TabIndex = 5;
            this.StartSort.Text = "Start Sorting Data";
            this.StartSort.UseVisualStyleBackColor = true;
            this.StartSort.Click += new System.EventHandler(this.StartSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 404);
            this.Controls.Add(this.StartSort);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.PrimeButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Names";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrimeButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button StartSort;
    }
}

