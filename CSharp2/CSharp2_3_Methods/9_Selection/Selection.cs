using System;
using System.Collections.Generic;

class Selection
{
    static int FindPositionOfMax(int[] arr, int start)
    {
        int max = 0;
        int maxIndex = 0;
        for (int i = start; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }
    static void SwapElementsInArray(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
    static void SortDescending(int[] arr)
    {
        int index = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            index = FindPositionOfMax(arr, i);
            if (index != i && arr[i-1] < arr[index])
            {
                SwapElementsInArray(arr, i - 1, index);
            }
        }
    }
    static void SortAscending(int[] arr)
    {
        SortDescending(arr);
        Array.Reverse(arr);
    }
    static void Main()
    {
        int[] arr = { 1, 3, 6, 2, 9, 4, 7 };
        //SortDescending(arr);
        //foreach (var item in arr)
        //{
        //    Console.WriteLine(item);
        //}
        //SortAscending(arr);
        //foreach (var item in arr)
        //{
        //    Console.WriteLine(item);
        //}
    }
}

