using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveBadWords
{
    static string[] GetBadWords(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            string[] badWords = reader.ReadToEnd().Split();
            return badWords;
        }
    }
    //Da dovyr6a
    static void RemoveBadWordsMethod(string filePath, string badwordspath)
    {
        string[] badWords = GetBadWords(badwordspath);
        StreamReader reader = new StreamReader(filePath);
        string content = string.Empty;
        using (reader)
        {
            content = reader.ReadToEnd();
        }
        for (int i = 0; i < badWords.Length; i++)
        {
            content = content.Replace(badWords[i] + " ", string.Empty);
        }
        Console.WriteLine(content);
    }
    static void Main()
    {
        RemoveBadWordsMethod("../../input.txt", "../../badwords.txt");
    }
}
