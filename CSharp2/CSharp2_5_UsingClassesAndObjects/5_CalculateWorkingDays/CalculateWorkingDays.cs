using System;
using System.Collections.Generic;
using System.Linq;

class CalculateWorkingDays
{
    static List<DateTime> officialHolidays = new List<DateTime>(){
        new DateTime(2013, 01, 01), new DateTime(2013, 01, 02), new DateTime(2013, 03, 03), 
        new DateTime(2013, 05, 01), new DateTime(2013, 05, 24), new DateTime(2013, 09, 22), 
        new DateTime(2013, 10, 01), new DateTime(2013, 12, 24), new DateTime(2013, 12, 25),
        new DateTime(2013, 12, 26)};

    static List<DateTime> GetAllDays(DateTime from, DateTime to)
    {
        List<DateTime> dates = new List<DateTime>();
        for (var dt = from; dt <= to; dt = dt.AddDays(1))
        {
            dates.Add(dt);
        }
        return dates;
    }

    static bool IsWorkingDay(DateTime date)
    {
        return (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            && !officialHolidays.Contains(date);
    }
    
    static int CalcWorkingDays(DateTime from, DateTime to)
    {
        List<DateTime> allDates = GetAllDays(from, to);
        return allDates.Where(day => IsWorkingDay(day)).Count();
    }

    static void Main()
    {
        Console.WriteLine(CalcWorkingDays(new DateTime(2013, 01, 22), new DateTime(2013, 01, 29)));
    }
}
