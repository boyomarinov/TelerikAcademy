using System;
using System.Text;
using System.Text.RegularExpressions;

class MatchEmail
{
    static void ExtractEmails(string input)
    {
        //HTML5 W3C email regex
        string simpleEmailRegex = @"[a-zA-Z0-9.!#$%&'*+-/=?\^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*";
        MatchCollection emails = Regex.Matches(input, simpleEmailRegex);
        foreach (Match item in emails)
        {
            Console.WriteLine(item);
        }
    }
    static void Main()
    {
        string input = "balabsdlk()someemail@abv.bg sdfhj32 ;hello@yahoo.com";
        ExtractEmails(input);
    }
}
