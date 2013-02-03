using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceSubstring
{
    static void Replace(string inputPath, string outputPath,
                    string toReplace, string replaceWith)
    {
        StreamReader reader = new StreamReader(inputPath);
        StreamWriter writer = new StreamWriter(outputPath);
        string line = string.Empty;
        using (reader)
        {
            using (writer)
            {
                while((line = reader.ReadLine()) != null)
                {
                    //normal replace
                    //writer.WriteLine(line.Replace("start", "finish"));

                    //replace whole word only
                    Regex regex = new Regex("\bstart\b", RegexOptions.Compiled);
                    writer.WriteLine(regex.Replace(line, "end"));
                }
            }
        }
    }
    
    static void Main()
    {

    }
}
