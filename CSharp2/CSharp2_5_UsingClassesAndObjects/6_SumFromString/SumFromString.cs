using System;

class SumFromString
{
    static int CalculateWithSplit(string str)
    {
        int sum = 0;
        int parsed = 0;
        string[] pieces = str.Split();
        for (int i = 0; i < pieces.Length; i++)
        {
            parsed = int.Parse(pieces[i]);
            sum += parsed;
        }
        return sum;
    }

    static int CalculateWithLoop(string str)
    {
        int sum = 0;
        int multiplyBy = 1;
        int digit = 0;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] == ' ')
            {
                multiplyBy = 1;
                continue;
            }
            digit = str[i] - '0';
            sum += multiplyBy * digit;
        }
        return sum;
    }
    static void Main()
    {
        string line = "43 68 9 23 318";
        Console.WriteLine(CalculateWithSplit(line));
        Console.WriteLine(CalculateWithSplit(line));
    }
}

