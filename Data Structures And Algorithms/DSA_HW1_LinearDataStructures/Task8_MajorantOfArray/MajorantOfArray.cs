using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_MajorantOfArray
{
    public static class MajorantOfArray
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

        public static int FindMajorant(List<int> input)
        {
            int majorantMargin = input.Count / 2 + 1;
            Dictionary<int, int> valueCount = new Dictionary<int, int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!valueCount.ContainsKey(input[i]))
                {
                    valueCount[input[i]] = 1;
                }
                else
                {
                    valueCount[input[i]]++;
                }

                if (valueCount[input[i]] > majorantMargin)
                {
                    return input[i];
                }
            }

            //handle case when there is no clear winner
            int majorant = valueCount.OrderByDescending(x => x.Value).Select(x => x.Key).First();

            return majorant;
        }

        public static void Main()
        {
            //List<int> input = ReadInput();
            List<int> input = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            int majorant = FindMajorant(input);
            Console.WriteLine(majorant);
        }
    }
}
