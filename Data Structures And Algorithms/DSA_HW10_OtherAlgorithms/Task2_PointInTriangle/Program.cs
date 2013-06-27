using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_PointInTriangle
{
    public static class Program
    {
        public static bool IsInTriangle(Point p, Point p1, Point p2, Point p3)
        {
            double determinant = ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));

            double alpha = ((p2.Y - p3.Y) * (p.X - p3.X) + (p3.X - p2.X) * (p.Y - p3.Y)) / determinant;
            double beta = ((p3.Y - p1.Y) * (p.X - p3.X) + (p1.X - p3.X) * (p.Y - p3.Y)) / determinant;
            double gamma = 1 - alpha - beta;

            return (alpha >= 0) && (beta >= 0) && (gamma >= 0);
        }

        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Point a = new Point(0, 0);
            Point b = new Point(2, 0);
            Point c = new Point(2, 2);

            Random rand = new Random();
            var points = Enumerable.Range(0, 10000000).Select(i => Tuple.Create(rand.Next(0, 2), rand.Next(0, 2))).ToArray();

            sw.Start();
            long memo = GC.GetTotalMemory(true);

            foreach (var point in points)
            {
                IsInTriangle(new Point(point.Item1, point.Item2), a, b, c);
            }
            sw.Stop();
            Console.WriteLine(GC.GetTotalMemory(true) - memo);
            Console.WriteLine(sw.Elapsed);
            //Point target = new Point(1.7, 0.2);
            //Point target2 = new Point(0.3, 0);
            //Point target3 = new Point(1.9, 2);

            //Point a = new Point(0, 0);
            //Point b = new Point(2, 0);
            //Point c = new Point(2, 2);

            ////in triangle
            //Console.WriteLine("Point is in triangle: " + IsInTriangle(target, a, b, c));

            ////on edge
            //Console.WriteLine("Point is in triangle: " + IsInTriangle(target2, a, b, c));

            ////outside triangle
            //Console.WriteLine("Point is in triangle: " + IsInTriangle(target3, a, b, c));
        }
    }
}
