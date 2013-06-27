using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Permutations
{
    public static class Program
    {
        private static int[] elems = new int[3];
        private static bool[] visited = new bool[3];

        public static void GeneratePermutations(int start)
        {
            if (start == elems.Length)
            {
                Console.WriteLine(string.Join(", ", elems.Select(x => x + 1)));
                return;
            }

            for (int i = 0; i < elems.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                elems[start] = i;
                visited[i] = true;
                GeneratePermutations(start + 1);
                visited[i] = false;
            }
        }
            
        public static void Main()
        {
            //int n = int.Parse(Console.ReadLine());

            int n = 3;
            GeneratePermutations(0);
        }
    }
}
