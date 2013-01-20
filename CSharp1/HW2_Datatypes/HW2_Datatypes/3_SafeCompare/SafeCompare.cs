using System;

class SafeCompare
{
    static void Main()
    {
        string[] input = Console.ReadLine().Replace('.',',').Split();
        decimal first = decimal.Parse(input[0]);
        decimal second = decimal.Parse(input[1]);
        bool equal = (Math.Abs(first - second) < 0.000001M);
        Console.WriteLine(equal);
    }
}

