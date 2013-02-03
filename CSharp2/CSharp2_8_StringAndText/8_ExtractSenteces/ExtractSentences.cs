using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentences
{

    static void Extract(string test, string target)
    {
        //Split input to sentences
        string[] sentences = test.Split('.');
        //correct for beginning whitespaces
        //loop up to [length-1] because splitting with dot
        //creates additional last item which is useless for us
        for (int i = 0; i < sentences.Length - 1; i++)
        {
            if (sentences[i][0] == ' ')
            {
                sentences[i] = sentences[i].Substring(1);
            }
        }
        //check every sentence with regex for given target
        Regex regexIn = new Regex("\\b(" + target + ")\\b");
        for (int i = 0; i < sentences.Length; i++)
        {
            Match containsIn = regexIn.Match(sentences[i]);
            if (containsIn.Success)
            {
                Console.WriteLine(sentences[i] + ".");
            }
        }
    }
    static void Main()
    {
        string sample = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight."
                                + "So we are drinking all the day. We will move out of it in 5 days.";
        string target = "in";
        //Console.WriteLine(Extract(sample, target));
        Extract(sample, target);
    }
}

