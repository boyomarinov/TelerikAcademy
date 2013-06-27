using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Subsets
{
    public static class Program
    {
        private static string[] elems;
        private static string[] globalElems;
        private static bool[] visited;
        private static bool[] globalVisited;

        public static void GenerateSubsets(int start)
        {
            if (start == elems.Length)
            {
                Console.WriteLine(string.Join(", ", elems));
                return;
            }

            for (int i = 0; i < globalElems.Length; i++)
            {
                if (visited[i])
                {
                    globalVisited[i] = true;
                    continue;
                }

                elems[start] = globalElems[i];
                visited[i] = true;

                GenerateSubsets(start + 1);

            }
        }

        public static void Main()
        {
            int n = 3;
            int k = 2;
            elems = new string[2];
            globalElems = new string[3] { "test", "rock", "fun" };
            visited = new bool[3];
            globalVisited = new bool[3];

            GenerateSubsets(0);
        }
    }
}
