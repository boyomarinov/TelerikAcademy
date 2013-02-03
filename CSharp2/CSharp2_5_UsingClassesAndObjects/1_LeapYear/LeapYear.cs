using System;

class LeapYear
{
    //an year is leap if is divisible by 400 OR
    //divisible by 4 and 100 at the same time
    static bool CheckLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 == 0);
    }

    static void Main()
    {
        Console.Write("Check if year is leap: ");
        int year = int.Parse(Console.ReadLine());
        if (CheckLeapYear(year))
        {
            Console.WriteLine("Year is leap.");
        }
        else
        {
            Console.WriteLine("Year is not leap.");
        }
    }
}
