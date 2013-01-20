using System;
using System.Numerics;

class IntegerSetFunctions
{
    static int Minimum(int[] arr)
    {
        int min = int.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }
    static int Maximum(int[] arr)
    {
        int max = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
    static long Sum(int[] arr)
    {
        long sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }
    static double Average(int[] arr)
    {
        return (double)Sum(arr) / arr.Length;
    }
    static BigInteger Product(int[] arr)
    {
        BigInteger product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }
        return product;
    }
    static void Main()
    {
        //Read input
        Console.Write("Input your integers: ");
        string[] strInput = Console.ReadLine().Split();
        int[] input = new int[strInput.Length];
        for (int i = 0; i < strInput.Length; i++)
        {
            input[i] = int.Parse(strInput[i]);
        }

        //display results
        Console.WriteLine("Minimum:\t{0}", Minimum(input));
        Console.WriteLine("Maximum:\t{0}", Maximum(input));
        Console.WriteLine("Average:\t{0}", Average(input));
        Console.WriteLine("Sum:    \t{0}", Sum(input));
        Console.WriteLine("Product:\t{0}", Product(input));
    }
}
