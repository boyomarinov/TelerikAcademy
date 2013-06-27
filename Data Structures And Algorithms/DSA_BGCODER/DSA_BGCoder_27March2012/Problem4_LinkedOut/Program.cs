using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4_LinkedOut
{
    public static class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        public static IDictionary<string, int> TraverseWithBFS(string start, IList<string> searched)
        {
            Dictionary<string, int> searchedNodesDistances = searched.ToDictionary(node => node, node => -1);
            HashSet<string> visited = new HashSet<string>();
            Queue<string> mainQueue = new Queue<string>();
            int level = 0;

            if (!graph.ContainsKey(start))
            {
                return searchedNodesDistances;
            }

            mainQueue.Enqueue(start);
            visited.Add(start);

            while (mainQueue.Count > 0)
            {
                Queue<string> neighbours = new Queue<string>();
                while (mainQueue.Count > 0)
                {
                    string currentNode = mainQueue.Dequeue();
                    
                    if (searchedNodesDistances.ContainsKey(currentNode) && searchedNodesDistances[currentNode] == -1)
                    {
                        searchedNodesDistances[currentNode] = level;
                    }

                    foreach (var node in graph[currentNode])
                    {
                        if (visited.Contains(node))
                        {
                            continue;
                        }

                        neighbours.Enqueue(node);
                        visited.Add(node);
                    }
                }
                mainQueue = neighbours;
                level++;
            }


            return searchedNodesDistances;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            string start = Console.ReadLine();
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                if (!graph.ContainsKey(line[0]))
                {
                    graph.Add(line[0], new List<string>());
                }

                graph[line[0]].Add(line[1]);

                //backlink
                if (!graph.ContainsKey(line[1]))
                {
                    graph.Add(line[1], new List<string>());
                }

                graph[line[1]].Add(line[0]);
            }

            var searched = Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(i => Console.ReadLine()).ToArray();


            //Console.WriteLine(String.Join(",", TraverseWithBFS(start, searched)));
            StringBuilder sb = new StringBuilder();
            IDictionary<string, int> resultFromBfs = TraverseWithBFS(start, searched);
            foreach (var item in resultFromBfs.Values)
            {
                sb.AppendLine(item.ToString());
            }
            Console.Write(sb.ToString());
        }
    }
}
