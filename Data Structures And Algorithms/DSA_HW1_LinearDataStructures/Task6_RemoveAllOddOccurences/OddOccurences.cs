using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_RemoveAllOddOccurences
{
    public static class OddOccurences
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

        public static List<int> RemoveOddOccurences(List<int> input)
        {
            List<int> result = input;

            Dictionary<int, int> valueCount = new Dictionary<int,int>();
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

            foreach (var item in valueCount)
            {
                if (item.Value % 2 != 0)
                {
                    result.RemoveAll(x => x == item.Key);
                }
            }

            return result;
        }

        public static void Main()
        {
            //List<int> input = ReadInput();
            List<int> input = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Console.WriteLine("Original input:");
            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List<int> removed = RemoveOddOccurences(input);

            Console.WriteLine("With odd occurences' count removed: ");
            foreach (var item in removed)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
