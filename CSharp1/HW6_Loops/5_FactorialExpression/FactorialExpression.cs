using System;

class FactorialExpression
{
    static ulong Factorial(int n)
    {
        ulong result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= (ulong)i;
        }
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Input N and K (1 < N < K): ");
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        ulong factorialK = Factorial(k);
        ulong factorialN = Factorial(n);
        ulong factorialKN = Factorial(k - n);
        Console.WriteLine("Result: {0}", factorialN*factorialK/factorialKN);
    }
}
