using System;
using System.Collections.Generic;
using System.Text;

class SubsetExamSum
{
    static void FindExactSumSubset(List<int> arr, int size, int target)
    {
        bool[] check = new bool[size];
        int currentSum = 0;

        for (int i = 0; i < size; i++)
        {
            currentSum += arr[i];
            if (currentSum == target)
            {
                check[i] = true;
            }
            else if (currentSum > target || arr.Contains(arr[i]))
            {
                currentSum -= arr[i];
                check[i] = false;
            }
            else if (currentSum < target)
            {
                check[i] = true;
            }
        }

        string res = "yes (";
        for (int i = 0; i < size; i++)
        {
            if (check[i] == true)
            {
                res += arr[i] + "+";
            }
        }
        res = res.Substring(0, res.Length - 1) + ")";
        if (res == "yes (")
        {
            Console.WriteLine("No subset found");
        }
        else
        {
            Console.WriteLine(res);
        }
    }

    static void FindExactSubset(List<int> arr, int target)
    {
        int count = (int)Math.Pow(2, arr.Count);
        int currentSum = 0;
        bool foundSubset = false;
        StringBuilder str = new StringBuilder();
        
        for (int i = 1; i <= count; i++)
        {
            for (int j = 0; j < arr.Count; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    if(currentSum == 0)
                    {
                        str.Append(arr[j]);
                    }
                    else
                    {
                        str.Append("+").Append(arr[j]);
                    }
                    currentSum += arr[j];
                }
            }
            if (currentSum == target)
            {
                Console.WriteLine("Yes({0})", str);
                foundSubset = true;
                break;
            }
            else
            {
                currentSum = 0;
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
        List<int> arr = new List<int>(){ 2, 1, 2, 4, 3, 5, 2, 6 };
        int target = 14;

        FindExactSubset(arr, target);
    }
}

