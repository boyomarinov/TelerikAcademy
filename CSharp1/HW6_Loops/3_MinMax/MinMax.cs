using System;

class MinMax
{
    static int Max(int[] arr, int size)
    {
        int max = -2147483646;
        for (int i = 0; i < size; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
    static int Min(int[] arr, int size)
    {
        int min = 2147483646;
        for (int i = 0; i < size; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }
    static void Main()
    {
        Console.Write("How many numbers will you input? ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input numbers: ");
        string[] userInput = Console.ReadLine().Split();
        int[] arr = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(userInput[i]);
        }
        Console.WriteLine("Min: {0}", Min(arr, n));
        Console.WriteLine("Max: {0}", Max(arr, n));
    }
}

