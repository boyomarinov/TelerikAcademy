using System;
using System.Collections.Generic;

class MaxHomoSubsequence
{
    static string MaxIncreasingSubSequence(int[] arr, int size)
    {
        List<int> elements = new List<int>();
        int maxStart = 0;
        int currentStart = 0;
        int sequenceLength = 1;
        for (int i = 1; i < size; i++)
        {
            if (arr[i - 1] < arr[i])
            {
                if (i - currentStart + 1 > sequenceLength)
                {
                    maxStart = currentStart;
                    sequenceLength = i - currentStart + 1;
                }
                
            }
            else
            {
                currentStart = i;
            }
        }
        string res = "{";
        for (int i = maxStart; i < sequenceLength; i++)
        {
            res += arr[i];
            res += ", ";
        }
        res += arr[sequenceLength] + "}";
        return res;
    }

    static void Main()
    {
        int[] arr = { 3, 2, 3, 4, 2, 2, 4 };
        Console.WriteLine(MaxIncreasingSubSequence(arr, 7));
    }
}

