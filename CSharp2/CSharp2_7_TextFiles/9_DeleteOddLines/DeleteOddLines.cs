using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    static void DeleteOddLinesOfFile(string filePath)
    {
        List<string> lines = new List<string>();
        string line = string.Empty;
        
        //read file line by line
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }

        //clear content of file
        File.WriteAllText(filePath, string.Empty);

        //write only odd lines in file
        StreamWriter writer = new StreamWriter(filePath);
        using (writer)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                //match even lines because they will be
                //the odd ones from the original file
                if (i % 2 == 0)
                {
                    writer.WriteLine(lines[i]);
                }
            }
        }
    }
    static void Main(string[] args)
    {
        DeleteOddLinesOfFile("../../numbers.txt");
    }
}

