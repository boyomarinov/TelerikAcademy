using System;

class PrintNotDivisableBy37
{
    static void PrintNotDivisableNumbers(int boundary)
    {
        for (int number = 1; number <= boundary; number++)
        {
            if ((number % 3 == 0) && (number % 7 == 0))
            {
                continue;
            }
            Console.WriteLine(number);
        }
    }

    static void Main()
    {
        Console.Write("Number to loop to: ");
        int upperBoundary = int.Parse(Console.ReadLine());

        PrintNotDivisableNumbers(upperBoundary);
    }
}

