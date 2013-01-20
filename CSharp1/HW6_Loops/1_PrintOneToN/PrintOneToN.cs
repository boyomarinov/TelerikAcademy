using System;

class PrintOneToN
{
    static void PrintNumbers(int num)
    {
        for (int number = 1; number <= num; number++)
        {
            Console.WriteLine(number);
        }
    }

    static void Main()
    {
        Console.Write("Number to loop to: ");
        int upperBoundary = int.Parse(Console.ReadLine());
        PrintNumbers(upperBoundary);
    }
}

