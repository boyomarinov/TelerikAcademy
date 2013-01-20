using System;

class QuadraticEquation
{
    static void Main()
    {
        double x1, x2;
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());

        double d = b * b - 4 * a * c;
        if (d > 0)
        {
            x1 = (-b - Math.Sqrt(d)) / (2 * a);
            x2 = (-b + Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("Two real roots:");
            Console.WriteLine("x1: {0}", x1);
            Console.WriteLine("x2: {0}", x2);
        }
        else if (d == 0)
        {
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("Only one real root: {0}", x1);
        }
        else
        {
            Console.WriteLine("No real roots.");
        }
    }
}

