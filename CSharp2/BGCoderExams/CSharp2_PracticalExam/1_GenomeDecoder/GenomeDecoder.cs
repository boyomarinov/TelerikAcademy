using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int lineSize, groupSize, lineNumberChars;
    static StringBuilder output = new StringBuilder();

    static void CoolPrint()
    {
        int lineNumber = 1;
        StringBuilder printed = new StringBuilder();

        for (int c = 0; c < output.Length; )
        {
            if (c % lineSize == 0)
            {
                printed.Append(Convert.ToString(lineNumber).PadLeft(lineNumberChars));
                lineNumber++;
            }

            for (int i = 0; i < lineSize && c < output.Length; i++)
            {
                if (i % groupSize == 0) printed.Append(" ");

                printed.Append(output[c++]);
            }
            printed.AppendLine();
        }

        Console.Write(printed);
    }

    static void ParseInput()
    {
        string[] dimensions = Console.ReadLine().Split();
        lineSize = int.Parse(dimensions[0]);
        groupSize = int.Parse(dimensions[1]);
        string genome = Console.ReadLine();

        if(Regex.Match(genome, @"\d").Success)
        {
        foreach (Match gen in Regex.Matches(genome, @"(\d*)(\D)"))
        {
            int times = gen.Groups[1].Value == String.Empty ? 1 : int.Parse(gen.Groups[1].Value);
            output.Append(new String(gen.Groups[2].Value[0], times));
        }
        }
        else output.Append(genome);

        int numberOfLines = (int)Math.Ceiling((double)output.Length / lineSize);
        lineNumberChars = (int)Math.Log10(numberOfLines) + 1;

        // Console.WriteLine(output);
    }

    static void Main()
    {
#if DEBUG
        //Console.SetIn(new StreamReader("../../input.txt"));
        //Console.SetIn(new StreamReader("../../test.009.in.txt"));
#endif

        ParseInput();

        CoolPrint();
    }
}
