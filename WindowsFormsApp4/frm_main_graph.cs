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
namespace IMS
{
    public partial class frm_main_graph : Form
    {
        public frm_main_graph()
        {
            InitializeComponent();
        }
        public static int qut_count { get; set; }
        private void frm_main_graph_Load(object sender, EventArgs e)
        {
            qut_count = frm_quotation_list.count_qut;
            populate_que_chart();
            customize();
        }

        private void customize()
        {
            Chart1.ChartAreas[0].AxisX.Title = "x-axis";
            Chart1.ChartAreas[0].AxisY.Title = "y-axis";


            Chart1.Titles.Add("Cartesion chart");


            Chart1.BackColor = Color.Red;
            Chart1.ChartAreas[0].BackColor = Color.BlueViolet;



        }
        private void populate_que_chart()
        {
            Chart1.Series.Clear();
            Series series = new Series("Row count");
            series.ChartType = SeriesChartType.Point;

            int row = 7;

            series.Points.AddXY(1,10);
            series.Points.AddXY(2, 20);
            series.Points.AddXY(3, 30);
            series.Points.AddXY(4, 40);
            series.Points.AddXY(5, 50);

            Chart1.Series.Add(series);



        }
    }
}
