using System;
using System.Collections.Generic;

class ZeroSubset
{
    static List<List<int>> FindSubsets(List<int> arr)
    {
        List<List<int>> subsetsCollection = new List<List<int>>();
        int loopCount = (int)Math.Pow(2, arr.Count);
        for(int i=0; i<loopCount; i++)
        {
            List<int> subset = new List<int>();
            for(int indexOfBit = 0; indexOfBit < arr.Count; indexOfBit++)
            {
                int bit = (int)Math.Pow(2, indexOfBit) & i;
                bool bitValue = (bit > 0) ? true : false;
                if(bitValue == true)
                {
                    subset.Add(arr[indexOfBit]);
                }
            }
            subsetsCollection.Add(subset);
        }
        return subsetsCollection;
    }

    static bool CheckSubsets(List<List<int>> subsets)
    {
        bool found = false;
        foreach (List<int> subset in subsets)
        {
            if (CalculateSum(subset) == 0 && subset.Count > 0)
            {
                found = true;
                break;
            }
        }
        return found;
    }

    static int CalculateSum(List<int> arr)
    {
        int sum = 0;
        foreach (int item in arr)
        {
            sum += item;
        }
        return sum;
    }

    static void Main()
    {
        Console.Write("Input numbers: ");
        string[] stringInput = Console.ReadLine().Split();
        List<int> input = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int parsed = int.Parse(stringInput[i]);
            input.Add(parsed);
        }
        List<List<int>> allSubsets = FindSubsets(input);
        bool result = CheckSubsets(allSubsets);
        if (result == true)
        {
            Console.WriteLine("Zero-sum subset found!");
        }
        else
        {
            Console.WriteLine("No zero-sum subset.");
        }
    }
}

