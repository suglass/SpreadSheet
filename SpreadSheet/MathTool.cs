using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public class MathTool
    {        
        public Form1 m_form;
        public ExpModule m_cell_exp;

        public MathTool(Form1 form)
        {
            m_form = form;
        }
        
        public double GetOutput()
        {            
            double output = -1;

            if (m_cell_exp.idx_function == ConstEnv.FUNC_ARITHMETIC)
            {
                output = Arithmetic(m_cell_exp);
            }
            else if (m_cell_exp.idx_function == ConstEnv.FUNC_AVERAGE)
            {
                output = GetValueArray(m_cell_exp).Average();
            }
            else if (m_cell_exp.idx_function == ConstEnv.FUNC_MEAN)
            {
                output = Mean(m_cell_exp);
            }
            else if (m_cell_exp.idx_function == ConstEnv.FUNC_MEDIAN)
            {
                output = Median(m_cell_exp);
            }
            else if (m_cell_exp.idx_function == ConstEnv.FUNC_MODE)
            {
                output = Mode(m_cell_exp);
            }
            else if (m_cell_exp.idx_function == ConstEnv.FUNC_SUM)
            {
                output = Sum(m_cell_exp);
            }

            return output;
        }                

        public void GetExpModule(string tbx_content)
        {
            m_cell_exp = new ExpModule();

            string expression = tbx_content.ToUpper().Replace(" ", "");

            var arr = Regex.Matches(expression, ConstEnv.arith_reg_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
            if (arr.Length == 1)
            {
                m_cell_exp.idx_function = ConstEnv.FUNC_ARITHMETIC;
                var operator_arr = Regex.Matches(expression, ConstEnv.get_operator_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
                m_cell_exp.idx_arith_operator = Array.IndexOf(ConstEnv.arithmetic_opr_list, operator_arr[0]);
                m_cell_exp.is_valid = ConstEnv.EXP_FUNCTION_OK;
            }
            else
            {
                arr = Regex.Matches(expression, ConstEnv.func_reg_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
                if (arr.Length == 1)
                {
                    var func_arr = Regex.Matches(expression, ConstEnv.get_func_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
                    m_cell_exp.idx_function = Array.IndexOf(ConstEnv.func_list, func_arr[0]);
                    m_cell_exp.is_valid = ConstEnv.EXP_FUNCTION_OK;
                }
                else
                    return;
            }

            if (m_cell_exp.is_valid == ConstEnv.EXP_FUNCTION_OK)
            {
                var value_arr = Regex.Matches(expression, ConstEnv.get_value_pattern)
                                        .OfType<Match>()
                                        .Select(m => m.Groups[0].Value)
                                        .ToArray();
                
                m_cell_exp.idx_beginX = value_arr[0][0] - 65;
                m_cell_exp.idx_beginY = int.Parse(value_arr[0].Substring(1)) - 1;

                m_cell_exp.idx_finishX = value_arr[1][0] - 65;
                m_cell_exp.idx_finishY = int.Parse(value_arr[1].Substring(1)) - 1;

                int idx_X, idx_Y;
                try
                {
                    for (idx_X = m_cell_exp.idx_beginX; idx_X <= m_cell_exp.idx_finishX; idx_X++)
                        for (idx_Y = m_cell_exp.idx_beginY; idx_Y <= m_cell_exp.idx_finishY; idx_Y++)
                        {
                            double temp = double.Parse(m_form.m_tbxCell[idx_X, idx_Y].Text);
                        }
                    m_cell_exp.is_valid = ConstEnv.EXP_OK;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            return;
        }

        public double Arithmetic(ExpModule m_cell_exp)
        {
            double output = -999999999;

            double X_value = double.Parse(m_form.m_tbxCell[m_cell_exp.idx_beginX, m_cell_exp.idx_beginY].Text);
            double Y_value = double.Parse(m_form.m_tbxCell[m_cell_exp.idx_finishX, m_cell_exp.idx_finishY].Text);

            if (m_cell_exp.idx_arith_operator == ConstEnv.ARITH_PLUS)
                output = X_value + Y_value;
            else if (m_cell_exp.idx_arith_operator == ConstEnv.ARITH_MINUS)
                output = X_value - Y_value;
            else if (m_cell_exp.idx_arith_operator == ConstEnv.ARITH_MULTIPLY)
                output = X_value * Y_value;
            else if (m_cell_exp.idx_arith_operator == ConstEnv.ARITH_DIVIDE)
                output = X_value / Y_value;

            return output;
        }

        public double Arithmetic(string str_tbx, int idx_opr)
        {
            double output = -999999999;
            string expression = str_tbx.Replace(" ", "").Substring(1);
            string[] value = expression.Split(ConstEnv.arithmetic_opr_list[idx_opr][0]);

            double X = double.Parse(value[0]);
            double Y = double.Parse(value[1]);

            if (idx_opr == ConstEnv.ARITH_PLUS)
                output = X + Y;
            else if (idx_opr == ConstEnv.ARITH_MINUS)
                output = X - Y;
            else if (idx_opr == ConstEnv.ARITH_MULTIPLY)
                output = X * Y;
            else if (idx_opr == ConstEnv.ARITH_DIVIDE)
                output = X / Y;

            return output;
        }

        public int TotalCount(ExpModule m_cell_exp)
        {
            int cols_num = m_cell_exp.idx_finishX - m_cell_exp.idx_beginX + 1;
            int rows_num = m_cell_exp.idx_finishY - m_cell_exp.idx_beginY + 1;
            return cols_num * rows_num;
        }

        public double[] GetValueArray(ExpModule m_cell_exp)
        {            
            int idx_X;
            int idx_Y;

            List<double> value_list = new List<double>();

            for (idx_X = m_cell_exp.idx_beginX; idx_X <= m_cell_exp.idx_finishX; idx_X++)
                for (idx_Y = m_cell_exp.idx_beginY; idx_Y <= m_cell_exp.idx_finishY; idx_Y++)
                {
                    value_list.Add(double.Parse(m_form.m_tbxCell[idx_X, idx_Y].Text));
                }
            return value_list.ToArray();
        }

        public double Sum(ExpModule m_cell_exp)
        {
            double total = 0;
            int idx_X;
            int idx_Y;

            try
            {
                for (idx_X = m_cell_exp.idx_beginX; idx_X <= m_cell_exp.idx_finishX; idx_X ++)
                    for (idx_Y = m_cell_exp.idx_beginY; idx_Y <= m_cell_exp.idx_finishY; idx_Y ++)
                    {
                        total += double.Parse(m_form.m_tbxCell[idx_X, idx_Y].Text);
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return total;
        }

        public double Mean(ExpModule m_cell_exp)
        {
            double total = Sum(m_cell_exp);
            return total / TotalCount(m_cell_exp);
        }

        public double Median(ExpModule m_cell_exp)
        {
            double[] numbers = GetValueArray(m_cell_exp);

            int numberCount = numbers.Count();            
            int halfIndex = numbers.Count() / 2;

            var sortedNumbers = numbers.OrderBy(n => n);
            double median;

            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2);
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }
            return median;
        }

        public double Mode(ExpModule m_cell_exp)
        {
            double[] numbers = GetValueArray(m_cell_exp);

            Dictionary<double, int> counts = new Dictionary<double, int>();
            foreach (double a in numbers)
            {
                if (counts.ContainsKey(a))
                    counts[a] = counts[a] + 1;
                else
                    counts[a] = 1;
            }

            double result = double.MinValue;
            int max = int.MinValue;

            foreach (int key in counts.Keys)
            {
                if (counts[key] > max)
                {
                    max = counts[key];
                    result = key;
                }
            }
            return result;
        }
    }
}
