﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPrj
{
    internal class AddOperator : MyOperator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
