using System;

class BinarySearch
{
    static int RecursiveBinarySearch(int[] arr, int left, int right, int value)
    {
        if (left > right)
        {
            return -1;
        }
        int middle = (left + right) / 2;
        if (arr[middle] == value)
        {
            return middle;
        }
        else if (arr[middle] < value)
        {
            return RecursiveBinarySearch(arr, middle + 1, right, value);
        }
        else
        {
            return RecursiveBinarySearch(arr, left, middle - 1, value);
        }
    }
    static int IterativeBinarySearch(int[] arr, int left, int right, int value)
    {
        while (left <= right)
        {
            int middle = (left + right) / 2;
            if (arr[middle] == value)
            {
                return middle;
            }
            else if (arr[middle] > value)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return -1;
    }
    static void Main()
    {
        int[] sortedArr = { 1, 3, 4, 5, 9, 12, 21, 23, 24, 71, 90, 99, 100 };
        int toFind = 23;

        DateTime first = DateTime.Now;
        int recursive = RecursiveBinarySearch(sortedArr, 0, 12, toFind);
        TimeSpan recursiveTime = DateTime.Now - first;
        DateTime second = DateTime.Now;
        int iterative = IterativeBinarySearch(sortedArr, 0, 12, toFind);
        TimeSpan iterativeTime = DateTime.Now - second;

        Console.WriteLine("Recursive\t Index: {0}\tTime: {1}", recursive, recursiveTime);
        Console.WriteLine("Iterative\t Index: {0}\tTime: {1}", iterative, iterativeTime);
    }
}

