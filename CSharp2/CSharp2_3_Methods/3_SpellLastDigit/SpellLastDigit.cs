using System;

class SpellLastDigit
{
    static string[] digits = {"zero", "one", "two", "three", "four", "five",
                      "six", "seven", "eight", "nine"};

    static void SpellLast(int num)
    {
        Console.WriteLine(digits[num % 10]);
    }

    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        SpellLast(num);
    }
}

