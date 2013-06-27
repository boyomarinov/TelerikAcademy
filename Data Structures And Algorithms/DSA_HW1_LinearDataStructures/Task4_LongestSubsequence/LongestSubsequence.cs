using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_LongestSubsequence
{
    public static class LongestSubsequence
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

        public static List<int> LongestEqualElemSubsequence(List<int> list)
        {
            List<int> longestSubsequence = new List<int>();
            int listCount = list.Count;
            longestSubsequence = list
                    .Select((i, index) => new
                    {
                        Item = i,
                        index,
                        PrevEqual = index == 0 || list.ElementAt(index - 1) == i,
                        NextEqual = index == listCount - 1 || list.ElementAt(index + 1) == i,
                    })
                    .Where(x => x.PrevEqual || x.NextEqual)
                    .GroupBy(x => x.Item)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Select(x => x.Item)
                    .ToList();

            return longestSubsequence;
        }

        public static void Main()
        {
            List<int> input = ReadInput();
            List<int> longestSubsequence = LongestEqualElemSubsequence(input);

            foreach (var item in longestSubsequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
