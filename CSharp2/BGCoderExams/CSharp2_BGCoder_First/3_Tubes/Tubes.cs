using System;

class Program
{
    //static int CalculateOptimalTube(int fighters, int[] tubes)
    //{
    //    long sum = 0;
    //    for (int i = 0; i < tubes.Length; i++)
    //    {
    //        sum += tubes[i];
    //    }
    //    int maxTube = (int)(sum / fighters);

    //    int tubeLenght = maxTube;
    //    int happyFighters = 0;
    //    while (happyFighters != fighters)
    //    {
    //        happyFighters = 0;
    //        for (int i = 0; i < tubes.Length; i++)
    //        {
    //            happyFighters += tubes[i] / tubeLenght;
    //        }
    //        tubeLenght--;
    //    }
    //    return tubeLenght + 1;
    //}
  
    //static int OptimalTube(int[] tubes, int fighters, long sum)
    //{
    //    int maxTube = (int)(sum / fighters);
    //    int[] tubeLenghts = GenerateTubeLengthArray(maxTube);

    //    int tubeLenght = maxTube;
    //    int happyFighters = 0;
    //    while (happyFighters != fighters)
    //    {
    //        happyFighters = 0;
    //        for (int i = 0; i < tubes.Length; i++)
    //        {
    //            happyFighters += tubes[i] / tubeLenght;
    //        }
    //        tubeLenght--;
    //    }
    //}
    static long FindOptimalTube(long[] tubes, long left, long right, long fighters)
    {
        while (left + 1 < right)
        {
            long middle = (left + right) / 2;
            long happyFighters = 0;
            for (int i = 0; i < tubes.Length; i++)
            {
                happyFighters += tubes[i] / middle;
            }
            
            if (happyFighters >= fighters)
            {
                left = middle;
            }
            else
            {
                right = middle;
            }
        }
        return left;
    }

    static void Main()
    {
        int n, m;
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        long[] tubeSizes = new long[n];
        long sum = 0;
        for (int i = 0; i < tubeSizes.Length; i++)
        {
            tubeSizes[i] = int.Parse(Console.ReadLine());
            sum += tubeSizes[i];
        }
        if (sum < m)
        {
            Console.WriteLine("-1");
        }
        else
        {
            long max = sum / m + 1;
            //long max = int.MaxValue;
            Console.WriteLine(FindOptimalTube(tubeSizes, 1, max, m));
        }
        //int n = 4;
        //int m = 11;
        //int[] sizes = { 803, 777, 444, 555 };
        //int max = 234;
        
        //Console.WriteLine(max);
        //Console.WriteLine(CalculateOptimalTube(m, sizes));
    }
}

