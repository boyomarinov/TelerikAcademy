using System;
using System.IO;
using System.Linq;

namespace February2013_Problem1_Nosene
{
    public static class Program
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
#endif

            int bag = int.Parse(Console.ReadLine());
            Console.ReadLine();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];

                if (sum > bag)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}