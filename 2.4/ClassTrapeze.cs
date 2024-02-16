using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class IntegerTrapeze : IDefiniteIntegral
    {
        public string MethodName => "Trapeze";

        public double SearchValue(IDefiniteIntegral._IntegerDelegate Function, double a, double b, double h = 1E-5)
        {
            if (a == b) return 0;
            if (a < b) throw new ArgumentException(nameof(a));
            if(h<=0) throw new ArgumentException(nameof(h));
            if(Function==null) throw new ArgumentNullException(nameof(Function));

            double len = b - a;
            double count = len / h;
            double sum = 0;

            double x = a;

            for (int j = 0; j < count; j++)
            {
                sum += Math.Abs(h* ((Function(x)+Function(x+h)) / 2.0));
                x += h;
            }

            return Math.Round(sum, 10);
        }
    }
}
