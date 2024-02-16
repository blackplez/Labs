using Ex4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{

    internal class Program
    {

        static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            try
            {
                double a = -1, b = 1;
                stopwatch.Start(); ToConsole($"Left:\t\t{new IntegerLeftRectangles().SearchValue(Function, a, b)}\t", "");
                stopwatch.Start(); ToConsole($"Right:\t\t{new IntegerRightRectangles().SearchValue(Function, a, b)}");
                stopwatch.Start(); ToConsole($"Middle:\t\t{new IntegerMiddleRectangles().SearchValue(Function, a, b)}");
                stopwatch.Start(); ToConsole($"Trapeze:\t{new IntegerTrapeze().SearchValue(Function, a, b)}");
                stopwatch.Start(); ToConsole($"Simpsons:\t{new IntegerSimpson().SearchValue(Function, a, b)}");
            }
            catch (ArgumentNullException e) { Console.WriteLine(e.Message); }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }

        }
        public static double Function(double x)
        {
            return 2 * x * x - 5;
        }










        public static void ToConsole(string text, string tb="\t")
        { 
            Console.Write(text);
            stopwatch.Stop();
            Console.Write($"{tb}\t({stopwatch.ElapsedMilliseconds} ms)");
            if(tb=="") Console.Write(" (initializate static)");
            Console.WriteLine();
            stopwatch.Reset();
        }


    }
}