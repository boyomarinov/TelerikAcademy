using System;
using System.Globalization;

class DaysInBetween
{
    static void Main()
    {
        //string first = "27.02.2006";
        //string second = "3.03.2004";
        Console.WriteLine("Enter two dates in the specified format: (day.month.year)");
        Console.Write("Enter first date: ");
        string first = Console.ReadLine();
        Console.Write("Enter second date: ");
        string second = Console.ReadLine();

        DateTime start = DateTime.ParseExact(first, "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(second, "d.MM.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Distance: {0} days", (start - end).TotalDays);
    }
}
