using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class ReverseWords
{
    //parse sentence to words and punctuation marks
    static string[] ParseSentence(string sentence)
    {
        StringBuilder parsed = new StringBuilder();
        int start = 0;
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ',' || sentence[i] == '!' || sentence[i] == '.')
            {
                parsed.Append(sentence.Substring(start, i - start) + " " + sentence[i]);
                start = i + 1;
            }
        }
        string[] words = parsed.ToString().Split();
        return words;
    }
    
    static void ReverseSentenceFromParsed(string[] parsed)
    {
        List<string> words = parsed.ToList();
        //get indexes and values of punctuation marks
        Dictionary<int, string> punctuationMarks = new Dictionary<int, string>();
        for (int i = 0; i < words.Count; i++)
        {
            if (words[i] == "," || words[i] == "." || words[i] == "!")
            {
                punctuationMarks.Add(i, words[i]);
            }
        }
       
        int[] punctIndexes = punctuationMarks.Keys.ToArray();
        string[] punctValues = punctuationMarks.Values.ToArray();
        
        //remove punctuation marks from array
        for (int i = punctIndexes.Length - 1; i >= 0; i--)
        {
            words.RemoveAt(punctIndexes[i]);
        }

        //reverse words in array
        words.Reverse();

        //put punctuation marks back in their original places
        for (int i = 0; i < punctIndexes.Length; i++)
        {
            words.Insert(punctIndexes[i], punctValues[i]);
        }

        //print reversed sentence on the console
        for (int i = 0; i < words.Count; i++)
        {
            if (i+1 < words.Count && (words[i+1] == "," || words[i+1] == "!" || words[i+1] == "."))
            {
                Console.Write(words[i]);
            }
            else
            {
                Console.Write(words[i] + " ");
            }
        }
        Console.WriteLine();
    }

    static void ReverseSentence(string sentence)
    {
        string[] parsed = ParseSentence(sentence);
        ReverseSentenceFromParsed(parsed);
    }
    
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        ReverseSentence(sentence);
    }
}

