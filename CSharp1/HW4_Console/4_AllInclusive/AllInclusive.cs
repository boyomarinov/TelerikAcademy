using System;

class AllInclusive
{
    static int CheckDivided(int start, int finish)
    {
        int count = 0;
        for(int i=start; i<=finish; i++)
        {
            if(i % 5 == 0)
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        Console.Write("Starting integer: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Last integer: ");
        int finish = int.Parse(Console.ReadLine());

        Console.WriteLine("Count: {0}", CheckDivided(start, finish));
    }
}

