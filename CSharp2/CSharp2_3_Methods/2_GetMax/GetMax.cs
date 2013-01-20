using System;

class GetMax
{
    static int ReturnMax(int a, int b)
    {
        if (a >= b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    static void Main()
    {
        int a, b, c;
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());

        int res = ReturnMax(ReturnMax(a, b), c);
        Console.WriteLine(res);
    }
}

