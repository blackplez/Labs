using System;

public delegate double EquationDelegate(double x);

public class Program
{
    public static double FindRoot(double a, double b, EquationDelegate equation, double precision)
    {
        double root = 0;

        // Проверка наличия корня на заданном интервале
        if (equation(a) * equation(b) >= 0)
        {
            throw new ArgumentException("No root on the given interval");
        }

        // Пока разница между границами интервала больше точности - мы продолжаем делить интервал пополам и проверять, в какой половине находится корень
        while (Math.Abs(b - a) > precision)
        {
            root = (a + b) / 2;

            if (equation(root) * equation(a) < 0)
            {
                b = root;
            }
            else
            {
                a = root;
            }
        }

        return root;
    }

    public static double SquareEquation(double x)
    {
        return x * x - 4;
    }

    public static void Main(string[] args)
    {
        // Пример использования функции для нахождения корня
        double root = FindRoot(1, 3, SquareEquation, 0.001);
        Console.WriteLine("Root: " + root);
    }
}
