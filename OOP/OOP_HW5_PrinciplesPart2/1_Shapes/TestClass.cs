using System;
using System.Collections.Generic;

namespace _1_Shapes
{
    class TestClass
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Triangle(2, 3));
            shapes.Add(new Rectangle(4, 5));
            shapes.Add(new Circle(5));

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0:F2}", shape.CalculateSurface());
            }
        }
    }
}
