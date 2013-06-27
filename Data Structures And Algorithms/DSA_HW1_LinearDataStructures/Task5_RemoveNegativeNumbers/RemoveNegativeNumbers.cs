using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_RemoveNegativeNumbers
{
    public class RemoveNegativeNumbers
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

        public static void Main()
        {
            List<int> input = ReadInput();

            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            input.RemoveAll(x => x < 0);

            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
