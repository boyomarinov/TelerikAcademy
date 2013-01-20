using System;
using System.Collections.Generic;

class LongestIncreasingSubset
{
    static void TrackLongestSubset(int[] arr, int[] pred, List<int> res, int index, int count)
    {
        int i = 0;
        if (count == 0) return;
        res.Add(arr[index]);
        TrackLongestSubset(arr, pred, res, pred[index], count - 1);
    }
    static void Main()
    {
        int n = 9;
        // Console.WriteLine("Count: ");
        //int n = int.Parse(Console.ReadLine());
        //string[] numbersString = Console.ReadLine().Split();
        int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int[] length = new int[n+1];
        int[] pred = new int[n+1];
        List<int> result = new List<int>();
        //for (int i = 0; i < n; i++)
        //{
        //    array[i] = int.Parse(numbersString[i]);
        //}

        length[0] = 1;
        pred[0] = -1;
        int maxIndex = 0;
        int maxLen = 1;
        for (int i = 1; i < n; i++)
        {
            length[i] = 1;
            pred[i] = -1;
            for (int j = i - 1; j >= 0; j--)
            {
                if ((array[j] <= array[i]) && (length[i] < length[j] + 1))
                {
                    length[i] = length[j] + 1;
                    pred[i] = j;
                }
            }

            if (length[i] > maxLen)
            {
                maxIndex = i;
                maxLen = length[i];
            }

        }

        TrackLongestSubset(array, pred, result, maxIndex, maxLen);

        result.Reverse();
        foreach (var item in result)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}

