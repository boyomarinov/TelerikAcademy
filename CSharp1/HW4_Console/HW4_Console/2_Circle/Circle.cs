using System;

    class Circle
    {
        static void Main()
        {
            Console.Write("Radius: ");
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine("Perimeter of circle is: {0}", 2*radius*Math.PI);
            Console.WriteLine("Area of circle is: {0}", Math.PI*radius*radius);
        }
    }
