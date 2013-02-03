using System;

class RandomGenerator
{
    static void GenerateRandom(int from, int to, int howMany)
    {
        Random rand = new Random();
        for (int i = 0; i < howMany; i++)
        {
            Console.WriteLine(rand.Next(from, to));
        }
    }
    static void Main()
    {
        int from = 100;
        int to = 200;
        int howMany = 10;
        GenerateRandom(from, to, howMany);
    }
}

