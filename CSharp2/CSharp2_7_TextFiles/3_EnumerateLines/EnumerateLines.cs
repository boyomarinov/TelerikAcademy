using System;
using System.IO;

class EnumerateLines
{
    static void Enumerate(string file, string output)
    {
        int lineNumber = 1;
        string line = string.Empty;
        StreamReader reader = new StreamReader(file);
        StreamWriter writer = new StreamWriter(output);
        using (reader)
        {
            using (writer)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    line = lineNumber.ToString() + " " + reader.ReadLine();
                    writer.WriteLine(line);
                    lineNumber++;
                }
            }
        }
    }
    static void Main()
    {
        Enumerate("../../EnumerateLines.cs", "../../output.txt");
    }
}

