using System;

class HexBin
{
    static char[] hex = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                  'A', 'B', 'C', 'D', 'E', 'F'};

    static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
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
    static int Pow(int numBase, int deg)
    {
        int res = 1;
        for (int i = 0; i < deg; i++)
        {
            res *= numBase;
        }
        return res;
    }
    static string ConvertHexToBinary(string str)
    {
        string res = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            int temp = GetIndexOfHex(str[i]);
            for (int j = 0; j < 4; j++)
            {
                res += temp % 2;
                temp /= 2;
            }
            
        }
        return ReverseString(res);
    }

    static string ConvertBinaryToHex(string bin)
    {
        //fill with zeros if missing
        if (bin.Length % 4 != 0)
        {
            return ConvertBinaryToHex(new String('0', 4 - bin.Length % 4) + bin);
        }

        int res = 0;
        int hexDegree = 0;
        for (int i = bin.Length - 1; i >= 0; i -= 4)
        {
            //get portion of 4 bits
            int part = 0;
            int coef = 8;
            //convert it to decimal
            for (int j = 3; j >= 0; j--)
            {
                part += coef * (bin[i - j] - '0');
                coef /= 2;
            }
            //get hex rappresentation and add it to the result
            res += part * Pow(16, hexDegree);
            hexDegree++;
        }
        return res.ToString();
    }
   
    static void Main()
    {
        string bin = ConvertHexToBinary("15");
        Console.WriteLine(bin);
        string hexnum = ConvertBinaryToHex(bin);
        Console.WriteLine(hexnum);
    }
}

