namespace SpreadSheet
{
    partial class frmChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChart));
            this.BarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnChangeRC = new System.Windows.Forms.Button();
            this.BarChart_1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart_1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarChart
            // 
            chartArea1.Name = "ChartArea1";
            this.BarChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.BarChart.Legends.Add(legend1);
            this.BarChart.Location = new System.Drawing.Point(17, 17);
            this.BarChart.Name = "BarChart";
            this.BarChart.Size = new System.Drawing.Size(549, 354);
            this.BarChart.TabIndex = 0;
            this.BarChart.Text = "chart1";
            // 
            // btnChangeRC
            // 
            this.btnChangeRC.Location = new System.Drawing.Point(352, 381);
            this.btnChangeRC.Name = "btnChangeRC";
            this.btnChangeRC.Size = new System.Drawing.Size(75, 23);
            this.btnChangeRC.TabIndex = 1;
            this.btnChangeRC.Text = "row <-> col";
            this.btnChangeRC.UseVisualStyleBackColor = true;
            this.btnChangeRC.Click += new System.EventHandler(this.btnChangeRC_Click);
            // 
            // BarChart_1
            // 
            chartArea2.Name = "ChartArea1";
            this.BarChart_1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.BarChart_1.Legends.Add(legend2);
            this.BarChart_1.Location = new System.Drawing.Point(17, 17);
            this.BarChart_1.Name = "BarChart_1";
            this.BarChart_1.Size = new System.Drawing.Size(549, 354);
            this.BarChart_1.TabIndex = 2;
            this.BarChart_1.Text = "chart1";
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.BarChart_1);
            this.Controls.Add(this.btnChangeRC);
            this.Controls.Add(this.BarChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "frmChart";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.BarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart BarChart;
        private System.Windows.Forms.Button btnChangeRC;
        private System.Windows.Forms.DataVisualization.Charting.Chart BarChart_1;
    }
}