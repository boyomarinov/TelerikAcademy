using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGO_April2012_TaenEzik
{
    public static class Program
    {
        private static string input;
        private static string[] current;
        private static int minDifference = int.MaxValue;
        private static int?[,] DP = new int?[64, 64];

        private static bool CheckLetterOrder(string one, int index)
        {
            int[] alphabet = new int[26];

            if (index + one.Length > input.Length)
            {
                return false;
            }

            foreach (char c in one)
            {
                alphabet[c - 'a']++;
            }

            for (int j = index; j < index + one.Length; j++)
            {
                alphabet[input[j] - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (alphabet[i] > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int WordDifference(string one, int index)
        {
            return one.Where((t, i) => t != input[index + i]).Count();
        }

        //returns difference
        //po kakvoto si vikam rekursiqta po nego memoiziram!
        private static void CheckExpression(int index, int currentDifference)
        {
            if (DP[index, currentDifference] != null)
            {
                return;
            }

            if (index == input.Length)
            {
                if (currentDifference < minDifference)
                {
                    minDifference = currentDifference;
                }

                return;
            }

            foreach (var word in current)
            {
                if (CheckLetterOrder(word, index))
                {
                    int difference = WordDifference(word, index);
                    DP[index, currentDifference] = difference;
                    CheckExpression(index + word.Length, currentDifference + difference);
                }

            }
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            current = Console.ReadLine().Split();

            CheckExpression(0, 0);
            Console.WriteLine((minDifference != int.MaxValue) ? minDifference : -1);
        }
    }
}
