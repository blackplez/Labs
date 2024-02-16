using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student1 = new Student("Maksim1", "Kornev", "GdeLaby", "МПМ-122", "122545", 2);
                Student student2 = new Student("Maksim2", "Kornev", "GdeLaby", "МПМ-122", "122545", 2);
                Student student3 = new Student("Maksim1", "Kornev", "GdeLaby", "МПМ-122", "122545", 2);
                Console.WriteLine(student1.ToString()); 
                Console.WriteLine(student2.ToString()); 
                Console.WriteLine(student3.ToString());
                Console.WriteLine($"HashCode: {student1.GetHashCode()}");
                Console.WriteLine($"student 1 is {(student1.Equals(student2)?"":"not")} equals student 2");
                Console.WriteLine($"student 1 is {(student1.Equals(student3) ? "" : "not")} equals student 3");
            }
            catch (ArgumentNullException e) { Console.WriteLine(e.Message); }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }

            Console.ReadLine();
        }
    }
}
