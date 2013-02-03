using System;
using System.Text.RegularExpressions;
using System.Globalization;

class MatchDates
{
    static void ExtractDates(string input)
    {
        CultureInfo canadaFormat = new CultureInfo("en-CA");
        string dateRegex = @"\b[0-2][0-9].[0-1][0-9].[0-9]{4}\b";
        MatchCollection dates = Regex.Matches(input, dateRegex);
        for (int i = 0; i < dates.Count; i++)
        {
            string matched = dates[i].ToString();
            DateTime date = DateTime.ParseExact(matched, "dd.MM.yyyy", CultureInfo.GetCultureInfo("en-CA"));
            Console.WriteLine(date.ToString("d", canadaFormat));
        }
    }
    static void Main()
    {
        string input = "Some random dates to parse 26.01.2013, 01.01.1900";
        ExtractDates(input);
    }
}
