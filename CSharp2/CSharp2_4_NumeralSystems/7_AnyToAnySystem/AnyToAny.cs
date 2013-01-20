using System;

class AnyToAny
{
    static char[] hex = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                  'A', 'B', 'C', 'D', 'E', 'F'};

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
    static int ConvertXtoDec(string str, int baseNum)
    {
        int result = 0;
        int coef = 1;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            result += coef * GetIndexOfHex(str[i]);
            coef *= baseNum;
        }

        return result;
    }
    static string ConvertDecToY(int decimalNum, int baseNum)
    {
        string res = "";
        while(decimalNum > 0)
        {
            int remainder = decimalNum % baseNum;
            res = hex[remainder] + res;
            decimalNum /= baseNum;
        }
        return res;
    }
    static string ConvertXtoY(string xNum, int xBase, int yBase)
    {
        return ConvertDecToY(ConvertXtoDec(xNum, xBase), yBase);
    }

    static void Main()
    {
        Console.WriteLine(ConvertXtoY("15", 10, 16));
    }
}
