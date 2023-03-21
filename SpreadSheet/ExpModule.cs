using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public class ExpModule
    {
        public int idx_function;
        public int idx_beginX;
        public int idx_beginY;
        public int idx_finishX;
        public int idx_finishY;

        public int idx_arith_operator;
        
        public int is_valid;

        public ExpModule()
        {
            idx_function = ConstEnv.FUNC_NONE;
            idx_beginX = -1;
            idx_beginY = -1;
            idx_finishX = -1;
            idx_finishY = -1;
            is_valid = ConstEnv.EXP_BASE;
            idx_arith_operator = ConstEnv.ARITH_NONE;
        }
    }
}
