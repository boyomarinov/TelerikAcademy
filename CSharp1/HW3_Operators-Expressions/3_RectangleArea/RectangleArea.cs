using System;

class RectangleArea
{
    static void Main()
    {
        Console.WriteLine("Input: width, heigth");
        int width = int.Parse(Console.ReadLine());
        int heigth = int.Parse(Console.ReadLine());
        Console.WriteLine("Rectangle area is {0}.", width * heigth);
    }
}

