using System;
using System.IO;

class CountWords
{
    static int CountWord(string filePath, string word)
    {
        StreamReader reader = new StreamReader(filePath);
        string text = string.Empty;
        using (reader)
        {
            text = reader.ReadToEnd();
        }

        int count = 0;
        int index = text.IndexOf(word, 0);
        while (index != -1)
        {
            count++;
            index = text.IndexOf(word, index + 1);
        }
        return count;
    }
    static void CountWordsInText(string textFilePath, string wordFilePath)
    {
        //StreamReader textfile = new StreamReader(textFilePath);
        StreamReader wordfile = new StreamReader(wordFilePath);
        string[] words;
        using (wordfile)
        {
            words = wordfile.ReadToEnd().Split();
        }

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine("Word: {0}\tCount: {1}", words[i], CountWord(textFilePath, words[i]));
        }
    }
    static void Main()
    {
        CountWordsInText("../../text.txt", "../../words.txt");
    }
}
