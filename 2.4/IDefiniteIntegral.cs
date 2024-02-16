
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal interface IDefiniteIntegral
    {
        public delegate double _IntegerDelegate(double x);
        public string MethodName { get; }
        public double SearchValue(_IntegerDelegate Function, double a, double b, double h=1e-5);
    }
}
