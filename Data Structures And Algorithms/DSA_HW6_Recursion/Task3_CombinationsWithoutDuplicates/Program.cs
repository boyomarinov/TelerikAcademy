using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_CombinationsWithoutDuplicates
{
    static class Program
    {
        private static int[] elems;
        private static int[] current;
        private static string[] words = { "test", "rock", "fun", "bla" };

        private static void GenerateCombinations(int start, int next)
        {
            if (start == current.Length)
            {
                Console.WriteLine(string.Join(" ", current.Select(x => words[x])));
                return;
            }

            for (int i = next; i < elems.Length; i++)
            {
                current[start] = i;
                GenerateCombinations(start + 1, i + 1);
            }
        }

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            elems = new int[n];
            current = new int[k];

            GenerateCombinations(0, 0);
        }
    }
}
