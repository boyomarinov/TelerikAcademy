using System;

class MaxOutOfFive
{
    static void Main()
    {
        Console.WriteLine("Input 5 integers: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());

        double max = a;
        if (b > a)
        {
            max = b;
        }
        else if (c > a)
        {
            max = c;
        }
        else if (d > a)
        {
            max = d;
        }
        else if (e > a)
        {
            max = e;
        }
        Console.WriteLine("Max: {0}", max);
    }
}

