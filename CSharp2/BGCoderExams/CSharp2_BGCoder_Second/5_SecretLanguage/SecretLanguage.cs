using System;
using System.Text.RegularExpressions;

class SecretLanguage
{
    static string SortString(string input)
    {
        char[] arr = input.ToCharArray();
        Array.Sort(arr);
        return new String(arr);
    }
    static int CountInversions(string input, string[] words)
    {
        int minCount = 100000;
        int result = 0;
        bool flag = false;
        int[] min = new int[input.Length+1];
        for (int i = 0; i < input.Length; i++)
        {
            min[i + 1] = 100000;
        }

        string[] sortedWords = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            sortedWords[i] = SortString(words[i]);
        }


        for (int i = 0; i < input.Length; i++)
        {
            minCount = int.MaxValue;
         
            for (int j = 0; j < words.Length; j++)
            {
                if (i+1 >= words[j].Length)
                {
                    int count = 0;
                    string piece = input.Substring(i - words[j].Length + 1, words[j].Length);
                    string sortedPiece = SortString(piece);
                    if (sortedPiece != sortedWords[j])
                    {
                        continue;
                    }
                    else
                    {
                        flag = true;
                        count = CountIversion(words, count, j, piece);
                        min[i + 1] = Math.Min(min[i + 1], min[i + 1 - words[j].Length] + count);
                    }
                    //Console.WriteLine(count + " " + piece);
                    //minCount = Math.Min(minCount, count);
                    //Console.WriteLine(minCount);
                }
                //else
                //{
                //    continue;
                //}
                
            }
            //if (minCount < int.MaxValue)
            //{
            //    result += minCount;
            //}
        }
        //if (flag)
        //{
        //    return result;
        //}
        //return -1;
        return min[input.Length] < 100000 ? min[input.Length] : -1;
    }

    private static int CountIversion(string[] words, int count, int j, string piece)
    {
        for (int k = 0; k < piece.Length; k++)
        {
            if (piece[k] != words[j][k])
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        #if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../test.010.in.txt"));
        #endif
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(Console.ReadLine(), "\"(.*?)\"");
        string[] words = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            words[i] = matches[i].Groups[1].Value;
        }

        
        Console.WriteLine(CountInversions(input, words)); 
    }
}
