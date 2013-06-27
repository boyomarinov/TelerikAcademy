using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2_8Feb2012_Crossword
{
    internal class Program
    {
        private static int dimensions;
        private static ICollection<string> words = null;
        private static ICollection<string> sorted = null; 


        private static bool IsValidCrossword(string[] crossword)
        {
            for (int row = 0; row < dimensions; row++)
            {
                StringBuilder sb = new StringBuilder();
                for (int col = 0; col < dimensions; col++)
                {
                    sb.Append(crossword[col][row]);
                }
                if (!words.Contains(sb.ToString()))
                {
                    return false;
                }
            }

            return true;
        }



        public static void FindCrossword(string[] crossword, int start)
        {
            if (start == dimensions)
            {
                if (IsValidCrossword(crossword))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, crossword));
                    Environment.Exit(0);
                }

                return;
            }

            foreach (var word in sorted)
            {
                crossword[start] = word;
                FindCrossword(crossword, start + 1);
            }

        }


        private static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            dimensions = int.Parse(Console.ReadLine());
            words = new HashSet<string>();
            sorted = new SortedSet<string>();
            string currentWord = string.Empty;
            for (int i = 0; i < dimensions*2; i++)
            {
                currentWord = Console.ReadLine();
                words.Add(currentWord);
                sorted.Add(currentWord);
            }

            string[] crossword = new string[dimensions];
            FindCrossword(crossword, 0);

            Console.WriteLine("NO SOLUTION!");
        }
    }
}
