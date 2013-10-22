using System;
using System.Collections.Generic;
using System.Linq;
using CurrentDayClient.DayOfWeekService;

namespace CurrentDayClient
{
    public static class Program
    {
        public static void Main()
        {
            DayOfWeekServiceClient dayOfWeekClient = new DayOfWeekServiceClient();
            string result = dayOfWeekClient.GetDayOfWeek(DateTime.Now);
            Console.WriteLine(result);
        }
    }
}
