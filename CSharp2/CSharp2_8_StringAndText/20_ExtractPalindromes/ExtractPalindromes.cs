using System;
using System.Text.RegularExpressions;

class ExtractPalindromes
{
    static bool IsPalindrome(string word)
    {
        bool flag = true;
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - i - 1])
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
    static void ExtractPalindromesMethod(string input)
    {
        //[A-Za-z0-9_] n-times
        string matchWord = @"\w+";
        MatchCollection words = Regex.Matches(input, matchWord);
        for (int i = 0; i < words.Count; i++)
        {
            if (IsPalindrome(words[i].ToString()))
            {
                Console.WriteLine(words[i].ToString());
            }
        }
    }
    static void Main()
    {
        string input = "ABBA - spaghetti? lamal, exe!";
        ExtractPalindromesMethod(input);
    }
}
