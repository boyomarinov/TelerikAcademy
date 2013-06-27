using System;
using System.IO;
using System.Linq;

namespace Algo_February2013_04_Salaries
{
    public static class Program
    {
        private static bool[][] AdjMatrix;

        private static long?[] DP = new long?[51];

        private static long CalculateSalary(int start)
        {
            if (DP[start] != null)
            {
                return DP[start].Value;
            }

            long result = 0;
            int i = 0;
            for (; i < AdjMatrix[start].Length; i++)
            {
                if (AdjMatrix[start][i])
                {
                    result += CalculateSalary(i);
                }
            }

            DP[start] = (result != 0) ? result : 1;
            return DP[start].Value;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
#endif

            int dimension = int.Parse(Console.ReadLine());

            AdjMatrix =
                Enumerable.Range(0, dimension)
                          .Select(i => Console.ReadLine().Select(c => (c == 'Y') ? true : false).ToArray())
                          .ToArray();

            long budget = 0;
            for (int i = 0; i < dimension; i++)
            {
                budget += CalculateSalary(i);
            }

            Console.WriteLine(budget);
        }
    }
}