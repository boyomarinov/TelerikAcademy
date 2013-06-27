using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;
using Vertex = System.Tuple<int, int>;

namespace Algo_February2013_10_Energo
{
    public static class Program
    {
        static MultiDictionary<int, Vertex> graph = new MultiDictionary<int, Vertex>(true);
        private static long sum = 0;

        public static void Prim(int start)
        {
            HashSet<int> spanningTree = new HashSet<int>();
            OrderedBag<Vertex> priorityQueue = new OrderedBag<Vertex>((a, b) => a.Item2.CompareTo(b.Item2));

            spanningTree.Add(start);

            priorityQueue.AddMany(graph[start]);
            
            while (priorityQueue.Count > 0)
            {
                Vertex current = priorityQueue.RemoveFirst();

                if (spanningTree.Contains(current.Item1))
                {
                    continue;
                }

                priorityQueue.AddMany(graph[current.Item1]);
                spanningTree.Add(current.Item1);
                sum += current.Item2;
            }
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif



            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] currentLine = Console.ReadLine().Split();
                int first = int.Parse(currentLine[0]);
                int second = int.Parse(currentLine[1]);
                int distance = int.Parse(currentLine[2]);

                graph.Add(first, Tuple.Create(second, distance));
                graph.Add(second, Tuple.Create(first, distance));
            }

            Prim(graph.Keys.First());
            Console.WriteLine(sum);
        }
    }
}
