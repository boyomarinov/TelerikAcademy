using System;
using System.Numerics;

class BigFactorial
{

    static BigInteger Factorial(int n)
    {
        BigInteger result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    static int CountZeros(BigInteger fact)
    {
        int counter = 0;
        while (fact % 10 == 0)
        {
            counter++;
            fact /= 10;
        }
        return counter;
    }
    static int CountTrailingZeros(int n)
    {
        int i = 1;
        int result = 0;
        while (n >= i)
        {
            i *= 5;
            result += n / i;
        }
        return result;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        DateTime start = DateTime.Now;
        //BigInteger fact = Factorial(n);
        //int res = CountZeros(fact);
        int alternativeZeros = CountTrailingZeros(n);
        TimeSpan elapsed = DateTime.Now - start;
        //Console.WriteLine("Fact: {0}", fact);
        //Console.WriteLine();
        //Console.WriteLine("Zeros: {0}", res);
        Console.WriteLine("Alternative Zeros: {0}", alternativeZeros);
        Console.WriteLine("Time: {0}", elapsed);
    }
}

