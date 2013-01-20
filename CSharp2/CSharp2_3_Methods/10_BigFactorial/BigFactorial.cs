using System;
using System.Collections.Generic;
using System.Text;

class BigFactorial
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
    //TODO: Proper Function
    static List<int> MultiplyNumsWithArray(List<int> first, List<int> second)
    {
        //determine which list is bigger
        int smallerSize = (first.Count < second.Count) ? first.Count : second.Count;
        int biggerSize = (first.Count > second.Count) ? first.Count : second.Count;
        int whoIsBigger = 0;
        if (smallerSize == second.Count)
        {
            whoIsBigger = 1;
        }
        else
        {
            whoIsBigger = 2;
        }

        int temp = 0;
        int digitToAdd = 0;
        int digitToRemember = 0;
        List<int> result = new List<int>();
        for (int i = 0; i < smallerSize; i++)
        {
            temp = first[i] * second[i];
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

        for (int i = smallerSize; i < biggerSize; i++)
        {
            if (whoIsBigger == 1)
            {
                if (digitToRemember > 0)
                {
                    result.Add(digitToRemember + first[i]);
                }
                else
                {
                    result.Add(first[i]);
                }
            }
            else if (whoIsBigger == 2)
            {
                if (digitToRemember > 0)
                {
                    result.Add(digitToRemember + second[i]);
                }
                else
                {
                    result.Add(second[i]);
                }
            }
        }

        return result;
    }
    static void Print(List<int> list)
    {
        StringBuilder str = new StringBuilder();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            str.Append(list[i]);
        }
        Console.WriteLine(str);
    }
    static void Main()
    {
        int a = 11;
        int b = 8;
        Print(MultiplyNumsWithArray(NumToDigitArray(a), NumToDigitArray(b)));
        //List<int> temp = new List<int>();
        //List<List<int>> factorials = new List<List<int>>();
        //List<int> first = new List<int>();
        //first.Add(1);
        ////0! = 1 and 1! = 1
        //factorials.Add(first);
        //factorials.Add(first);
        //for (int x = 2; x < 100; x++)
        //{
        //    temp = NumToDigitArray(x);
        //    factorials.Add(MultiplyNumsWithArray(temp, factorials[x - 1]));
        //}
        //for (int i = 0; i < 10; i++)
        //{
        //    Print(factorials[i]);
        //}
    }
}

