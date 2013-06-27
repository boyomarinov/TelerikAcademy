using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryItem = System.Tuple<string, int, string>;

namespace Task3_BiDictionary
{
    public static class Program
    {
        public static void Main()
        {
            BiDictionary<string, int, string> biDictionary = new BiDictionary<string, int, string>(allowDuplicateValues: true);

            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                biDictionary.Add("Item" + rand.Next(1, 30), rand.Next(10, 1000), "SecondItem" + rand.Next(40, 100));
            }

            Console.WriteLine("Test GET: ");
            Console.WriteLine(string.Join(" ", biDictionary.GetByFirstKey("Item3")));
            Console.WriteLine(string.Join(" ", biDictionary.GetBySecondKey(100)));
            Console.WriteLine(string.Join(" ", biDictionary.GetByFirstAndSecondKey("Item50", 300)));

            Console.Write("Dictionary Count: ");
            Console.WriteLine(biDictionary.Count);

            biDictionary.RemoveByFirstKey("Item10");
            Console.Write("Dictionary Count: ");
            Console.WriteLine(biDictionary.Count);

            biDictionary.RemoveBySecondKey(500);
            Console.Write("Dictionary Count: ");
            Console.WriteLine(biDictionary.Count);

            biDictionary.RemoveByFirstAndSecondKey("Item20", 200);
            Console.Write("Dictionary Count: ");
            Console.WriteLine(biDictionary.Count);
        }
    }
}
