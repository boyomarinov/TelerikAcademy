using System;

class FirTree
{
    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());
        int lineSize = 2 * n - 2;
        string dots;
        string asterisks;
        for (int i = 1; i < n; i++)
        {
            dots = new string('.', n - i-1);
            asterisks = new string('*', 2*i-1);
            Console.WriteLine(dots + asterisks + dots);
        }
        dots = new string('.', n - 2);
        asterisks = new string('*', 1);
        Console.WriteLine(dots + asterisks + dots);
    }
}

