using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGO_October2012_Task5ZigZagNums
{
    public static class Program
    {
        private static int n;
        private static int k;
        private static int[] elems;
        private static int[] current;

        public static void GenerateCombinations(int start, int next)
        {
            if (start == current.Length)
            {
                Console.WriteLine(string.Join(" ", current));
                return;
            }

            for (int i = 0; i < elems.Length; i++)
            {
                current[start] = i;
                GenerateCombinations(start + 1, i + 1);
            }
        }


        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif



            string[] nums = Console.ReadLine().Split();
            n = int.Parse(nums[0]);
            k = int.Parse(nums[1]);

            elems = new int[n];
            current = new int[k];

            GenerateCombinations(0, 0);

        }
    }
}
