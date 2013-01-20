using System;

class MaximalSum
{
    static int[] FindMax(int[] arr, int n, int k)
    {
        int[] res = new int[k];
        int maxSum = 0;
        int currentSum = 0;
        int startIndex = 0;
        for (int i = 0; i < n - k + 1; i++)
        {
            for (int j = 0; j < k; j++)
            {
                currentSum += arr[i + j];
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = i;
            }
        }
        for (int i = 0; i < k; i++)
        {
            res[i] = arr[i + startIndex];
        }
        return res;
    }

    static void Main()
    {
        int n, k;
        Console.Write("N: ");
        n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.Write("K: ");
        k = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int[] res = FindMax(arr, n, k);
        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
    }
}
