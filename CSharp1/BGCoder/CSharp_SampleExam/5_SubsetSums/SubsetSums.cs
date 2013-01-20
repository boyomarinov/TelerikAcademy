using System;
using System.Collections.Generic;

class SubsetSums
{
    static List<List<long>> FindSubsets(List<long> arr)
    {
        List<List<long>> subsetsCollection = new List<List<long>>();
        int loopCount = (int)Math.Pow(2, arr.Count);
        for (int i = 0; i < loopCount; i++)
        {
            List<long> subset = new List<long>();
            for (int indexOfBit = 0; indexOfBit < arr.Count; indexOfBit++)
            {
                int bit = (int)Math.Pow(2, indexOfBit) & i;
                bool bitValue = (bit > 0) ? true : false;
                if (bitValue == true)
                {
                    subset.Add(arr[indexOfBit]);
                }
            }
            subsetsCollection.Add(subset);
        }
        return subsetsCollection;
    }
    static long CalculateSum(List<long> arr)
    {
        long sum = 0;
        foreach (long item in arr)
        {
            sum += item;
        }
        return sum;
    }
    static long CheckSubsets(List<List<long>> subsets, long targetSum)
    {
        long count = 0;
        foreach (List<long> subset in subsets)
        {
            if (CalculateSum(subset) == targetSum && subset.Count > 0)
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        long targetSum;
        long n;
        long temp;
        targetSum = long.Parse(Console.ReadLine());
        n = long.Parse(Console.ReadLine());
        List<long> arr = new List<long>();
        while (n > 0)
        {
            temp = long.Parse(Console.ReadLine());
            arr.Add(temp);
            n--;
        }
        List<List<long>> allSubsets = FindSubsets(arr);
        long result = CheckSubsets(allSubsets, targetSum);
        Console.WriteLine(result);
    }
}

