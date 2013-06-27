using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Algo_March2012_05_FriendsOfPesho
{
    public struct Node : IComparable<Node>
    {
        public int NodeValue { get; set; }
        public int Distance { get; set; }

        public Node(int nodeValue, int weight) : this()
        {
            this.NodeValue = nodeValue;
            this.Distance = weight;
        }

        public override string ToString()
        {
            return string.Format("nodeValue: {0}, weight: {1}", NodeValue, Distance);
        }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }

    public static class Program
    {
        private static List<Node>[] graph;
        private static HashSet<int> hospitals = new HashSet<int>();

        private static int[] Dijkstra(int start)
        {
            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();

            OrderedBag<Node> priorityQueue = new OrderedBag<Node>();
            priorityQueue.Add(new Node(start, 0));
            distances[start] = 0;

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.RemoveFirst();

                foreach (var node in graph[current.NodeValue])
                {
                    if (current.Distance + node.Distance < distances[node.NodeValue])
                    {
                        distances[node.NodeValue] = current.Distance + node.Distance;
                        priorityQueue.Add(new Node(node.NodeValue, distances[node.NodeValue]));
                    }
                }
            }

            return distances;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../test.010.in.txt"));
#endif

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string[] main = Console.ReadLine().Split();
            int nodesCount = int.Parse(main[0]);
            int vertices = int.Parse(main[1]);
            int hospitalsCount = int.Parse(main[2]);

            graph = new List<Node>[nodesCount + 1];

            string[] hospitalsLine = Console.ReadLine().Split();
            for (int i = 0; i < hospitalsLine.Length; i++)
            {
                hospitals.Add(int.Parse(hospitalsLine[i]));
            }

            for (int i = 0; i < vertices; i++)
            {
                string[] currentLine = Console.ReadLine().Split();
                int first = int.Parse(currentLine[0]);
                int second = int.Parse(currentLine[1]);
                int weight = int.Parse(currentLine[2]);

                if (graph[first] == null)
                {
                    graph[first] = new List<Node>();
                }

                graph[first].Add(new Node(second, weight));


                if (graph[second] == null)
                {
                    graph[second] = new List<Node>();
                }

                graph[second].Add(new Node(first, weight));
            }

            int minSum = int.MaxValue;
            foreach (var hospital in hospitals)
            {
                var distances = Dijkstra(hospital);
                //int currentSum = distances.Where((x, i) => !hospitals.Contains(i)).Sum(x => x);
                int currentSum = 0;
                for (int i = 1; i < distances.Length; i++)
                {
                    if (hospitals.Contains(i))
                    {
                        continue;
                    }

                    currentSum += distances[i];
                }

                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
            }

            sw.Stop();

            //Console.WriteLine(sw.Elapsed);

            Console.WriteLine(minSum);
        }
    }
}
