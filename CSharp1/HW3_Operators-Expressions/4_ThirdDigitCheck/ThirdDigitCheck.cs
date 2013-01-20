using System;

class ThirdDigitCheck
{
    static bool CheckDigit(int num)
    {
        if (num < 100)
        {
            return false;
        }
        else if (num < 1000)
        {
            return (num / 100 == 7);
        }
        else
        {
            return ((num / 100) % 10 == 7);
        }
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Third digit from right to left equals 7? {0}", CheckDigit(number));
        Console.WriteLine();
    }
}

