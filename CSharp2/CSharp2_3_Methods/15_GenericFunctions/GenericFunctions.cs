using System;

class GenericFunctions
{
    static T Max<T>(T[] arr) where T : IComparable<T>
    {
        int indexOfMax = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(arr[indexOfMax]) < 0)
            {
                indexOfMax = i;
            }
        }
        return arr[indexOfMax];
    }
    static T Min<T>(T[] arr) where T : IComparable<T>
    {
        int indexOfMin = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(arr[indexOfMin]) > 0)
            {
                indexOfMin = i;
            }
        }
        return arr[indexOfMin];
    }
    static T Sum<T>(T[] arr)
    {
        dynamic sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }
    static T Average<T>(T[] arr)
    {
        return Sum(arr) / (dynamic)arr.Length;
    }
    static T Product<T>(T[] arr)
    {
        dynamic product = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }
        return product;
    }

    static void Main()
    {
        int[] ints = { 1, 2, 3, 4 };
        double[] doubles = { 1.5, 2, 2.5 };

        Console.WriteLine(Sum(ints));
        Console.WriteLine(Average(doubles));
    }
}

