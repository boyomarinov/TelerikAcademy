using System;
using System.IO;

class CompareFiles
{
    static void Compare(string pathToFile1, string pathToFile2)
    {
        string lineFromFirst = string.Empty;
        string lineFromSecond = string.Empty;
        string equal = string.Empty;
        string different = string.Empty;
        int lineNumber = 1;

        StreamReader first = new StreamReader(pathToFile1);
        StreamReader second = new StreamReader(pathToFile2);
        using (first)
        {
            using (second)
            {
                while ((lineFromFirst = first.ReadLine()) != null && (lineFromSecond = second.ReadLine()) != null)
                {
                    if (string.Compare(lineFromFirst, lineFromSecond) == 0)
                    {
                        equal += lineNumber + " ";
                    }
                    else
                    {
                        different += lineNumber + " ";
                    }
                    lineNumber++;
                }
            }
        }
        Console.WriteLine("Equal lines: {0}", equal);
        Console.WriteLine("Different lines: {0}", different);
    }
    static void Main()
    {
        Compare("../../a.txt", "../../b.txt");
    }
}
