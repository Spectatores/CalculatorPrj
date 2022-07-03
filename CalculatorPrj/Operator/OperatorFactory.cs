using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPrj.Operator
{
    internal class OperatorFactory
    {
        public static MyOperator GetOperator(string s)
        {
            switch (s)
            {
                case "+":
                    return new AddOperator();
                case "-":
                    return new SubOperator();
                case "x":
                    return new MutipleOperator();
                case "/":
                    return new DivisionOperator();
                case "%":
                    return new RemainderOperator();
                default:
                    return null;
            }
        }
    }
}
