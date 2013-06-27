using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task7_OccurencesInArray
{
    public static class OccurencesInArray
    {
        public static List<int> ReadInput()
        {
            List<int> userInput = new List<int>();
            Console.Write("Numbers count: ");
            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersCount; i++)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                userInput.Add(parsedNumber);
            }

            return userInput;
        }

        public static string CountOccurences(List<int> input)
        {
            Dictionary<int, int> valueCount = new Dictionary<int, int>();
            for (int i = 0; i < input.Count; i++)
            {
                if (valueCount.ContainsKey(input[i]))
                {
                    valueCount[input[i]]++;
                }
                else
                {
                    valueCount[input[i]] = 1;
                }
            }

            List<int> sortedKeys = valueCount.OrderBy(x => x.Key).Select(x => x.Key).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in sortedKeys)
            {
                sb.AppendLine(String.Format("{0} -> {1} times", item, valueCount[item]));
            }

            return sb.ToString();
        }

        public static void Main()
        {
            //List<int> input = ReadInput();
            List<int> input = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            string occurences = CountOccurences(input);
            Console.WriteLine(occurences);
        }
    }
}
