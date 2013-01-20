using System;

class OddNumber
{
    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());

        long result = 0;
        for (int i = 0; i < n; i++)
        {
            long next = long.Parse(Console.ReadLine());
            result = result ^ next;
        }
        Console.WriteLine(result);
    }
}
