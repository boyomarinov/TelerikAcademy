using System;

class HexDec
{
    static char[] hex = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                  'A', 'B', 'C', 'D', 'E', 'F'};

    static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
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
    static int GetIndexOfHex(char c)
    {
        int res = -1;
        for (int i = 0; i < 16; i++)
        {
            if (hex[i] == c)
            {
                res = i;
                break;
            }
        }
        return res;
    }

    static string ConvertDecToHex(int num)
    {
        string res = "";
        if (num == 1)
        {
            res = "1";
            return res;
        }
        int temp = 0;
        while (num > 0)
        {
            temp = num % 16;
            res += hex[temp];
            num /= 16;
        }
        res = ReverseString(res);
        return res;
    }
   
    static int ConvertHexToDec(string str)
    {
        int res = 0;
        int degree = str.Length - 1;
        for (int i = 0; i < str.Length; i++)
        {
            int coef = GetIndexOfHex(str[i]);
            res += coef * Pow(16, degree);
            degree--;
        }
        return res;
    }
    static void Main()
    {
        string hexnum = ConvertDecToHex(21);
        Console.WriteLine(hexnum);
        int decnum = ConvertHexToDec(hexnum);
        Console.WriteLine(decnum);
    }
}

