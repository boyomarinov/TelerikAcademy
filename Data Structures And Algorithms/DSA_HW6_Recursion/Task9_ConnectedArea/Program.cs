using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Coord = System.Tuple<int, int>;

namespace Task9_ConnectedArea
{
    public static class Program
    {
        private static string[,] labyrinth;
        private static string[,] lab2;
        private static readonly Coord[] directions = new Coord[]
            {
                new Coord(-1, 0),
                new Coord(0, 1),
                new Coord(1, 0),
                new Coord(0, -1)
            };

        private static bool[,] visited;
        private static int maxCount = 0;

        private static void FindAdjacent(Coord start, int count)
        {
            Stack<Coord> stack = new Stack<Coord>();
            stack.Push(start);
            //visited[start.Item1, start.Item2] = true;

            while (stack.Count > 0)
            {
                Coord current = stack.Pop();
                lab2[current.Item1, current.Item2] = "!";
                count++;

                Thread.Sleep(66);
                Print(lab2);

                foreach (var direction in directions)
                {
                    Coord next = new Coord(current.Item1 + direction.Item1, current.Item2 + direction.Item2);
                    bool isInLabyrinth = next.Item1 >= 0 && next.Item1 < labyrinth.GetLength(0) &&
                                         next.Item2 >= 0 && next.Item2 < labyrinth.GetLength(1);

                    if (isInLabyrinth && labyrinth[next.Item1, next.Item2] != "▀" && visited[next.Item1, next.Item2] == false)
                    {
                        if (labyrinth[next.Item1, next.Item2] == "e")
                        {
                            return;
                        }

                        visited[next.Item1, next.Item2] = true;
                        stack.Push(next);
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                }

                //visited[next.Item1, next.Item2] = false;
            }
        }

        private static void Print(string[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j] + " ");
                }
                sb.AppendLine();
            }

            Console.Clear();
            Console.Write(sb.ToString());
        }

        private static void PrintBool(bool[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append((matrix[i,j] ? "1" : "0") + " ");
                }
                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input_10.txt"));
#endif

            labyrinth = new string[10, 10];
            lab2 = new string[labyrinth.GetLength(0), labyrinth.GetLength(1)];
            visited = new bool[labyrinth.GetLength(0), labyrinth.GetLength(1)];

            string line = Console.ReadLine();
            int row = 0;
            while (line != null && row < labyrinth.GetLength(0))
            {
                string[] splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < splitted.Length; col++)
                {
                    labyrinth[row, col] = splitted[col];
                    lab2[row, col] = splitted[col];
                }

                line = Console.ReadLine();
                row++;
            }

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (visited[i, j] || labyrinth[i, j] != "0")
                    {
                        continue;
                    }

                    FindAdjacent(new Coord(i, j), 0);
                }
            }

            Console.WriteLine(maxCount - 1);
        }
    }
}
