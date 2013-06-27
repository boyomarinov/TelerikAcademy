using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_AplusBNta
{
    public static class Program
    {
        public static long[] GeneratePascalNumbers(int level)
        {
            long[] result = new long[level];

            result[0] = 1;

            for (int i = 1; i < level; i++)
            {
                List<long> temp = new List<long>(result);
                for (int j = 1; j <= i; j++)
                {
                    result[j] = temp[j - 1] + temp[j];
                }
            }

            return result;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            string input = Console.ReadLine();
            Console.ReadLine();
            int level = int.Parse(Console.ReadLine());

            //input = input.Substring(1, input.Length - 2);
            //string[] arguments = input.Split('+');
            string first = input[1].ToString();
            string second = input[3].ToString();

            long[] result = GeneratePascalNumbers(level + 1);
            //Console.WriteLine(string.Join(", ", result));

            StringBuilder sb = new StringBuilder();
            int len = result.Length;

            sb.Append("(" + first + "^" + (len-1) + ")");

            for (int i = 1; i < len - 1; i++)
            {
                sb.Append("+" + result[i]);
                sb.Append("(" + first + "^" + (len - i - 1) + ")");
                sb.Append("(" + second + "^" + (i) + ")");
            }

            sb.Append("+(" + second + "^" + (len-1) + ")");

            Console.WriteLine(sb.ToString());
            //}

        }
    }
}
