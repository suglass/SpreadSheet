using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public static class ConstEnv
    {
        public static string[] func_list = new string[]
        {
            "MODE",
            "AVERAGE",
            "MEDIAN",
            "MEAN",
            "SUM"
        };

        public static string[] arithmetic_opr_list = new string[]
        {
            "+",
            "-",
            "*",
            "/"
        };        

        public static readonly string func_reg_pattern = @"= *((MODE|AVERAGE|MEDIAN|MEAN|SUM)| |) *(\(|)[A-Za-z](1[0-9]|2[0-6]|[0-9]) *(:) *[A-Za-z](1[0-9]|2[0-6]|[0-9])";
        public static readonly string arith_reg_pattern = @"= *(\(| |)[A-Za-z](1[0-9]|2[0-6]|[0-9])( |)*(\+|\*|\-|\/)( |)*[A-Za-z](1[0-9]|2[0-6]|[0-9])(\)|)";

        public static readonly string get_value_pattern = @"[A-Za-z](1[0-9]|2[0-6]|[0-9])";
        public static readonly string get_func_pattern = @"(MODE|AVERAGE|MEDIAN|MEAN|SUM)";
        public static readonly string get_operator_pattern = @"(\+|\*|\-|\/)";

        public static readonly int ARITH_NONE = -1;
        public static readonly int ARITH_PLUS = 0;
        public static readonly int ARITH_MINUS = 1;
        public static readonly int ARITH_MULTIPLY = 2;
        public static readonly int ARITH_DIVIDE = 3;

        public static readonly int FUNC_NONE = -1;
        public static readonly int FUNC_MODE = 0;
        public static readonly int FUNC_AVERAGE = 1;
        public static readonly int FUNC_MEDIAN = 2;
        public static readonly int FUNC_MEAN = 3;
        public static readonly int FUNC_SUM = 4;
        public static readonly int FUNC_ARITHMETIC = 5;

        public static readonly int EXP_BASE = -1;
        public static readonly int EXP_FUNCTION_OK = 0;
        public static readonly int EXP_OK = 1;        

        public static readonly int INPUT_VALUE = 1;
        public static readonly int INPUT_FUNCTION = 2;        
    }
}
