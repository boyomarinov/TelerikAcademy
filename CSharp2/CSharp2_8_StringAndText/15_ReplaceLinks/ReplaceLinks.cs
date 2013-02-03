using System;
using System.Text.RegularExpressions;

class ReplaceLinks
{
    static string ReplaceLinksInText(string input)
    {
        string matchLinks = "<a href=\"(.*?)\">(.*?)</a>";
        var match = Regex.Match(input, matchLinks);
        string link = match.Groups[1].ToString();
        string value = match.Groups[1].ToString();
        string replacement = "[URL=" + link + "]" + value + "[/URL]"; 
        string result = Regex.Replace(input, matchLinks, replacement);
        return result;
    }
    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        string result = ReplaceLinksInText(text);
        Console.WriteLine(result);
    }
}
