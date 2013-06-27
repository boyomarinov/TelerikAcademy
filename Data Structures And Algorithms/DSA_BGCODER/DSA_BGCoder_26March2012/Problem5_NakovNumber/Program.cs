using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_NakovNumber
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input2.txt"));
#endif

            var authorsCollection = Console.ReadLine()
                .Split(',')
                .Select(entry => new HashSet<string>(entry.Split(new[] { '"', ' ' }, StringSplitOptions.RemoveEmptyEntries)))
                .ToArray();

            Dictionary<string, int> authorsRang = authorsCollection.SelectMany(x => x).Distinct().ToDictionary(x => x, x => -1);

            Queue<string> authorsQueue = new Queue<string>();
            int level = 0;
            authorsQueue.Enqueue("NAKOV");

            while (authorsQueue.Count > 0)
            {
                level++;
                Queue<string> currentLevel = new Queue<string>();
                while (authorsQueue.Count > 0)
                {
                    string current = authorsQueue.Dequeue();
                    authorsRang[current] = level - 1;

                    foreach (var authors in authorsCollection.Where(x => x.Contains(current)))
                    {
                        foreach (var legitAuthor in authors)
                        {
                            if (authorsRang[legitAuthor] == -1)
                            {
                                currentLevel.Enqueue(legitAuthor);
                            }
                        }
                    }
                }

                authorsQueue = currentLevel;
            }

            var sortedByName = authorsRang.OrderBy(x => x.Key).Select(x => String.Format("{0} {1}", x.Key, x.Value));
            Console.WriteLine(String.Join(Environment.NewLine, sortedByName));

        }
    }
}
