using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class UpCase
{
    static string ChangeUpCase(string text)
    {
        Regex upcase = new Regex("<upcase>(.*?)</upcase>");

        MatchCollection matches = upcase.Matches(text);
        for (var i = 0; i < matches.Count; i++)
        {
            text = text.Replace(matches[i].ToString(), matches[i].Groups[1].ToString().ToUpper());
        }
        return text;
    }
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(ChangeUpCase(text));
    }
}
