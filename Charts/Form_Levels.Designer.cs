namespace Charts
{
    partial class Form_Levels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Levels));
            this.chart_levels = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_levels)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_levels
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_levels.ChartAreas.Add(chartArea1);
            this.chart_levels.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_levels.Legends.Add(legend1);
            this.chart_levels.Location = new System.Drawing.Point(0, 0);
            this.chart_levels.Name = "chart_levels";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_levels.Series.Add(series1);
            this.chart_levels.Size = new System.Drawing.Size(800, 450);
            this.chart_levels.TabIndex = 0;
            this.chart_levels.Text = "chart_Levels";
            // 
            // Form_Levels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart_levels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Levels";
            this.Text = "Levels";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Levels_FormClosing);
            this.Load += new System.EventHandler(this.Form_Levels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_levels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart_levels;
    }
}