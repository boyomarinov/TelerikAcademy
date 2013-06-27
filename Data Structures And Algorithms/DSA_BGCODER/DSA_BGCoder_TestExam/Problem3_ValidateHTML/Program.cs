using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem3_ValidateHTML
{
    public static class Program
    {
        public static bool SpecialComparer(string openTag, string closeTag)
        {
            if (openTag.Length + 1 != closeTag.Length)
            {
                return false;
            }

            for (int i = 1; i < openTag.Length; i++)
            {
                if (openTag[i] != closeTag[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsOpeniningTag(string tag)
        {
            return tag[1] != '/';
        }

        public static bool Validate(string lineOfMarkupLanguage)
        {
            string[] splitted = lineOfMarkupLanguage.Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> mainStack = new Stack<string>();

            foreach (var tag in splitted)
            {
                if (IsOpeniningTag(tag))
                {
                    mainStack.Push(tag);
                }
                else
                {
                    if (mainStack.Count == 0)
                    {
                        return false;
                    }

                    string currentOpeningTag = mainStack.Pop();
                    if (!SpecialComparer(currentOpeningTag, tag))
                    {
                        return false;
                    }
                }
            }

            return (mainStack.Count == 0);
        }

        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader(@"../../test.020.in.txt"));
            Debug.Listeners.Add(new ConsoleTraceListener());
            #endif

            Stopwatch sw = new Stopwatch();
            sw.Start();
            StringBuilder sb = new StringBuilder();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();

                bool isValid = Validate(line);
                if (isValid)
                {
                    sb.AppendLine("VALID");
                }
                else
                {
                    sb.AppendLine("INVALID");
                }
            }
            sw.Stop();
            Console.Write(sb.ToString());
            Debug.WriteLine(sw.Elapsed);
            string bla = "asdlj";
        }
    }
}