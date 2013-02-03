using System;
using System.Text.RegularExpressions;

class ReplaceBadWords
{
    static string ReplaceWords(string input, string word)
    {
        //modify regex to match a whole word: \bword\b ??
        Regex wordRegex = new Regex(word, RegexOptions.Compiled);
        input = wordRegex.Replace(input, new string('*', word.Length));
        return input;
    }
    static void Main()
    {
        string input = "Microsoft announced its next generation PHP compiler today." +
            "It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string php = "PHP";
        string microsoft = "Microsoft";
        string clr = "CLR";
        string res = string.Empty;
        res = ReplaceWords(input, microsoft);
        res = ReplaceWords(res, php);
        res = ReplaceWords(res, clr);
        Console.WriteLine(res);

    }
}
