using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3_ReadAndSort
{
    public static class ReadAndSort
    {
        public static void Main()
        {
            List<int> input = new List<int>();
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                int parsedInteger = int.Parse(line);
                input.Add(parsedInteger);

                line = Console.ReadLine();
            }

            var sorted = input.OrderBy(x => x);

            foreach (int item in sorted)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
