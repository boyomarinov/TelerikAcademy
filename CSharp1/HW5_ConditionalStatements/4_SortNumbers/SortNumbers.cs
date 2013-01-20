using System;

class SortNumbers
{
    static void Main()
    {
        int a, b, c;
        int min, middle, max;
        Console.WriteLine("Input: ");
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());

        if (a >= b)
        {
            if (a >= c)
            {
                max = a;
                if (b >= c)
                {
                    middle = b;
                    min = c;
                }
                else
                {
                    middle = c;
                    min = b;
                }
            }
            else
            {
                max = c;
                middle = a;
                min = b;
            }
        }
        else if (b >= c)
        {
            max = b;
            if (a >= c)
            {
                middle = a;
                min = c;
            }
            else
            {
                middle = c;
                min = a;
            }
        }
        else
        {
            max = c;
            if (a >= b)
            {
                middle = a;
                min = b;
            }
            else
            {
                middle = b;
                min = a;
            }
        }

        Console.WriteLine("In ascending order: {0}, {1}, {2}", min, middle, max);
    }
}

