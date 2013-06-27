using System;

namespace ALGO_April2012_Vrachka
{
    public static class Program
    {
        private static int guessedRight;
        private static int guessedWrong;
        private static string prophecy;
        private static int?[, ,] DP = new int?[2600, 2, 2600];

        private static int BestCaseProphecy(int start, int good, int bad)
        {
            if (good > 0 && DP[start, 0, good] != null)
            {
                return DP[start, 0, good].Value;
            }

            if (bad > 0 && DP[start, 1, bad] != null)
            {
                return DP[start, 1, bad].Value;
            }

            if (start == prophecy.Length)
            {
                return 0;
            }

            int getGood = 0;
            int getBad = 0;

            if (good < guessedRight && prophecy[start] == 'G')
            {
                getGood = 1 + BestCaseProphecy(start + 1, good + 1, 0);
            }

            if (good < guessedRight && prophecy[start] == 'B')
            {
                getGood = BestCaseProphecy(start + 1, good + 1, 0);
            }

            if (bad < guessedWrong && prophecy[start] == 'B')
            {
                getBad = 1 + BestCaseProphecy(start + 1, 0, bad + 1);
            }

            if (bad < guessedWrong && prophecy[start] == 'G')
            {
                getBad = BestCaseProphecy(start + 1, 0, bad + 1);
            }

            int max = Math.Max(getGood, getBad);

            if (good > 0)
            {
                DP[start, 0, good] = max;
            }

            if (bad > 0)
            {
                DP[start, 1, bad] = max;
            }

            return max;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var input = Console.ReadLine().Split();
            guessedRight = int.Parse(input[0]);
            guessedWrong = int.Parse(input[1]);

            prophecy = Console.ReadLine();

            Console.WriteLine(BestCaseProphecy(0, 0, 0));
        }
    }
}
