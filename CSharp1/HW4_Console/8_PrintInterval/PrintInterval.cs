using System;

class PrintInterval
{
    static void Main()
    {
        Console.Write("Print up to: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("{0}", i);
        }
        Console.WriteLine();
    }
}

