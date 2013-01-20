using System;

class SpellNumber
{
    static string[] underTwenty = {"Zero", "One", "Two", "Three", "Four", "Five",
                "Six", "Seven", "Eight", "Nine", "Ten",
                "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
    static string[] centArr = { "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    static string[] thousArr = {"One Hundred", "Two Hundred", "Three Hundred", "Four Hundred", "Five Hundred",
                                "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred"};
    static void NumberSpeller(int num)
    {
        if (num < 20)
        {
            Console.WriteLine(underTwenty[num]);
        }
        else if (num < 100)
        {
            int divider = num / 10;
            int remainder = num % 10;
            if (remainder == 0)
            {
                Console.WriteLine(centArr[divider - 2]);
            }
            else
            {
                Console.WriteLine(centArr[divider - 2] + " " + underTwenty[remainder]);
            }
        }
        else
        {
            int divider = num / 100;
            int remainder = num % 100;
            if (remainder == 0)
            {
                Console.WriteLine(thousArr[divider - 1]);
            }
            else
            {
                if (remainder < 20)
                {
                    Console.WriteLine(thousArr[divider - 1] + " and " + underTwenty[remainder]);
                }
                else if (remainder % 10 == 0)
                {
                    Console.WriteLine(thousArr[divider - 1] + " and " + centArr[remainder / 10 - 2]);
                }
                else
                {
                    Console.Write("{0} ", thousArr[divider - 1]);
                    NumberSpeller(num % 100);
                }
            }
        }
    }
    static void Main()
    {
        Console.Write("Spell number: ");
        int num = int.Parse(Console.ReadLine());

        NumberSpeller(num);
    }
}

