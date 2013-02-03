using System;
using System.Collections.Generic;
using System.IO;

class SortNames
{
    static void OutputSorted(string input, string output)
    {
        List<string> lines = new List<string>();
        string line = string.Empty;
        StreamReader reader = new StreamReader(input);
        //read all lines from input
        using (reader)
        {
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        //default sort sorts lines lexicographically
        lines.Sort();
        
        //now write lines in the output file
        StreamWriter writer = new StreamWriter(output);
        using (writer)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i]);
            }
        }
    }

    static void Main()
    {
        OutputSorted("../../input.txt", "../../output.txt");
    }
}
