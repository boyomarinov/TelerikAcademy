using System;
using System.Collections.Generic;
using System.Text;

class ExactSubsetSumWithLength
{
    static void FindExactSubsetWithLength(List<int> arr, int subsetLength, int target)
    {
        int count = (int)Math.Pow(2, arr.Count);
        int currentSum = 0;
        bool foundSubset = false;
        StringBuilder str = new StringBuilder();
        int subsetCount = 0;

        for (int i = 1; i <= count; i++)
        {
            for (int j = 0; j < arr.Count; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    if (currentSum == 0)
                    {
                        str.Append(arr[j]);
                    }
                    else
                    {
                        str.Append("+").Append(arr[j]);
                    }
                    currentSum += arr[j];
                    subsetCount++;
                }
            }
            if (currentSum == target && subsetCount == subsetLength)
            {
                Console.WriteLine("Yes({0})", str);
                foundSubset = true;
                break;
            }
            else
            {
                currentSum = 0;
                subsetCount = 0;
                str.Clear();
            }
        }
        if (foundSubset == false)
        {
            Console.WriteLine("Subset with this sum does not exist");
        }
    }
    static void Main()
    {
        int n, k, s;
        List<int> arr = new List<int>(){2, 1, 2, 4, 3, 5, 2, 6 };
        k = 3;
        s = 7;

        FindExactSubsetWithLength(arr, k, s);
    }
}

