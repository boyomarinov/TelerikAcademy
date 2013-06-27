using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace November_Problem4_DjedaiskaMeditaciq
{
    public static class Program
    {
        public static Dictionary<char, int> rangs = new Dictionary<char, int>(){
               {'m', 1},
               {'k', 2},
               {'p', 3}
            };

        public static int CompareRang(char one, char another)
        {
            return rangs[one].CompareTo(rangs[another]);
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader(@"../../input.txt"));
#endif

            int count = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();

            Queue<string> m = new Queue<string>();
            Queue<string> k = new Queue<string>();
            Queue<string> p = new Queue<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                char current = input[i][0];
                if (current == 'm')
                {
                    m.Enqueue(input[i]);
                }
                else if (current == 'k')
                {
                    k.Enqueue(input[i]);
                }
                else
                {
                    p.Enqueue(input[i]);
                }
            }

            if (m.Count > 0)
            {
                sb.Append(String.Join(" ", m));
            }

            if (k.Count > 0)
            {
                sb.Append(" ");
                sb.Append(String.Join(" ", k));
            }

            if (p.Count > 0)
            {
                sb.Append(" ");
                sb.Append(String.Join(" ", p));
            }

            Console.WriteLine(sb.ToString());

            #region Some timelimits
            //OrderedBag<Tuple<char, string>> bag = new OrderedBag<Tuple<char, string>>(
            //    (tuple1, tuple2) => CompareRang(tuple1.Item1, tuple2.Item1));


            //for (int i = 0; i < count; i++)
            //{
            //    bag.Add(new Tuple<char, string>(input[i][0], input[i]));
            //}

            ////Console.WriteLine(String.Join(' ', bag));
            //Console.WriteLine(String.Join(" ", bag.Select(x => x.Item2)));
            #endregion
        }
    }
}
