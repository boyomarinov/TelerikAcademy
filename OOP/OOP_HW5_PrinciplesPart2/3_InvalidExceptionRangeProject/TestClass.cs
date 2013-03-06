using System;
using System.Globalization;

namespace InvalidExceptionRangeProject
{
    class TestClass
    {
        //Check if input is correct integer and is in range
        public static int ReadAndCheckInteger(int min, int max)
        {
            Console.Write("Enter an integer: ");
            int number;
            bool parsed = int.TryParse(Console.ReadLine(), out number);
            if (parsed)
            {
                if (number < min || number > max)
                {
                    throw new InvalidRangeException<int>("Integer is out of range.", min, max);
                }
                return number;
            }
            else
            {
                throw new ArgumentException("Input was not an integer.");
            }
        }
        public static void PrintNumber()
        {
            try
            {
                Console.WriteLine(ReadAndCheckInteger(1, 100));
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("{0}\nRange: {1} - {2}", ex.OutOfRangeMessage, ex.Start, ex.End);
            }
        }

        //Check if input is correct date and is in correct time interval
        public static DateTime ReadAndCheckDate(DateTime start, DateTime end)
        {
            const string dateFormat = "d/M/yyyy";
            DateTime date;

            Console.Write("Enter a data ( day/month/year ): ");
            
            bool parsed = DateTime.TryParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (parsed)
            {
                if (DateTime.Compare(date, start) < 0 || DateTime.Compare(date, end) > 0)
                {
                    throw new InvalidRangeException<DateTime>("Date is not in the suggested time interval.", start, end);
                }
                return date;
            }
            else
            {
                throw new ArgumentException("Input was not a date.");
            }
        }
        public static void PrintDate()
        {
            try
            {
                Console.WriteLine(ReadAndCheckDate(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31)).ToShortDateString());
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("{0}\nTime interval: {1} - {2}", ex.OutOfRangeMessage,
                    ex.Start.ToShortDateString(), ex.End.ToShortDateString());
            }
        }

        static void Main()
        {
            PrintNumber();
            PrintDate();
        }
    }
}
