using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace _3.TrieWordFinder
{
    public static class Program
    {
        private static char[] separators = { '.', ',', ' ', '!', '?', '\n', '\r', ':', '-', '(', ')', '"', '/', '[', ']',
                                            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Trie testTrie = TrieFactory.GetTrie();
            
            //string[] input = Regex.Split(File.ReadAllText(@"../../input.txt"), @"\W+");
            string[] input = (File.ReadAllText(@"../../input.txt")).Split(separators, StringSplitOptions.RemoveEmptyEntries);
            //string[] input = (File.ReadAllText(@"../../small_input.txt")).Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                testTrie.AddWord(item);
            }

            var words = testTrie.GetWords().Select(word => new KeyValuePair<string, int>(word, testTrie.WordCount(word)));
            Console.WriteLine(String.Join(Environment.NewLine, words));

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
