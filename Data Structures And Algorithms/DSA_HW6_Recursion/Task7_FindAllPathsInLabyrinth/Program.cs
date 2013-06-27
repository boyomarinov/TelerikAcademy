using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coord = System.Tuple<int, int>;

namespace Task7_FindAllPathsInLabyrinth
{
    public static class Program
    {
        private static string[,] labyrinth;
        private static Coord[] directions = new Coord[]
            {
                new Coord(0, 1),
                new Coord(0, -1),
                new Coord(1, 0),
                new Coord(-1, 0)
            };

        private static bool[,] visited;
        private static List<Coord> paths = new List<Coord>(); 

        private static Coord start;
        private static int level;
        private static int count = 0;

        private static void FindAllPaths(Coord start)
        {
            if (labyrinth[start.Item1, start.Item2] == "e")
            {
                count++;
                Console.WriteLine(string.Join(" ", paths));
                return;
            }

            Console.WriteLine(start);

            foreach (var direction in directions)
            {
                Coord newCell = new Coord(start.Item1 + direction.Item1, start.Item2 + direction.Item2);
                bool isInLabyrinth = newCell.Item1 >= 0 && newCell.Item1 < labyrinth.GetLength(0) &&
                                     newCell.Item2 >= 0 && newCell.Item2 < labyrinth.GetLength(1);

                if (isInLabyrinth && labyrinth[newCell.Item1, newCell.Item2] != "x" && visited[newCell.Item1, newCell.Item2] == false)
                {
                    paths.Add(newCell);
                    visited[newCell.Item1, newCell.Item2] = true;
                    FindAllPaths(newCell);
                    paths.RemoveAt(paths.Count-1);
                    visited[newCell.Item1, newCell.Item2] = false;

                }
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

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif


            labyrinth = new string[6, 6];
            visited = new bool[6, 6];

            string line = Console.ReadLine();
            int row = 0;
            while (line != null && row < labyrinth.GetLength(0))
            {
                string[] splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < splitted.Length; col++)
                {
                    labyrinth[row, col] = splitted[col];
                }

                line = Console.ReadLine();
                row++;
            }

            start = FindStart();

            visited[start.Item1, start.Item2] = true;
            FindAllPaths(start);
            Console.WriteLine(count);
        }
    }
}
