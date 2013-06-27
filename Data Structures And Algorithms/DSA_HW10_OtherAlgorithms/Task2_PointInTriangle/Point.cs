using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_PointInTriangle
{
    public struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator +(Point a, double num)
        {
            double x = a.X * num;
            double y = a.Y * num;

            return new Point(x, y);
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", X, Y);
        }
    }
}
