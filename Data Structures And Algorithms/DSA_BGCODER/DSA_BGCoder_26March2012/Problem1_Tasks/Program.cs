using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using Task = System.Tuple<int, string>;

namespace Problem1_Tasks
{
    public static class Program
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input2.txt"));
#endif

            OrderedBag<Task> tasks = new OrderedBag<Task>((a, b) => {
                int compared = a.Item1.CompareTo(b.Item1);
                if (compared != 0)
                {
                    return compared;
                }

                return a.Item2.CompareTo(b.Item2);
            });

            StringBuilder result = new StringBuilder();
            int commandsList = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsList; i++)
            {
                string line = Console.ReadLine();
                string[] commandParts = line.Split(new char[]{' '}, 3);
                if (commandParts[0] == "New")
                {
                    int priority = int.Parse(commandParts[1]);
                    string taskName = commandParts[2];
                    tasks.Add(new Task(priority, taskName));
                }
                else if (commandParts[0] == "Solve")
                {
                    if (tasks.Count == 0)
                    {
                        result.AppendLine("Rest");
                        continue;
                    }
                    Task min = tasks.RemoveFirst();
                    result.AppendLine(min.Item2);
                }
            }

            Console.Write(result.ToString());
        }
    }
}