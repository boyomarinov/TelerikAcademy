using System;

class SubarrayExactSum
{
    static void PrintNums(int[] arr, int start, int end)
    {
        string res = "{";
        for (int i = start; i < end; i++)
        {
            res += arr[i] + ", ";
        }
        res += arr[end] + "}";
        Console.WriteLine(res);
    }
    static void subArrayTargetSum(int[] arr, int size, int target)
    {
        int start = 0;
        int currentSum = arr[0];
        for (int i = 1; i <= size; i++)
        {
            while (currentSum > target && start < i - 1)
            {
                currentSum -= arr[start];
                start++;
            }
            if (currentSum == target)
            {
                PrintNums(arr, start, i - 1);
                return;
            }
            if (i < size)
            {
                currentSum += arr[i];
            }
        }
        Console.WriteLine("There is no sequence matching the given sum.");
    }
    static void Main()
    {
        //input
        int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
        int target = 11;
        subArrayTargetSum(arr, 7, target);
    }
}
