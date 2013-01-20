using System;
using System.Collections.Generic;

class LeatMajorityMultiple
{
    static List<List<int>> GenerateTriads(List<int> arr)
    {
        List<List<int>> triads = new List<List<int>>();
        for (int first = 0; first < 3; first++)
        {
            for (int second = first + 1; second < 4; second++)
            {
                for (int third = second + 1; third < 5; third++)
                {
                    List<int> toAdd = new List<int>();
                    toAdd.Add(arr[first]);
                    toAdd.Add(arr[second]);
                    toAdd.Add(arr[third]);
                    triads.Add(toAdd);
                }
            }
        }
        return triads;
    }
    static int GCD(int a, int b)
    {
        int temp = 0;
        if (b == 0)
        {
            return a;
        }
        while (b != 0)
        {
            temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    static int LCM(int a, int b)
    {
        return (Math.Abs(a * b)) / GCD(a, b);
    }
    static int LCMTriad(List<int> arr)
    {
        return LCM(LCM(arr[0], arr[1]), arr[2]);
    }
    static void Print(List<List<int>> arr)
    {
        foreach (List<int> item in arr)
        {
            Console.WriteLine("[{0}, {1}, {2}]", item[0], item[1], item[2]);
        }
    }
    static void Main()
    {
        int a, b, c, d, e;
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());
        d = int.Parse(Console.ReadLine());
        e = int.Parse(Console.ReadLine());
        List<int> array = new List<int>();
        array.Add(a);
        array.Add(b);
        array.Add(c);
        array.Add(d);
        array.Add(e);
        List<List<int>> allTriads = GenerateTriads(array);
        int min = int.MaxValue;
        foreach (List<int> item in allTriads)
        {
            int triadLCM = LCMTriad(item);
            if (triadLCM < min)
            {
                min = triadLCM;
            }
        }
        Console.WriteLine(min);
        //Print(GenerateTriads(array));
    }
}

