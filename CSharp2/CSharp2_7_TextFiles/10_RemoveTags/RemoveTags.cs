using System;
using System.IO;
using System.Text.RegularExpressions;

class RemoveTags
{
    static void ExtractInfo(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        string content = string.Empty;
        using (reader)
        {
            content = reader.ReadToEnd();
        }
        Regex regex = new Regex("<[^<>]+>", RegexOptions.Compiled);
        content = regex.Replace(content, string.Empty);
        Console.WriteLine(content);
    }
    static void Main()
    {
        ExtractInfo("../../tags.txt");
    }
}
