using System;
using System.Linq;
using System.Numerics;

namespace Algo_ColouredBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, BigInteger> factorial = null;
            factorial = (x => x == 0 ? 1 : x * factorial(x - 1));

            ((Action<string>)(x => Console.WriteLine(factorial(x.Length) / x.GroupBy(g => g).Select(g => factorial(g.Count())).Aggregate<BigInteger, BigInteger>(1, (a, b) => a * b))))(Console.ReadLine());
        }
    }
}
