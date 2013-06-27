using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGO_April2012_Tribonacci
{
    public static class Program
    {
        private static long[] DP = new long[128];

        public static long Tribonacci(long n)
        {
            if (DP[n] > 0)
            {
                return DP[n];
            }

            if (n < 4)
            {
                return DP[n];
            }

            DP[n] =  Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);

            return DP[n];
        }

        public static void Main(string[] args)
        {
            long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();

            DP[1] = input[0];
            DP[2] = input[1];
            DP[3] = input[2];

            Console.WriteLine(Tribonacci(input[3]));
        }
    }
}
