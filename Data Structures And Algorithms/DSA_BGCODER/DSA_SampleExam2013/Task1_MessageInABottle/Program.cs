using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_MessageInABottle
{
    public static class Program
    {
        private static Dictionary<string, string> decoder = new Dictionary<string, string>();
        private static List<List<string>> decodedMessages = new List<List<string>>();
        private static List<string> currentMessage = new List<string>();

        public static void GenerateMessages(int start, string message)
        {
            if (start == message.Length)
            {
                decodedMessages.Add(currentMessage.Select(x => x).ToList());
                //currentMessage = new List<string>();
                return;
            }

            for (int i = 1; i < message.Length - start + 1; i++)
            {
                string current = message.Substring(start, i);
                if (decoder.ContainsKey(current))
                {
                    currentMessage.Add(decoder[current]);
                    GenerateMessages(start + current.Length, message);
                    currentMessage.RemoveAt(currentMessage.Count - 1);
                }
            }
        }

        public static void ParseCypher(string cypher)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cypher.Count(); i++)
            {
                if (!IsBigLetter(cypher[i]))
                {
                    continue;
                }

                string letterKey = cypher[i].ToString();
                //get letter value

                while (i < cypher.Count() - 1 && !IsBigLetter(cypher[i + 1]))
                {
                    sb.Append(cypher[++i]);
                }

                decoder.Add(sb.ToString(), letterKey);
                sb.Clear();
            }
        }

        private static void SortAndPrint(List<List<string>> list)
        {
            Console.WriteLine(string.Join(Environment.NewLine, list.Select(x => string.Concat(x)).OrderBy(x => x)));
        }

        public static bool IsBigLetter(char letter)
        {
            return ('A' <= letter && letter <= 'Z');
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif


            string message = Console.ReadLine();
            string cypher = Console.ReadLine();
            ParseCypher(cypher);
            //Console.WriteLine(cypher);
            //Console.WriteLine(string.Join(Environment.NewLine, decoder));
            GenerateMessages(0, message);

            Console.WriteLine(decodedMessages.Count);
            //if(decodedMessages.Count > 0)
            SortAndPrint(decodedMessages);
        }
    }
}
