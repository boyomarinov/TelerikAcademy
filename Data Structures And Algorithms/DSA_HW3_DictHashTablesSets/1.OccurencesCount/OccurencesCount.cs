using System;
using System.Collections.Generic;
using System.Linq;

namespace OccurencesCount
{
    public static class OccurencesCount
    {
        public static void Main()
        {
            double[] input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Dictionary<double, int> occurences = new Dictionary<double, int>();
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

            //optional key sorting
            List<double> sortedKeys = occurences.Keys.ToList();
            sortedKeys.Sort();

            foreach (var key in sortedKeys)
            {
                Console.WriteLine("{0} -> {1} times", key, occurences[key]);
            }
        }
    }
}
