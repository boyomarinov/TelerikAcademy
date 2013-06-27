using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace _3.CountWordsInFile
{
    public static class CountWordsInFile
    {
        private static char[] separators = { ' ', ',', '.', ':', '!', '?', '-', '–', '\r', '\n' };

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            StreamReader reader = new StreamReader("../../input.txt");
            string input = string.Empty;
            using (reader)
            {
                input = reader.ReadToEnd();
            }

            string[] splittedInput = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordOccurences = new Dictionary<string, int>();
            foreach (var item in splittedInput)
            {
                string currentWord = item.ToLower();
                if (wordOccurences.ContainsKey(currentWord))
                {
                    wordOccurences[currentWord]++;
                }
                else
                {
                    wordOccurences[currentWord] = 1;
                }
            }
            
            var sortedKeys = wordOccurences.OrderBy(x => x.Value).Select(x => x.Key).ToList();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            foreach (var key in sortedKeys)
            {
                Console.WriteLine("{0} -> {1} times", key, wordOccurences[key]);
            }
        }
    }
}
