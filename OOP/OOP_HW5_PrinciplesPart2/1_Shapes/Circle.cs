using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Shapes
{
    class Circle : Shape
    {
        public Circle(int radius)
            :base(radius, radius)
        { }

        public override double CalculateSurface()
        {
            Console.WriteLine("Circle surface: ");
            return 2 * Math.PI * Width;
        }
    }
}
