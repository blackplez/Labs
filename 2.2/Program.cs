using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{

    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Combinations:");
                List<int> items = new List<int>() { 1, 2, 3 };
                EqulityComparerRealizate comparerRealizate = new EqulityComparerRealizate();
                foreach (List<int> s in items.GetCombinations(2,comparerRealizate))
                {
                    Console.Write("[ ");
                    foreach (int i in s)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            catch (ArgumentNullException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

            try
            {
                Console.WriteLine("Combinations With No Repetitions:");
                List<int> items = new List<int>() { 1, 2, 3 };
                EqulityComparerRealizate comparerRealizate = new EqulityComparerRealizate();
                foreach (List<int> s in items.GetCombinationsNoRepetitions(2,comparerRealizate))
                {
                    Console.Write("[ ");
                    foreach (int i in s)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            catch (ArgumentNullException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

            try
            {
                Console.WriteLine("Subsets:");
                List<int> items = new List<int>() { 1, 2, 3 };
                EqulityComparerRealizate comparerRealizate = new EqulityComparerRealizate();
                foreach (List<int> s in items.GetSubsets(comparerRealizate))
                {
                    Console.Write("[ ");
                    foreach (int i in s)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            catch (ArgumentNullException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

            try
            {
                Console.WriteLine("Rearrangements:");
                List<int> items = new List<int>() { 1, 2, 3 };
                EqulityComparerRealizate comparerRealizate = new EqulityComparerRealizate();
                foreach (List<int> s in items.GetRearrangements(comparerRealizate))
                {
                    Console.Write("[ ");
                    foreach (int i in s)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
                Console.WriteLine(); 

            }
            catch (ArgumentNullException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

            try
            {
                Console.WriteLine("Error:");
                List<int> items = new List<int>() { 1, 1, 3 };
                EqulityComparerRealizate comparerRealizate = new EqulityComparerRealizate();
                foreach (List<int> s in items.GetRearrangements(comparerRealizate))
                {
                    Console.Write("[ ");
                    foreach (int i in s)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            catch (ArgumentNullException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

        }

    }
}