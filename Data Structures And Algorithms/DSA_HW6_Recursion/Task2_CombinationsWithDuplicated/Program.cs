using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_CombinationsWithDuplicated
{
    public static class Program
    {
        private static int[] elems;
        private static int[] current;

        public static void GenerateCombinations(int start)
        {
            if (start == current.Length)
            {
                Console.WriteLine(string.Join(" ", current.Select(x => x + 1)));
                return;
            }

            for (int i = 0; i < elems.Length; i++)
            {
                current[start] = i;
                GenerateCombinations(start + 1);
            }
        }

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            elems = new int[n];
            current = new int[n - 1];

            GenerateCombinations(0);
        }
    }
}
