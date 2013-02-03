using System;

class ReadNumberClass
{
    static int ReadNumber(int start, int end)
    {
        int n;
        n = int.Parse(Console.ReadLine());
        if (n < 0)
        {
            throw new FormatException();
        }
        else if (n < start || n > end)
        {
            throw new ArgumentOutOfRangeException();
        }
        return n;
    }
    static void Main()
    {
        int start = 1;
        int end = 100;
        int input = 0;
        for (int i = 0; i < 10; i++)
        {
            input = ReadNumber(start, end);
        }
    }
}

