namespace SpreadSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbxStatus = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbFocused = new System.Windows.Forms.Label();
            this.lbFocusedCell = new System.Windows.Forms.Label();
            this.tbxFrom = new System.Windows.Forms.TextBox();
            this.lbFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTo = new System.Windows.Forms.TextBox();
            this.btnDrawChart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxStatus
            // 
            this.tbxStatus.Location = new System.Drawing.Point(80, 555);
            this.tbxStatus.Name = "tbxStatus";
            this.tbxStatus.Size = new System.Drawing.Size(593, 20);
            this.tbxStatus.TabIndex = 0;
            this.tbxStatus.TextChanged += new System.EventHandler(this.tbxStatus_TextChanged);
            this.tbxStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxStatus_KeyDown);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(22, 558);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(53, 13);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Content : ";
            // 
            // lbFocused
            // 
            this.lbFocused.AutoSize = true;
            this.lbFocused.Location = new System.Drawing.Point(737, 558);
            this.lbFocused.Name = "lbFocused";
            this.lbFocused.Size = new System.Drawing.Size(77, 13);
            this.lbFocused.TabIndex = 2;
            this.lbFocused.Text = "Focused Cell : ";
            // 
            // lbFocusedCell
            // 
            this.lbFocusedCell.AutoSize = true;
            this.lbFocusedCell.Location = new System.Drawing.Point(819, 558);
            this.lbFocusedCell.Name = "lbFocusedCell";
            this.lbFocusedCell.Size = new System.Drawing.Size(0, 13);
            this.lbFocusedCell.TabIndex = 3;
            // 
            // tbxFrom
            // 
            this.tbxFrom.Location = new System.Drawing.Point(1022, 555);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Size = new System.Drawing.Size(48, 20);
            this.tbxFrom.TabIndex = 1;
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(979, 558);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(39, 13);
            this.lbFrom.TabIndex = 5;
            this.lbFrom.Text = "From : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1088, 558);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "To :";
            // 
            // tbxTo
            // 
            this.tbxTo.Location = new System.Drawing.Point(1120, 555);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Size = new System.Drawing.Size(48, 20);
            this.tbxTo.TabIndex = 2;
            // 
            // btnDrawChart
            // 
            this.btnDrawChart.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawChart.Image")));
            this.btnDrawChart.Location = new System.Drawing.Point(1194, 551);
            this.btnDrawChart.Name = "btnDrawChart";
            this.btnDrawChart.Size = new System.Drawing.Size(33, 26);
            this.btnDrawChart.TabIndex = 3;
            this.btnDrawChart.UseVisualStyleBackColor = true;
            this.btnDrawChart.Click += new System.EventHandler(this.btnDrawChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1714, 591);
            this.Controls.Add(this.btnDrawChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.tbxTo);
            this.Controls.Add(this.tbxFrom);
            this.Controls.Add(this.lbFocusedCell);
            this.Controls.Add(this.lbFocused);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.tbxStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1730, 630);
            this.Name = "Form1";
            this.Text = "SpreadSheets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbFocused;
        private System.Windows.Forms.Label lbFocusedCell;
        private System.Windows.Forms.TextBox tbxFrom;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTo;
        private System.Windows.Forms.Button btnDrawChart;
    }
}

