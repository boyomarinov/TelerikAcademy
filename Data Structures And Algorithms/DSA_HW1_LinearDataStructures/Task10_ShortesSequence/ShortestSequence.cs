using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_ShortesSequence
{
    public static class ShortestSequence
    {
        public static IList<T> Clone<T>(this IList<T> list)
            where T : struct
        {
            return list.Select(x => x).ToList();
        }

        public static IList<int> GenerateShortestPath(int start, int end, IList<Func<int, int>> operations)
        {
            Queue<IList<int>> currentQueue = new Queue<IList<int>>();
            bool[] visited = new bool[end - start + 1];
            int level = 0;
            currentQueue.Enqueue(new List<int>() { start });
            visited[0] = true;

            while (currentQueue.Count > 0)
            {
                Queue<IList<int>> nextQueue = new Queue<IList<int>>();
                level++;

                while (currentQueue.Count > 0)
                {
                    IList<int> currentSequence = currentQueue.Dequeue();
                    foreach (var op in operations)
                    {
                        int calculated = op(currentSequence.Last());
                        IList<int> nextSequence = currentSequence.Clone();
                        nextSequence.Add(calculated);
                        
                        if (calculated > end || visited[calculated - start] == true)
                        {
                            continue;
                        }

                        if (calculated == end)
                        {
                            return nextSequence;
                        }

                        visited[calculated - start] = true;
                        nextQueue.Enqueue(nextSequence);
                    }
                }

                currentQueue = nextQueue;
            }

            return null;
        }

        public static void Main()
        {
            Func<int, int>[] operations = {x => x + 1, x => x + 2, x => x * 2};
            Console.WriteLine(string.Join(" -> ", GenerateShortestPath(5, 16, operations)));
            Console.WriteLine();
            Console.WriteLine(string.Join(" -> ", GenerateShortestPath(1, 10000, operations)));
            Console.WriteLine();
        }
    }
}
