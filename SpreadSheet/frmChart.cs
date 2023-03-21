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

namespace SpreadSheet
{
    public partial class frmChart : Form
    {
        public DataTable table;
        public DataTable rev_table;
        public int idx_begin_X;
        public int idx_begin_Y;
        public bool change_direction;
        public frmChart(DataTable tb, DataTable rev_tb, int begin_col, int begin_row)
        {
            table = tb;
            rev_table = rev_tb;
            idx_begin_X = begin_col;
            idx_begin_Y = begin_row;
            change_direction = false;

            InitializeComponent();

            BarChart.Visible = true;
            BarChart_1.Visible = false;

            DrawChart_row();
            DrawChart_col();
        }

        public void DrawChart_row()
        {
            BarChart.DataSource = table;
            for (int i = 0; i < table.Columns.Count - 1; i ++)
            {
                Series serie = new Series();
                serie.Name = "Series" + Convert.ToChar(i + idx_begin_X +65).ToString();
                serie.XValueMember = "INDEX";
                serie.YValueMembers = (idx_begin_X + i).ToString();
                BarChart.Series.Add(serie);
            }            
            BarChart.DataBind();
        }

        public void DrawChart_col()
        {
            BarChart_1.DataSource = rev_table;
            for (int i = 0; i < rev_table.Columns.Count - 1; i++)
            {
                Series serie = new Series();
                serie.Name = "Series" + (i + idx_begin_Y + 1).ToString();
                serie.XValueMember = "INDEX";
                serie.YValueMembers = (idx_begin_Y + i).ToString();
                BarChart_1.Series.Add(serie);
            }
            BarChart_1.DataBind();
        }

        private void btnChangeRC_Click(object sender, EventArgs e)
        {
            change_direction = !change_direction;
            
            if (change_direction == false)
            {
                BarChart.Visible = true;
                BarChart_1.Visible = false;
            }
            else
            {
                BarChart.Visible = false;
                BarChart_1.Visible = true;
            }
        }
    }
}
