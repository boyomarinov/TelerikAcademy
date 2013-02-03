using System;
using System.Text.RegularExpressions;

class ParseHTML
{
    static void ExtractInfoFromHTMLTags(string input)
    {
        string pattern = ">(.*?)<";
        Regex innerTag = new Regex(pattern);
        MatchCollection matches = innerTag.Matches(input);
        for (int i = 0; i < matches.Count; i++)
        {
            if (String.IsNullOrWhiteSpace(matches[i].Groups[1].Value))
            {
                continue;
            }
            Console.WriteLine(matches[i].Groups[1].Value);
        }
    }
    static void Main()
    {
        string input = "<html><head><title>News</title></head><body><p><a href=" +
                "\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free" +
                " real-world practical training for young people who want to turn into skillful " +
                ".NET software engineers.</p></body></html>";
        ExtractInfoFromHTMLTags(input);
    }
}
