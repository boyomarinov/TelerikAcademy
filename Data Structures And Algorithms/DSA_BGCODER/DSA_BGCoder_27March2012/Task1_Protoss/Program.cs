using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Protoss
{
    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator *(Point a, int num)
        {
            int x = a.X * num;
            int y = a.Y * num;

            return new Point(x, y);
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", X, Y);
        }

        public static int ManhattanDistance(Point start, Point end)
        {
            int result = 0;
            result += Math.Abs(start.X - end.X);
            result += Math.Abs(start.Y - end.Y);

            return result;
        }
    }   

    public static class Program
    {
        private static Dictionary<string, string> secrets = new Dictionary<string, string>();
        private static Dictionary<string, Point> coordinatesMap = new Dictionary<string, Point>(); 
        //private static string[,] matrix;
        private static int distance;
        private static Point target;

        private static string ConvertToNormalArea(string unnormal)
        {
            return string.Join("-", unnormal.Split('-').Select(x => secrets[x]));
        }

        private static int CalculateTemplarDistance(string coordinate)
        {
            Point current = coordinatesMap[coordinate];

            return Point.ManhattanDistance(current, target);
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            distance = int.Parse(Console.ReadLine());
            int secretsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < secretsCount; i++)
            {
                string[] splitted = Console.ReadLine().Split();
                secrets.Add(splitted[1], splitted[0]);
            }

            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //matrix = new string[dimensions[0], dimensions[1]];
            for (int row = 0; row < dimensions[0]; row++)
            {
                string[] splittedLine = Console.ReadLine().Split();
                for (int col = 0; col < dimensions[1]; col++)
                {
                    coordinatesMap.Add(ConvertToNormalArea(splittedLine[col]), new Point(row, col));
                }
            }

            target = coordinatesMap[Console.ReadLine()];

            int count = 0;
            int darkTemplarsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < darkTemplarsCount; i++)
            {
                if (CalculateTemplarDistance(Console.ReadLine()) <= distance)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        
    }
}
