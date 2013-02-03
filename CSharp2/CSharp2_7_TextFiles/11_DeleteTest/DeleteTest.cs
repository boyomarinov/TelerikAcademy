using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteTest
{
    static void DeleteTestWords(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        string content = string.Empty;
        using (reader)
        {
            content = reader.ReadToEnd();
        }
        Regex matchTestWords = new Regex("test(\\w+)", RegexOptions.Compiled);
        content = matchTestWords.Replace(content, string.Empty);
        //TODO: remove dead space or not?
        Console.WriteLine(content);
    }
    static void Main()
    {
        DeleteTestWords("../../deleteTest.txt");
    }
}