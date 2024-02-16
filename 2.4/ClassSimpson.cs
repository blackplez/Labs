using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class IntegerSimpson : IDefiniteIntegral
    {
        public string MethodName => "Simpson";
        
        public double SearchValue(IDefiniteIntegral._IntegerDelegate Function, double a, double b, double h = 1E-5)
        {
            if (a == b) return 0;
            if (a < b) throw new ArgumentException(nameof(a));
            if (h <= 0) throw new ArgumentException(nameof(h));
            if (Function == null) throw new ArgumentNullException(nameof(Function));

            double len = b - a;
            double count = len / h;
            double sum = Function(a) + Function(b);
            

            double x = a+h;
            for (int j = 1; j < count-1; j++)
            {
                double value = Function(x);
                value *= (j % 2 == 0 ? 2 : 4);
                sum+= Math.Abs(value);
                x += h;
            }

            return Math.Round(sum*h/3.0, 10);
        }
    }
}
