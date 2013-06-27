using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Variations
{
    public static class Program
    {
        private static string[] elems;
        private static string[] globalElems;

        

        public static void GenerateVariations(int start)
        {
            if (start == elems.Length)
            {
                Console.WriteLine(string.Join(", ", elems));
                return;
            }

            for (int i = 0; i < globalElems.Length; i++)
            {
                elems[start] = globalElems[i];
                GenerateVariations(start + 1);
            }
        }

        public static void Main()
        {
            int n = 3;
            int k = 3;   
            elems = new string[3];
            globalElems = new string[3] {"hi", "a", "b"};

            GenerateVariations(0);
        }
    }
}
