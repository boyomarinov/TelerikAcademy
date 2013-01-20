using System;
using System.Collections.Generic;

class AddNumbers
{
    static List<int> NumToDigitArray(int num)
    {
        List<int> numArray = new List<int>();
        int digit = 0;
        while (num > 0)
        {
            digit = num % 10;
            numArray.Add(digit);
            num /= 10;
        }
        return numArray;
    }
    static int ArrayToNum(List<int> arr)
    {
        int result = 0;
        int degree = arr.Count - 1;
        for (int i = arr.Count - 1; i >= 0; i--)
        {
            result += (int)(arr[i] * Math.Pow((double)10, (double)degree));
            degree--;
        }
        return result;
    }
    static int AddNumsWithArray(int a, int b)
    {
        List<int> first = NumToDigitArray(a);
        List<int> second = NumToDigitArray(b);
        int size = (first.Count < second.Count) ? first.Count : second.Count;
        int temp = 0;
        int digitToAdd = 0;
        int digitToRemember = 0;
        List<int> result = new List<int>();
        for (int i = 0; i < size; i++)
        {
            temp = first[i] + second[i];
            if (temp > 9)
            {
                digitToAdd = temp % 10;
                result.Add(digitToAdd + digitToRemember);
                digitToRemember = temp / 10;
            }
            else
            {
                digitToAdd = temp;
                result.Add(digitToAdd);
                digitToRemember = 0;
            }
        }
        if (digitToRemember > 0)
        {
            result.Add(digitToRemember);
        }
        int toReturn = ArrayToNum(result);
        return toReturn;
    }
    static void Main()
    {
        int a = 1;
        int b = 9;
        List<int> list = NumToDigitArray(a);
        //foreach (var item in list)
        //{
        //    Console.WriteLine(item);
        //}
        //Console.WriteLine(ArrayToNum(list));
        int res = AddNumsWithArray(a, b);
        Console.WriteLine(res);
    }


}

