using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Shapes
{
    class Triangle : Shape
    {
        public Triangle(int width, int height)
            : base(width, height)
        { }

        public override double CalculateSurface()
        {
            Console.WriteLine("TriangleSurface:");
            return (Width * Height) / 2;
        }
    }
}
