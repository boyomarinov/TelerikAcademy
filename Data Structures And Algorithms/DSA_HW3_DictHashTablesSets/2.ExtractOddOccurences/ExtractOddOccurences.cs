using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ExtractOddOccurences
{
    class ExtractOddOccurences
    {
        static void Main()
        {
            string[] input = new string[]{"C#", "SQL", "PHP", "PHP", "SQL", "SQL" } ;

            Dictionary<string, int> occurences = new Dictionary<string, int>();
            foreach (var item in input)
            {
                if (occurences.ContainsKey(item))
                {
                    occurences[item]++;
                }
                else
                {
                    occurences[item] = 1;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            bool first = true;
            foreach (var key in occurences.Keys)
            {
                if (occurences[key] % 2 != 0)
                {
                    if (first != true)
                    {
                        sb.Append("," + key);
                    }
                    else
                    {
                        sb.Append(key);
                    }
                }

                first = false;
            }

            sb.Append("}");
            Console.WriteLine(sb.ToString());
        }
    }
}
