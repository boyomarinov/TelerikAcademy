using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordCount
{
    static int countRepeated(string target, List<string> arr)
    {
        int count = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == target)
            {
                count++;
            }
        }
        return count;
    }
    static void RemoveElement(string target, List<string> arr)
    {
        int i = 0;
        //int size = arr.Count;
        while (i < arr.Count)
        {
            
        }
    }
    static bool FindWord(string target, string toMatch)
    {
        return (target == toMatch);
    }
    static void CountWords(string input)
    {
        Dictionary<string, int> words = new Dictionary<string, int>();
        //List<string> words = new List<string>();
        Regex matchAllWords = new Regex(@"\w+", RegexOptions.IgnoreCase);
        MatchCollection matches = matchAllWords.Matches(input);
        for (int i = 0; i < matches.Count; i++)
        {
            if (words.ContainsKey(matches[i].Value))
            {
                words[matches[i].Value] = words[matches[i].Value] + 1;
            }
            else
            {
                words[matches[i].Value] = 1;
            }
        }
        foreach (var item in words)
        {
            Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
        }
    }
    static void Main()
    {
        string sentence = "Write Write a program that reads a string from the console";
        CountWords(sentence);
    }
}
