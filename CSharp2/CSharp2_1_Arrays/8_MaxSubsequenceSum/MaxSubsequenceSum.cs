using System;

class MaxSubsequenceSum
{
    static void Main()
    {
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int startIndex = 0;
        int endIndex = 0;
        int maxSum = arr[0];
        int currSum = arr[0];
        int currIndex = 0;

        for (int i = 1; i < 9; i++)
        {
            if (currSum > 0)
            {
                currSum += arr[i];
            }
            else
            {
                currSum = arr[i];
                currIndex = i;
            }

            if (currSum > maxSum)
            {
                maxSum = currSum;
                startIndex = currIndex;
                endIndex = i;
            }
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.WriteLine(arr[i]);
        }

    }
}

