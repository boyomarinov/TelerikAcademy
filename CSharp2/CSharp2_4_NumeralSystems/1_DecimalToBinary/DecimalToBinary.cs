using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static List<int> ConvertDecToBin(int num)
    {
        List<int> res = new List<int>();
        if (num == 1)
        {
            res.Add(1);
            return res;
        }
        int temp = 0;
        while (num > 1)
        {
            temp = num % 2;
            res.Add(temp);
            num /= 2;
        }
        if (res[res.Count - 1] == 0)
        {
            res.Add(1);
        }
        res.Reverse();
        return res;
    }
    static int Pow(int numBase, int deg)
    {
        int res = 1;
        for (int i = 0; i < deg; i++)
        {
            res *= numBase;
        }
        return res;
    }
    static int ConvertBinaryToDec(List<int> arr)
    {
        int res = 0;
        int degree = arr.Count - 1;
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == 1)
            {
                res += Pow(2, degree);
            }
            degree--;
        }
        return res;
    }
    static void Main()
    {
        List<int> res = ConvertDecToBin(11);
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item);
        //}
        int dec = ConvertBinaryToDec(res);
        Console.WriteLine(dec);
    }
}

