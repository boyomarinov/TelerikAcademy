using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
using System.Diagnostics;
using Content = System.Tuple<string, string, string, long, string>;

namespace Problem4_FreeContent
{
    public static class Program
    {
        public static OrderedMultiDictionary<string, Content> contentsByName = new OrderedMultiDictionary<string, Content>(true, (a, b) => a.CompareTo(b), (tuple, tuple1) => ToStr(tuple).CompareTo(ToStr(tuple1)));
        public static MultiDictionary<string, Content> contentsByUrl = new MultiDictionary<string, Content>(true);

        public static string ToStr(Content x)
        {
            return String.Format("{0}: {1}", x.Item1, String.Join("; ", x.Item2, x.Item3, x.Item4, x.Item5));
        }

        private static string Find(string title, int count)
        {
            if (!contentsByName.ContainsKey(title))
            {
                return "No items found";
            }

            var matched = contentsByName[title].Select(ToStr);
            var filtered = matched.Take(count);

            return String.Join(Environment.NewLine, filtered);
        }

        private static string Update(string oldUrl, string newUrl)
        {
            if (oldUrl == newUrl)
            {
                return contentsByUrl[oldUrl].Count + " items updated";
            }

            int count = 0;
            if (!contentsByUrl.ContainsKey(oldUrl))
            {
                return "0 items updated";
            }

            var matched = contentsByUrl[oldUrl];
            foreach (var tuple in matched.ToArray())
            {
                Content updatedContentItem = new Content(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, newUrl);
                contentsByName.Remove(tuple.Item2, tuple);
                contentsByName.Add(updatedContentItem.Item2, updatedContentItem);
                contentsByUrl.Add(updatedContentItem.Item5, updatedContentItem);

                count++;
            }

            contentsByUrl.Remove(oldUrl);

            return count + " items updated";
        }

        public static void Main()
        {
            StringBuilder sb = new StringBuilder();

#if DEBUG
            Console.SetIn(new System.IO.StreamReader(@"../../test.007.in.txt"));

            var streamWriter = new StreamWriter("../../out.txt");
           // Console.SetOut(streamWriter);
#endif

            Stopwatch sw = new Stopwatch();
            sw.Start();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] splitted = line.Split(new char[] { ':' }, 2);
                string command = splitted[0];
                string[] commandParams = splitted[1].Split(';').Select(x => x.Trim()).ToArray();

                Content currentContent;
                string result;

                switch (command)
                {
                    case "Add book":
                        currentContent = new Content("Book", commandParams[0], commandParams[1],
                                                        long.Parse(commandParams[2]), commandParams[3]);
                        contentsByName.Add(currentContent.Item2, currentContent);
                        contentsByUrl.Add(currentContent.Item5, currentContent);
                        sb.AppendLine("Book added");
                        break;
                    case "Add movie":
                        currentContent = new Content("Movie", commandParams[0], commandParams[1],
                                                        long.Parse(commandParams[2]), commandParams[3]);
                        contentsByName.Add(currentContent.Item2, currentContent);
                        contentsByUrl.Add(currentContent.Item5, currentContent);
                        sb.AppendLine("Movie added");
                        break;
                    case "Add song":
                        currentContent = new Content("Song", commandParams[0], commandParams[1],
                                                        long.Parse(commandParams[2]), commandParams[3]);
                        contentsByName.Add(currentContent.Item2, currentContent);
                        contentsByUrl.Add(currentContent.Item5, currentContent);
                        sb.AppendLine("Song added");
                        break;
                    case "Add application":
                        currentContent = new Content("Application", commandParams[0], commandParams[1],
                                                        long.Parse(commandParams[2]), commandParams[3]);
                        contentsByName.Add(currentContent.Item2, currentContent);
                        contentsByUrl.Add(currentContent.Item5, currentContent);
                        sb.AppendLine("Application added");
                        break;
                    case "Find":
                        result = Find(commandParams[0], int.Parse(commandParams[1]));
                        sb.AppendLine(result);
                        break;
                    case "Update":
                        result = Update(commandParams[0], commandParams[1]);
                        sb.AppendLine(result);
                        break;
                    default:
                        throw new ArgumentException("Invalid command");
                        break;
                }

                line = Console.ReadLine();
            }
            sw.Stop();

#if DEBUG
            Console.WriteLine(sw.Elapsed);
            streamWriter.Close();
#endif

            //Console.Write(sb.ToString());
        }
    }
}

