using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Charts
{
    public partial class Form_Levels : Form
    {
        public Form_Levels()
        {
            InitializeComponent();
        }

        private void Form_Levels_Load(object sender, EventArgs e)
        {
            Kirajzol();
        }

        public void Kirajzol()
        {
            chart_levels.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Level",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            this.chart_levels.Series.Add(series1);

            for (int i = 0; i < Program.levels.Count; i++)
            {
                series1.Points.AddXY(Program.levels[i].Level_value, Program.levels[i].Energy);
            }
            chart_levels.Invalidate();
        }

        private void Form_Levels_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
