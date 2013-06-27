using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace February2012_Problem7_MaximalenPyt
{
    public static class Program
    {
        private static readonly Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static readonly HashSet<int> visited = new HashSet<int>();

        //private static int LINQFindMaxPath(int start)
        //{
        //    //try
        //    //{
        //    var result = graph[start]
        //                             .Where(node => !visited.Contains(node))
        //                             .Select(node =>
        //                                 {
        //                                     visited.Add(node);
        //                                     return FindMaxPath(node);
        //                                 });

        //    if (!result.Any())
        //    {
        //        return start + result.Max();
        //    }

        //    return start;
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    return start;
        //    //}
        //}

        private static long FindMaxPath(int start)
        {
            long maxSum = 0;
            List<int> collection = graph[start];
            visited.Add(start);
            foreach (int node in collection)
            {
                if (!visited.Contains(node))
                {
                    //visited.Add(node);
                    long current = FindMaxPath(node);

                    if (current > maxSum)
                    {
                        maxSum = current;
                    }
                }
            }

            return start + maxSum;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../test.005.in.txt"));
#endif
            var sw = new Stopwatch();
            sw.Start();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count - 1; i++)
            {
                string first = Console.ReadLine();
                int[] splitted =
                    first.Substring(1, first.Count() - 2)
                         .Split(new[] {" <- "}, StringSplitOptions.None).Select(int.Parse).ToArray();

                //first connection
                if (!graph.ContainsKey(splitted[0]))
                {
                    graph.Add(splitted[0], new List<int>());
                }
                graph[splitted[0]].Add(splitted[1]);

                //second connection
                if (!graph.ContainsKey(splitted[1]))
                {
                    graph.Add(splitted[1], new List<int>());
                }
                graph[splitted[1]].Add(splitted[0]);
            }

            IEnumerable<int> leaves = graph.Where(x => x.Value.Count == 1).Select(x => x.Key);

            long globalMaxPath = 0;
            foreach (int node in leaves)
            {
                //visited.Add(node);
                long sumFromCurrentNode = FindMaxPath(node);

                if (globalMaxPath < sumFromCurrentNode)
                {
                    globalMaxPath = sumFromCurrentNode;
                }

                visited.Clear();
                //visited = new HashSet<int>();
            }


            sw.Stop();
            Console.WriteLine(globalMaxPath);
            //Console.WriteLine(sw.Elapsed);
        }
    }
}