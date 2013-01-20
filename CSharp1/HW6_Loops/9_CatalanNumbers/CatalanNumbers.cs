using System;

class CatalanNumbers
{
    static decimal Factorial(int n)
    {
        decimal sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum *= (decimal)i;
        }
        return sum;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal nthCatalanNumber = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        Console.WriteLine("N-th Catalan number is {0}", nthCatalanNumber);
    }
}

