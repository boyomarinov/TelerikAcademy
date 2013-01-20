using System;

    class TrapezoidArea
    {
        static void Main()
        {
            Console.WriteLine("Input a, b, h");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine("Trapezoid area is: {0}", ((a+b)/2D) * h);
        }
    }
