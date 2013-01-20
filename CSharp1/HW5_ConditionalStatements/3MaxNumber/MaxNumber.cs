using System;

class MaxNumber
{
    static void Main()
    {
        int a, b, c;
        int max = 0;
        Console.WriteLine("Input: ");
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());

        if (a >= b)
        {
            if (a >= c)
            {
                max = a;
            }
        }
        else if (b >= a)
        {
            if (b >= c)
            {
                max = b;
            }
        }
        else if(c >= b)
        {
            if (c >= a)
            {
                max = c;
            }
        }

        Console.WriteLine("Max: {0}", max);
    }
}

