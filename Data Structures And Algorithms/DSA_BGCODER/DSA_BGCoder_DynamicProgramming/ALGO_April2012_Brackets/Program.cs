using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ALGO_April2012_Brackets
{
    class Program
    {
        private static int stack;
        private static long?[,] DP;

        public static long CountSolutions(char[] input, int start)
        {
            // Debug.WriteLine("{0} {1}", start, stack);

            if (stack < 0)
            {
                return 0;
            }

            if (start == input.Length)
            {
                if (stack == 0)
                {
                    // Debug.WriteLine(new string(input));
                    return 1;
                }

                return 0;
            }

            if (DP[start, stack] != null)
            {
                return DP[start, stack].Value;
            }

            Print(DP);
            Console.WriteLine();

            long result = 0;

            if (input[start] == '?')
            {
                input[start] = '(';
                stack++;
                result += CountSolutions(input, start + 1);
                stack--;

                input[start] = ')';
                stack--;
                result += CountSolutions(input, start + 1);
                stack++;

                input[start] = '?';
            }

            if (input[start] == '(')
            {
                stack++;
                result += CountSolutions(input, start + 1);
                stack--;
            }

            if (input[start] == ')')
            {
                stack--;
                result += CountSolutions(input, start + 1);
                stack++;
            }

            DP[start, stack] = result;

            return result;
        }

        static void Print(long?[,] matrix)
        {
#if DEBUG
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", matrix[row, col] ?? -1);
                }

                Console.WriteLine();
            }
#endif
        }

        static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            Debug.Listeners.Add(new ConsoleTraceListener());
#endif

            char[] line = Console.ReadLine().ToCharArray();
            DP = new long?[line.Length, line.Length];

            Console.WriteLine(CountSolutions(line, 0));
        }
    }
}
