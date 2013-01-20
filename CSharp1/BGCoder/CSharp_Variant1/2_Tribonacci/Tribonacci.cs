using System;
using System.Numerics;

class Tribonacci
{
    static BigInteger Eval(int n, int first, int second, int third)
    {
        BigInteger f1, f2, f3;
        BigInteger result = 0;
        f1 = (BigInteger)first;
        f2 = (BigInteger)second;
        f3 = (BigInteger)third;

        if (n == 1)
        {
            return f1;
        }
        else if (n == 2)
        {
            return f2;
        }
        else if (n == 3)
        {
            return f3;
        }
        else
        {
            while (n > 3)
            {
                result = f1 + f2 + f3;
                f1 = f2;
                f2 = f3;
                f3 = result;
                n--;
            }
            return result;
        }
    }
    static void Main()
    {
        int n;
        int first, second, third;
      
        first = int.Parse(Console.ReadLine());
        second = int.Parse(Console.ReadLine());
        third = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());
        BigInteger result = Eval(n, first, second, third);
        Console.WriteLine(result);
    }
}

