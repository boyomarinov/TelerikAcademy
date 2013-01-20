using System;

class InCircle
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 25)
        {
            Console.WriteLine("Point is in circle.");
        }
        else
        {
            Console.WriteLine("Point is not in circle.");
        }
    }
}

