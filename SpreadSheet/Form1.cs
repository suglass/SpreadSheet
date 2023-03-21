using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadSheet
{
    public partial class Form1 : Form
    {
        public TextBox[,] m_tbxCell;
        public Label[] m_lb_Cols;
        public Label[] m_lb_Rows;
        public MathTool m_math_tool;

        public TextBox m_focused_cell;

        public Form1()
        {
            m_tbxCell = new TextBox[26, 26];
            m_lb_Cols = new Label[26];
            m_lb_Rows = new Label[26];
            m_focused_cell = null;

            InitializeComponent();            

            for (int i = 0; i < 26; i ++)
                for (int j = 0; j < 26; j ++)
                {
                    m_tbxCell[i, j] = new System.Windows.Forms.TextBox();

                    int pos_x = i * 65 + 20;
                    int pos_y = j * 20 + 18;
                    m_tbxCell[i, j].Location = new System.Drawing.Point(pos_x, pos_y);

                    m_tbxCell[i, j].Name = "textBox" + i.ToString() + "*" + j.ToString();

                    m_tbxCell[i, j].Size = new System.Drawing.Size(65, 20);

                    m_tbxCell[i, j].Multiline = false;
                    m_tbxCell[i, j].Font = new Font(m_tbxCell[i, j].Font.FontFamily, 10);

                    m_tbxCell[i, j].KeyDown += new KeyEventHandler(tbx_KeyDown);
                    m_tbxCell[i, j].TextChanged += new EventHandler(TextBoxChange);
                    m_tbxCell[i, j].MouseClick += new MouseEventHandler(tbx_MouseClicked);
                    m_tbxCell[i, j].GotFocus += OnFocus;
                    m_tbxCell[i, j].Tag = i * 100 + j + 1;
                    
                    this.Controls.Add(m_tbxCell[i, j]);
                }

            for (int i = 0; i < 26; i ++)
            {
                m_lb_Cols[i] = new System.Windows.Forms.Label();
                m_lb_Rows[i] = new System.Windows.Forms.Label();

                m_lb_Cols[i].Location = new System.Drawing.Point(20 + i * 65, 0);
                m_lb_Rows[i].Location = new System.Drawing.Point(0, 18 + i * 20);

                m_lb_Cols[i].Name = "col_label_" + i.ToString();
                m_lb_Rows[i].Name = "row_label_" + i.ToString();

                m_lb_Cols[i].Size = new System.Drawing.Size(65, 18);
                m_lb_Rows[i].Size = new System.Drawing.Size(20, 20);

                m_lb_Cols[i].Text = Convert.ToChar(65 + i).ToString();
                m_lb_Rows[i].Text = (i + 1).ToString();
                m_lb_Cols[i].ForeColor = Color.Blue;
                m_lb_Rows[i].ForeColor = Color.Blue;

                m_lb_Cols[i].TextAlign = ContentAlignment.MiddleCenter;
                m_lb_Rows[i].TextAlign = ContentAlignment.MiddleCenter;

                this.Controls.Add(m_lb_Rows[i]);
                this.Controls.Add(m_lb_Cols[i]);
            }

            m_math_tool = new MathTool(this);
        }

        public void OnFocus(object sender, EventArgs e)
        {
            TextBox tbx_cell = sender as TextBox;
            /*if (m_focused_cell != null)
                m_focused_cell.BackColor = Color.White;*/

            foreach (TextBox item in m_tbxCell)
                if (item.BackColor != Color.White)
                    item.BackColor = Color.White;

            m_focused_cell = tbx_cell;
            m_focused_cell.BackColor = Color.Yellow;

            int tag = int.Parse(tbx_cell.Tag.ToString());
            string idx = Convert.ToChar(tag / 100 + 65).ToString() + " ";
            idx += (tag % 100).ToString();
            lbFocusedCell.Text = idx;

            tbxStatus.Text = tbx_cell.Text;
        }
        public void tbx_MouseClicked(object sender, EventArgs e)
        {
            TextBox tbx_cell = sender as TextBox;
            m_focused_cell = tbx_cell;
            tbxStatus.Text = tbx_cell.Text;
        }

        public void TextBoxChange(object sender, EventArgs e)
        {
            TextBox tbx_cell = sender as TextBox;
            m_focused_cell = tbx_cell;
            tbxStatus.Text = tbx_cell.Text;
        }

        public void tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                TextBox textbox = sender as TextBox;
                if (string.IsNullOrWhiteSpace(textbox.Text))
                    return;

                if (textbox.Text.ToString().Replace(" ", "")[0] != '=')
                    return;

                m_math_tool.GetExpModule(textbox.Text);

                if (m_math_tool.m_cell_exp.is_valid < ConstEnv.EXP_FUNCTION_OK)
                {
                    var operator_arr = Regex.Matches(textbox.Text.ToString().Replace(" ", ""), ConstEnv.get_operator_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
                    if (operator_arr.Count() != 1)
                    {
                        MessageBox.Show("Input invalid. Try again.");
                        return;
                    }
                    else
                    {
                        int idx_opr = Array.IndexOf(ConstEnv.arithmetic_opr_list, operator_arr[0]);
                        textbox.Text = m_math_tool.Arithmetic(textbox.Text.ToString(), idx_opr).ToString();
                        return;
                    }                    
                }
                if (m_math_tool.m_cell_exp.is_valid < ConstEnv.EXP_OK)
                {
                    MessageBox.Show("Some invalid cells. Check again if numbers are.");
                    return;
                }

                textbox.Text = m_math_tool.GetOutput().ToString();
            }
        }

        public int GetType(string tbx_content)
        {
            if (tbx_content.Replace(" ", "")[0] == '=')
                return ConstEnv.INPUT_FUNCTION;
            else
                return ConstEnv.INPUT_VALUE;
        }

        private void tbxStatus_TextChanged(object sender, EventArgs e)
        {
            TextBox status_textbox = sender as TextBox;

            if (m_focused_cell != null)
                m_focused_cell.Text = status_textbox.Text;
        }

        private void tbxStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                TextBox textbox = sender as TextBox;
                if (string.IsNullOrWhiteSpace(textbox.Text) || m_focused_cell == null)
                    return;

                if (textbox.Text.ToString().Replace(" ", "")[0] != '=')
                    return;

                m_math_tool.GetExpModule(textbox.Text);

                if (m_math_tool.m_cell_exp.is_valid < ConstEnv.EXP_FUNCTION_OK)
                {
                    var operator_arr = Regex.Matches(textbox.Text.ToString().Replace(" ", ""), ConstEnv.get_operator_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
                    if (operator_arr.Count() != 1)
                    {
                        MessageBox.Show("Input invalid. Try again.");
                        return;
                    }
                    else
                    {
                        int idx_opr = Array.IndexOf(ConstEnv.arithmetic_opr_list, operator_arr[0]);
                        textbox.Text = m_math_tool.Arithmetic(textbox.Text.ToString(), idx_opr).ToString();
                        return;
                    }
                }
                if (m_math_tool.m_cell_exp.is_valid < ConstEnv.EXP_OK)
                {
                    MessageBox.Show("Some invalid cells. Check again if numbers are.");
                    return;
                }

                textbox.Text = m_math_tool.GetOutput().ToString();
            }
        }

        private void btnDrawChart_Click(object sender, EventArgs e)
        {
            string begin = tbxFrom.Text.ToString().ToUpper().Replace(" ", "");
            string finish = tbxTo.Text.ToString().ToUpper().Replace(" ", "");

            var begin_arr = Regex.Matches(begin, ConstEnv.get_value_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
            var finish_arr = Regex.Matches(finish, ConstEnv.get_value_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
            if (begin_arr.Count() != 1 || finish_arr.Count() != 1)
            {
                MessageBox.Show("Input cells correctly.");
                return;
            }

            int idx_beginX = begin_arr[0][0] - 65;
            int idx_beginY = int.Parse(begin_arr[0].Substring(1)) - 1;

            int idx_finishX = finish_arr[0][0] - 65;
            int idx_finishY = int.Parse(finish_arr[0].Substring(1)) - 1;

            DataTable dt = new DataTable();

            int idx_X, idx_Y;

            dt.Columns.Add("INDEX");
            for (idx_X = idx_beginX; idx_X <= idx_finishX; idx_X++)
                dt.Columns.Add(idx_X.ToString());

            try
            {
                for (idx_Y = idx_beginY; idx_Y <= idx_finishY; idx_Y++)
                {
                    DataRow row = dt.NewRow();
                    row["INDEX"] = (idx_Y + 1).ToString();
                    for (idx_X = idx_beginX; idx_X <= idx_finishX; idx_X++)
                    {
                        double temp = double.Parse(m_tbxCell[idx_X, idx_Y].Text);
                        row[idx_X.ToString()] = temp;
                    }
                    dt.Rows.Add(row);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Some invalid cells. Check again if numbers are.");
                return;
            }

            DataTable rev_tb = Get_rev_Dt(idx_beginX, idx_beginY, idx_finishX, idx_finishY);

            frmChart dlg = new frmChart(dt, rev_tb, idx_beginX, idx_beginY);
            dlg.ShowDialog();
        }

        public DataTable Get_rev_Dt(int idx_beginX, int idx_beginY, int idx_finishX, int idx_finishY)
        {                           
            int idx_X, idx_Y;

            DataTable rev_tb = new DataTable();

            rev_tb.Columns.Add("INDEX");

            for (idx_Y = idx_beginY; idx_Y <= idx_finishY; idx_Y++)
                rev_tb.Columns.Add(idx_Y.ToString());

            for (idx_X = idx_beginX; idx_X <= idx_finishX; idx_X++)
            {
                DataRow row = rev_tb.NewRow();
                row["INDEX"] = Convert.ToChar(idx_X + 65).ToString();
                for (idx_Y = idx_beginY; idx_Y <= idx_finishY; idx_Y++)
                {
                    double temp = double.Parse(m_tbxCell[idx_X, idx_Y].Text);
                    row[idx_Y.ToString()] = temp;
                }
                rev_tb.Rows.Add(row);
            }
            return rev_tb;
        }
    }
}
