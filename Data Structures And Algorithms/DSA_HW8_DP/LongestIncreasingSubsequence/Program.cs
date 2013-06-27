using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    public static class Program
    {
        public static void Main()
        {
            int[] input = new int[] {2, 4, 3, 5, 1, 7, 6, 9, 8 };
            int[] DP = new int[input.Length];
            int[] P = new int[input.Length];
            DP[0] = 1;
            P[0] = -1;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (input[j] < input[i])
                    {
                        if (DP[i] < DP[j] + 1)
                        {
                            DP[i] = DP[j] + 1;
                            P[i] = j;
                        }
                    }
                }
            }

            Console.WriteLine(DP[input.Length - 1]);
            int k = input.Length - 1;
            Console.Write(input[k]);
            while (P[k] >= 0)
            {
                Console.Write(input[P[k]]);
                k = P[k];
            }
        }
    }
}
