using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coord = System.Tuple<int, int>;

namespace Problem5_HorseMatrix
{
    public static class Program
    {
        private static Coord[] directions =
            {
                new Coord(-1, +2),
                new Coord(+1, +2),
                new Coord(+1, -2),
                new Coord(-1, -2),
                new Coord(+2, +1),
                new Coord(-2, +1),
                new Coord(+2, -1),
                new Coord(-2, -1)
            };

        public static bool InMatrix(Coord c, char[,] matrix)
        {
            return (c.Item1 >= 0 && c.Item1 < matrix.GetLength(0)) &&
                   (c.Item2 >= 0 && c.Item2 < matrix.GetLength(1));
        }

        public static int OverrunKnighWithHorse(char[,] matrix, Coord start, Coord end)
        {
            Queue<Tuple<Coord, int>> q = new Queue<Tuple<Coord, int>>();
            int dimensions = matrix.GetLength(0);
            bool[,] visited = new bool[dimensions, dimensions];

            q.Enqueue(new Tuple<Coord, int>(start, 0));
            visited[start.Item1, start.Item2] = true;
            while (q.Count > 0)
            {
                Tuple<Coord, int> current = q.Dequeue();

                foreach (var direction in directions)
                {
                    Coord newCoords = new Coord(current.Item1.Item1 + direction.Item1,
                                                current.Item1.Item2 + direction.Item2);
                    if (InMatrix(newCoords, matrix) && !visited[newCoords.Item1, newCoords.Item2] && 
                        matrix[newCoords.Item1, newCoords.Item2] != 'x')
                    {
                        if (newCoords.Equals(end))
                        {
                            return current.Item2 + 1;
                        }
                        visited[newCoords.Item1, newCoords.Item2] = true;
                        q.Enqueue(new Tuple<Coord, int>(newCoords, current.Item2 + 1));
                    }
                }
            }

            return -1;
        }

        public static Coord IndexOf(char[,] matrix, char element)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == element)
                    {
                        return new Coord(row, col);
                    }
                }
            }

            throw new ArgumentException();
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader(@"../../input.txt"));
#endif

            int dimensions = int.Parse(Console.ReadLine());
            char[,] horseMatrix = new char[dimensions, dimensions];
            for (int row = 0; row < dimensions; row++)
            {
                string[] splittedLine = Console.ReadLine().Split();
                for (int col = 0; col < dimensions; col++)
                {
                    horseMatrix[row, col] = splittedLine[col][0];
                }
            }

            Coord start = IndexOf(horseMatrix, 's');
            Coord end = IndexOf(horseMatrix, 'e');

            int result = OverrunKnighWithHorse(horseMatrix, start, end);
            if (result != -1)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}
