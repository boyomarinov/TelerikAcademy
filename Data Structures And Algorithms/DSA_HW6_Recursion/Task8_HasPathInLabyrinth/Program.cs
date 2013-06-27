using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Coord = System.Tuple<int, int>;

namespace Task8_HasPathInLabyrinth
{

    public static class Program
    {
        private static string[,] labyrinth;
        private static string[,] lab2;
        private static Coord[] directions = new Coord[]
            {
                new Coord(-1, 0),
                new Coord(0, 1),
                new Coord(1, 0),
                new Coord(0, -1)
            };

        private static bool[,] visited;
        private static List<Coord> paths = new List<Coord>();

        private static void FindPath(Coord start)
        {
            Stack<Coord> stack = new Stack<Coord>();
            stack.Push(start);
            //visited[start.Item1, start.Item2] = true;

            while (stack.Count > 0)
            {
                Coord current = stack.Pop();
                lab2[current.Item1, current.Item2] = "-";

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

                //visited[next.Item1, next.Item2] = false;
            }
        }

        private static Coord FindStart()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "s")
                    {
                        return new Coord(row, col);
                    }
                }
            }

            return new Coord(-1, -1);
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

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input_20.txt"));
#endif

            labyrinth = new string[20, 20];
            lab2 = new string[20,20];
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

            Coord start = FindStart();
            //visited[start.Item1, start.Item2] = true;

            FindPath(start);

            Print(lab2);
           
        }
    }
}

