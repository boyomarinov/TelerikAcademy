using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(int width, int height)
            : base(width, height)
        { }

        public override double CalculateSurface()
        {
            Console.WriteLine("Rectangle Surface: ");
            return Width * Height;
        }
    }
}
