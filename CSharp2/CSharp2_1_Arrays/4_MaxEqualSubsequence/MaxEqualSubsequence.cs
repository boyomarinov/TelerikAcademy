using System;
using System.Collections.Generic;

class MaxEqualSubsequence
{
    static string MaxSubsequence(int[] arr, int size)
    {
        int element = 0;
        int previous = 0;
        int currentMax = 0;
        int max = 0;
        bool isFirst = true;
        for (int i = 0; i < size; i++)
        {
            if (!isFirst && previous.Equals(arr[i]))
            {
                currentMax++;
            }
            else
            {
                isFirst = false;
                currentMax = 1;
            }

            if (currentMax > max)
            {
                max = currentMax;
                element = arr[i];
            }
            previous = arr[i];
        }
        string res = "{";
        for (int i = 0; i < max-1; i++)
        {
            res += element;
            res += ", ";
        }
        res += element + "}";
        return res;
    }
    static void Main()
    {
        int[] arr = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int size = 10;
        Console.WriteLine(MaxSubsequence(arr, size));
    }
}

