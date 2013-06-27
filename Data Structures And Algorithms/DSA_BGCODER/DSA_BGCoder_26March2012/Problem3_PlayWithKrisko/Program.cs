using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;

namespace Problem3_PlayWithKrisko
{
    public static class Program
    {
        private static readonly MultiDictionary<int, int> graph = new MultiDictionary<int, int>(true);
        private static bool[] visited;
        private static int target;

        private static void clearVisited()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
        }

        private static int CalculateMaxSandwitches(int start)
        {
            int level = 0;
            var mainQueue = new Queue<int>();
            mainQueue.Enqueue(start);
            visited[start] = true;
            bool leafFound = false;

            int sandwichesCount = 0;

            while (mainQueue.Count > 0)
            {
                var neighbours = new Queue<int>();
                level++;

                while (mainQueue.Count > 0)
                {
                    int current = mainQueue.Dequeue();


                    foreach (int neighbour in graph[current])
                    {
                        if (visited[neighbour])
                        {
                            continue;
                        }

                        if (level == 1 && graph[neighbour].Count == 1)
                        {
                            sandwichesCount++;
                        }
                        else
                        {
                            if (!leafFound && graph[neighbour].Count == 1)
                            {
                                sandwichesCount += (1 << (level - 1)) + 1;
                                leafFound = true;
                            }
                            else if (level > 1)
                            {
                                sandwichesCount++;
                            }
                        }


                        visited[neighbour] = true;
                        neighbours.Enqueue(neighbour);
                    }
                }

                mainQueue = neighbours;
            }

            return sandwichesCount;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
#endif


            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] splitted = Console.ReadLine().Split();
                int dimension = int.Parse(splitted[0]);
                target = int.Parse(splitted[1]);

                visited = new bool[dimension];

                for (int row = 0; row < dimension; row++)
                {
                    string line = Console.ReadLine();
                    for (int col = 0; col < dimension; col++)
                    {
                        if (line[col] == '1')
                        {
                            graph.Add(row, col);
                        }
                    }
                }

                Console.WriteLine(CalculateMaxSandwitches(target));

                clearVisited();
                graph.Clear();
            }
        }
    }
}