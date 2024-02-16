
using System;

class Ex4
{
    static int Main()
    {
        try
        {
            string a = fractionToSystem(0.24, 4, 10);
            Console.WriteLine(a);
            Console.ReadLine();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            return 1;
        }
        
        
        return 0;
    }

    static string fractionToSystem(double fraction, int system, int accuracy)
    {
        int whole;
        double small;

        if (system<2 || system > 36)
        {
            throw new ArgumentException("Number system must be from 2 to 36", nameof(system));
        }

        fraction = Math.Abs(fraction);

        try
        {
            whole = (int)fraction;
            small = fraction - whole;
        }
        catch(ArgumentException e)
        {
            throw new ArgumentException(e.Message);
        }

        return (fraction < 0 ? "-" : "") + wholeToSystem(whole, system) +"."+ smallToSystem(small, system, accuracy);

    }

    static string wholeToSystem(int fraction, int system)
    {
        if (system < 2 || system > 36)
        {
            throw new ArgumentException("Number system must be from 2 to 36", nameof(system));
        }

        string result = "";

        while (fraction>0)
        {
            int code = fraction % system;
            fraction /= system;

            if (code > 9) code += 7;
            code += 48;

            result = (char)code + result;
        }

        return result;
    }

    static string smallToSystem(double fraction, int system, int accuracy)
    {
        string result = "", periodic = "";
        int searchIndex = 0;
        double epsilon = 1e-7;


        if (system < 2 || system > 36)
        {
            throw new ArgumentException("Number system must be from 2 to 36", nameof(system));
        }


        for (int i = 0; i <= accuracy && fraction > epsilon; i++)
        {
            fraction *= system;
            double code = Math.Floor(fraction);
            fraction -= code;
            if (code > 10) code += 7;
            code += 48;

            char symb = (char)code;
            result += symb;


            if (periodic.Length < 2)
            {
                periodic += symb;
            }
            else if (searchIndex == periodic.Length - 1)
            {
                if (periodic[0] == periodic[1]) return $"({periodic[0]})";
                else return $"({periodic})";
            }
            else if (symb == periodic[searchIndex])
            {
                searchIndex++;
            }
            else
            {
                searchIndex = 0;
                periodic = result;
            }
        }
        return result;
    }
}