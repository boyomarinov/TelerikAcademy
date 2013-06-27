using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February_Problem2_PriqteliNaIna
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            string result = string.Empty;
            int mostSocialCount = -1;
            foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
            {
                var line = Console.ReadLine().Split();
                int currentSocial = line[1].Count(c => c == '1');
                if (currentSocial > mostSocialCount || (currentSocial == mostSocialCount && line[0].CompareTo(result) < 0))
                {
                    mostSocialCount = currentSocial;
                    result = line[0];
                }
            }

            Console.WriteLine(result);
        }
    }
}
