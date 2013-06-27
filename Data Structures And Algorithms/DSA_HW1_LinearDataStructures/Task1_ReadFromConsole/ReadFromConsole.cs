using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1_ReadFromConsole
{
    public static class ReadFromConsole
    {
        public static void Main(string[] args)
        {
            List<int> input = new List<int>();
            string line = Console.ReadLine();
            while(line != string.Empty)
            {
                int parsed = int.Parse(line);
                input.Add(parsed);

                line = Console.ReadLine();
            }

            int inputSum = input.Sum();
            Console.WriteLine("Sum: {0}", inputSum);

            double inputAverage = (double)inputSum / input.Count;
            Console.WriteLine("Average: {0}", inputAverage);
        }
    }
}
