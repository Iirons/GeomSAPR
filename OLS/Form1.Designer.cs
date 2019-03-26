namespace OLS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DeletePointButton = new System.Windows.Forms.Button();
            this.GetCoefButton = new System.Windows.Forms.Button();
            this.GetYButton = new System.Windows.Forms.Button();
            this.XTextBox = new System.Windows.Forms.TextBox();
            this.LSM3checkBox = new System.Windows.Forms.CheckBox();
            this.LSM2checkBox = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CalculateLSMButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DrawButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GaussCheckBox = new System.Windows.Forms.CheckBox();
            this.GaussParCheckBox = new System.Windows.Forms.CheckBox();
            this.GaussSumCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GaussSumCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.GaussParCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.GaussCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.DeletePointButton);
            this.splitContainer1.Panel1.Controls.Add(this.GetCoefButton);
            this.splitContainer1.Panel1.Controls.Add(this.GetYButton);
            this.splitContainer1.Panel1.Controls.Add(this.XTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.LSM3checkBox);
            this.splitContainer1.Panel1.Controls.Add(this.LSM2checkBox);
            this.splitContainer1.Panel1.Controls.Add(this.ClearButton);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.CalculateLSMButton);
            this.splitContainer1.Panel1.Controls.Add(this.SaveButton);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.DrawButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 703);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // DeletePointButton
            // 
            this.DeletePointButton.Location = new System.Drawing.Point(4, 640);
            this.DeletePointButton.Name = "DeletePointButton";
            this.DeletePointButton.Size = new System.Drawing.Size(243, 23);
            this.DeletePointButton.TabIndex = 12;
            this.DeletePointButton.Text = "Delete Points";
            this.DeletePointButton.UseVisualStyleBackColor = true;
            this.DeletePointButton.Click += new System.EventHandler(this.DeletePointButton_Click);
            // 
            // GetCoefButton
            // 
            this.GetCoefButton.Location = new System.Drawing.Point(6, 556);
            this.GetCoefButton.Name = "GetCoefButton";
            this.GetCoefButton.Size = new System.Drawing.Size(241, 23);
            this.GetCoefButton.TabIndex = 11;
            this.GetCoefButton.Text = "Get Coefficients";
            this.GetCoefButton.UseVisualStyleBackColor = true;
            this.GetCoefButton.Click += new System.EventHandler(this.GetCoefButton_Click);
            // 
            // GetYButton
            // 
            this.GetYButton.Location = new System.Drawing.Point(172, 527);
            this.GetYButton.Name = "GetYButton";
            this.GetYButton.Size = new System.Drawing.Size(75, 23);
            this.GetYButton.TabIndex = 10;
            this.GetYButton.Text = "Get Y";
            this.GetYButton.UseVisualStyleBackColor = true;
            this.GetYButton.Click += new System.EventHandler(this.GetYButton_Click);
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(35, 530);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(88, 20);
            this.XTextBox.TabIndex = 9;
            // 
            // LSM3checkBox
            // 
            this.LSM3checkBox.AutoSize = true;
            this.LSM3checkBox.Location = new System.Drawing.Point(107, 449);
            this.LSM3checkBox.Name = "LSM3checkBox";
            this.LSM3checkBox.Size = new System.Drawing.Size(57, 17);
            this.LSM3checkBox.TabIndex = 8;
            this.LSM3checkBox.Text = "LSM 3";
            this.LSM3checkBox.UseVisualStyleBackColor = true;
            // 
            // LSM2checkBox
            // 
            this.LSM2checkBox.AutoSize = true;
            this.LSM2checkBox.Location = new System.Drawing.Point(12, 449);
            this.LSM2checkBox.Name = "LSM2checkBox";
            this.LSM2checkBox.Size = new System.Drawing.Size(57, 17);
            this.LSM2checkBox.TabIndex = 7;
            this.LSM2checkBox.Text = "LSM 2";
            this.LSM2checkBox.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(6, 501);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(241, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear Plot";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X = ";
            // 
            // CalculateLSMButton
            // 
            this.CalculateLSMButton.Location = new System.Drawing.Point(4, 472);
            this.CalculateLSMButton.Name = "CalculateLSMButton";
            this.CalculateLSMButton.Size = new System.Drawing.Size(243, 23);
            this.CalculateLSMButton.TabIndex = 4;
            this.CalculateLSMButton.Text = "Calculate";
            this.CalculateLSMButton.UseVisualStyleBackColor = true;
            this.CalculateLSMButton.Click += new System.EventHandler(this.CalculateLSMButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(4, 414);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(244, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(244, 396);
            this.dataGridView1.TabIndex = 1;
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(4, 669);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(244, 23);
            this.DrawButton.TabIndex = 0;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 703);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.CursorX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "PointSeries";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.White;
            series2.Name = "LineSeries1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "LineSeries2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "LineSeries3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1116, 703);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            this.chart1.MouseEnter += new System.EventHandler(this.Chart1_MouseEnter);
            this.chart1.MouseLeave += new System.EventHandler(this.Chart1_MouseLeave);
            // 
            // GaussCheckBox
            // 
            this.GaussCheckBox.AutoSize = true;
            this.GaussCheckBox.Location = new System.Drawing.Point(12, 449);
            this.GaussCheckBox.Name = "GaussCheckBox";
            this.GaussCheckBox.Size = new System.Drawing.Size(56, 17);
            this.GaussCheckBox.TabIndex = 13;
            this.GaussCheckBox.Text = "Gauss";
            this.GaussCheckBox.UseVisualStyleBackColor = true;
            // 
            // GaussParCheckBox
            // 
            this.GaussParCheckBox.AutoSize = true;
            this.GaussParCheckBox.Location = new System.Drawing.Point(74, 449);
            this.GaussParCheckBox.Name = "GaussParCheckBox";
            this.GaussParCheckBox.Size = new System.Drawing.Size(72, 17);
            this.GaussParCheckBox.TabIndex = 14;
            this.GaussParCheckBox.Text = "GaussPar";
            this.GaussParCheckBox.UseVisualStyleBackColor = true;
            // 
            // GaussSumCheckBox
            // 
            this.GaussSumCheckBox.AutoSize = true;
            this.GaussSumCheckBox.Location = new System.Drawing.Point(152, 449);
            this.GaussSumCheckBox.Name = "GaussSumCheckBox";
            this.GaussSumCheckBox.Size = new System.Drawing.Size(77, 17);
            this.GaussSumCheckBox.TabIndex = 15;
            this.GaussSumCheckBox.Text = "GaussSum";
            this.GaussSumCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 703);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CalculateLSMButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox LSM3checkBox;
        private System.Windows.Forms.CheckBox LSM2checkBox;
        private System.Windows.Forms.Button GetYButton;
        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.Button GetCoefButton;
        private System.Windows.Forms.Button DeletePointButton;
        private System.Windows.Forms.CheckBox GaussSumCheckBox;
        private System.Windows.Forms.CheckBox GaussParCheckBox;
        private System.Windows.Forms.CheckBox GaussCheckBox;
    }
}

