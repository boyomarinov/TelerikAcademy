using System;
using System.Globalization;

class AddTimeToDate
{
    static void Main()
    {
        //string date = Console.ReadLine();
        string date = "26.01.2013 8:00:00";
        DateTime original = DateTime.ParseExact(date, "d.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);
        original.AddHours(6).AddMinutes(30);
        Console.WriteLine("{0:d.MM.yyyy H:mm:ss dddd}", original);
    }
}

