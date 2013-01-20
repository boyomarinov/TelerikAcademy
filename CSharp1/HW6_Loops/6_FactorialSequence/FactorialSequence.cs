using System;

class FactorialSequence
{
    static ulong Factorial(int n)
    {
        ulong result = 1;
        if (n == 0)
        {
            return result;
        }
        for (int i = 1; i <= n; i++)
        {
            result *= (ulong)i;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Input N and X: ");
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());

        double sum = 0;
        for (int i = 0; i <= n; i++)
        {
            sum += Factorial(n) / Math.Pow(x, i);
        }
        Console.WriteLine("Sum: {0}", sum);
    }
}

