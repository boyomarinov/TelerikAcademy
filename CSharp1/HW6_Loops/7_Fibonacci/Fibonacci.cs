using System;

class Fibonacci
{
    static ulong CalculateFibonacci(int nth)
    {
        if (nth <= 2)
        {
            return 1;
        }
        int temp = nth / 2;
        ulong a = CalculateFibonacci(temp + 1);
        ulong b = CalculateFibonacci(temp);
        ulong next;
        if (nth % 2 == 1)
        {
            next = a * a + b * b;
        }
        else
        {
            next = b * (2 * a - b);
        }
        return next;
    }
    static ulong CalculateSlowFibonacci(int n)
    {
        if (n == 0 || n == 1)
            return (ulong)n;

        ulong fib1 = 0;
        ulong fib2 = 1;
        ulong fib = 0;

        for (int i = 2; i < n; i++)
        {
            fib = fib1 + fib2;
            fib1 = fib2;
            fib2 = fib;
        }

        return fib;
    }

    static void Main()  
    {
        Console.Write("N: ");
        int n = int.Parse(Console.ReadLine());
        DateTime start = DateTime.Now;
        ulong sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum += CalculateSlowFibonacci(i);
            //sum += CalculateFibonacci(i);
        }
        TimeSpan runTime = DateTime.Now - start;
        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Time: {0}", runTime);
    }
}

