using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_MostCommon
{
    class Program
    {
        private static Dictionary<string, int>[] dictionaries = new Dictionary<string, int>[6];

        private static string GetBiggestElem(int index)
        {
            //return dictionaries[index].OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key;
            //return dictionaries[index].Max(kvp => kvp.Value)
            int max = int.MinValue;
            string result = null;
            foreach (var kvp in dictionaries[index])
            {
                if (kvp.Value > max)
                {
                    max = kvp.Value;
                    result = kvp.Key;
                }
                else if (kvp.Value == max)
                {
                    result = (result.CompareTo(kvp.Key) > 0) ? kvp.Key : result;
                }
            }

            return result;
        }

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif


            for (int i = 0; i < 6; i++)
            {
                dictionaries[i] = new Dictionary<string, int>();
            }

            foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 6; j++)
                {
                    if (!dictionaries[j].ContainsKey(splitted[j]))
                    {
                        dictionaries[j][splitted[j]] = 0;
                    }

                    dictionaries[j][splitted[j]]++;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(GetBiggestElem(i));
            }
        }
    }
}
