using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGO_April2012_SuperSuma
{
    public static class Program
    {
        private static int?[,] DP;

        public static int CalculateSupersum(int k, int n)
        {
            if (k == 0)
            {
                return n;
            }

            if (DP[k, n] != null)
            {
               return DP[k, n].Value;
            }

            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += CalculateSupersum(k-1, i);
            }

            return (DP[k, n] = result).Value;
        }

        public static void Main(string[] args)
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            string[] input = Console.ReadLine().Split();
            int k = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            DP = new int?[k + 1,n + 1];
            
            Console.WriteLine(CalculateSupersum(k, n));
;        }
    }
}
