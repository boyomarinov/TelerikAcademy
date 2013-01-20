using System;

class SandGlass
{
    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());
        string dots, asterisks;
        int count = 0;
        for (int i = 0; i < n/2 + 1; i++)
        {
            dots = new string('.', count);
            asterisks = new string('*', n - 2*count);
            Console.WriteLine(dots + asterisks + dots);
            count++;
        }
        count = count - 2;
        for (int i = 0; i < n/2; i++)
        {
            dots = new string('.', count);
            asterisks = new string('*', n - count*2);
            Console.WriteLine(dots + asterisks + dots);
            count--;
        }
    }
}

