using System;

class CartesianCoordinateSystem
{
    static int GiveLocation(double x, double y)
    {
        int result = 0;
        if (x == 0 && y == 0)
        {
            result = 0;
        }
        else
        {
            if (x > 0)
            {
                if (y > 0)
                {
                    result = 1;
                }
                else if (y < 0)
                {
                    result = 4;
                }
                else
                {
                    result = 6;
                }
            }
            else if (x < 0)
            {
                if (y > 0)
                {
                    result = 2;
                }
                else if (y < 0)
                {
                    result = 3;
                }
                else
                {
                    result = 6;
                }
            }
            else
            {
                result = 5;
            }
        }
        return result;
    }
    static void Main()
    {
        double x, y;
        x = double.Parse(Console.ReadLine());
        y = double.Parse(Console.ReadLine());
        int result = GiveLocation(x, y);
        Console.Write(result);
    }
}

