using System;

class Greater
{
    static void Main()
    {
        Console.Write("first: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("second: ");
        int b = int.Parse(Console.ReadLine());

        int difference = a - b;
        int sign = (difference >> 31) & 1;
        int greaterNumber = a - sign * difference;

        Console.WriteLine("Greater: {0}", greaterNumber );
    }
}

