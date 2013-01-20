using System;

class SumIntegers
{
    static void Main()
    {
        int a, b, c;
        Console.Write("First: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Second: ");
        b = int.Parse(Console.ReadLine());
        Console.Write("Third: ");
        c = int.Parse(Console.ReadLine());

        Console.WriteLine("The sum of the numbers is {0}.", a + b + c);
    }
}

