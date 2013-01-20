using System;
using System.Collections.Generic;
using System.Linq;

class AddPolynomials
{
    static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    static string GetDegree(string str)
    {
        string res;
        string temp = "";
        string variableX = "x";
        //x^0 = 1, free member
        if (!str.Contains(variableX))
        {
            res = "0";
        }
        //degree is one
        else if (str[str.Length - 1] == 'x')
        {
            res = "1";
        }
        else
        {
            int i = str.Length - 1;
            while (str[i] != '^' && i >= 0)
            {
                temp += str[i];
                i--;
            }
            res = ReverseString(temp);
        }

        return res;
    }
    static string GetCoef(string str)
    {
        string res = "";
        if (str.Length == 1)
        {
            if (str[0] == 'x')
            {
                res = "1";
            }
            else
            {
                res = str[0].ToString();
            }
        }
        else if (str[0] == 'x')
        {
            res = "1";
        }
        else
        {
            int i = 0;
            do
            {
                res += str[i];
                i++;
            } while (str[i] != 'x');
        }
        return res;
    }
    static List<int> GetCoefficients(string str)
    {
        string[] tempCoef = str.Split();
        string maxDegreeStr = GetDegree(tempCoef[0]);
        int maxDegree = int.Parse(maxDegreeStr);
        List<string> res = new List<string>(maxDegree);
        //int size = tempCoef.Length;
        int i = 0;
        while(i < tempCoef.Length)
        {
            if (tempCoef[i] == "+" || tempCoef[i] == "-" ||
                tempCoef[i] == "*" || tempCoef[i] == "/")
            {
                //dummy size for non evaluated strings
                //size++;
                i++;
                continue;
            }
            string degree = GetDegree(tempCoef[i]);
            string coef = GetCoef(tempCoef[i]);
            //if degree mathes current degree or degree is absent but there is coef
            if (degree == maxDegree.ToString())// || (degree == "0" && coef[0] > '0' && coef[0] <= '9'))
            {
                res.Add(coef);
                i++;
            }
            else
            {
                res.Add("0");
            }
            maxDegree--; 
        }
        while (maxDegree >= 0)
        {
            res.Add("0");
            maxDegree--;
        }
        res.Reverse();
        List<int> result = res.Select(int.Parse).ToList();
        return result;
    }
    static List<int> AddPoly(List<int> first, List<int> second)
    {
        //which list is bigger
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
        if (digitToRemember > 0 && smallerSize == biggerSize)
        {
            result.Add(digitToRemember);
        }
        else
        {
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
        }
        return result;
    }
    //substract second poly from first
    static List<int> SubstractPoly(List<int> first, List<int> second)
    {
        //which list is bigger
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

        List<int> result = new List<int>();
        for (int i = 0; i < smallerSize; i++)
        {
            result.Add(first[i] - second[i]);
        }
        for (int i = smallerSize; i < biggerSize; i++)
        {
            if (whoIsBigger == 1)
            {
                result.Add(first[i]);
            }
            else
            {
                result.Add(second[i]);
            }
        }
        return result;
    }
    static List<int> MultiplyPoly(List<int> first, List<int> second)
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

        List<int> result = new List<int>();
        for (int i = 0; i < smallerSize; i++)
        {
            result.Add(first[i] * second[i]);
        }

        //after one of the lists is exhausted
        for (int i = smallerSize; i < biggerSize; i++)
        {
            if (whoIsBigger == 1)
            {
                result.Add(first[i]);
            }
            else if (whoIsBigger == 2)
            {
                result.Add(second[i]);
            }
        }

        return result;
    }
    static void Print(List<int> arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        string polynom1 = "x^2 + 5";
        string polynom2 = "x^3 + 2x^2 + 4x + 2";
        string polynom3 = "8x^5 + x";
        string polynom4 = "7x^5 + 4x^2 + 6";
        //string polynom2 = Console.ReadLine();
        //List<string> res = GetCoefficients(polynom1);
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item);
        //}
        //List<int> res = GetCoefficients(polynom2);
        List<int> respol3 = GetCoefficients(polynom3);
        List<int> respol4 = GetCoefficients(polynom4);
        Print(respol3);
        Print(respol4);
        List<int> res = AddPoly(respol3, respol4);
        List<int> substr = SubstractPoly(respol3, respol4);
        List<int> mult = MultiplyPoly(respol3, respol4);
        Print(res);
        Print(substr);
        Print(mult);
        
    }
}

