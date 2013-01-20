using System;

class CheckIfInFigure
{
    static bool InCircle(double x, double y)
    {
        return (Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2) <= 9);
    }
    static bool inRectangle(double x, double y)
    {
        if (x >= -1 && x <= 5 && y >= -1 && y <= 1)
        {
            return true;
        }
        return false;
    }
    static void Main()
    {
        Console.WriteLine("Input x, y");
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        if (InCircle(x, y) && inRectangle(x, y))
        {
            Console.WriteLine("Point is in the figure.");
        }
        else
        {
            Console.WriteLine("Point is out of the figure.");
        }
    }
}

