using System;

class ReverseDigits
{
    static int GetLength(int num)
    {
        int len = 0;
        while (num > 0)
        {
            num /= 10;
            len++;
        }
        return len;
    }
    static int Reverse(int num)
    {
        if (num < 10)
        {
            return num;
        }

        int result = 0;
        int digitsCount = GetLength(num);
        int degree = digitsCount-1;

        for (int i = 1; i <= digitsCount; i++)
        {
            result += (int)((num % 10) * Math.Pow((double)10, (double)degree));
            degree--;
            num /= 10;
        }
        return result;
    }
    static void Main()
    {
        int num = 256;
        Console.WriteLine(Reverse(num));
    }
}
