using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AcademyTasks
{
    public static class Program
    {
        private static List<int> tasks;
        //private static bool[] visited;
        private static int minTasks = int.MaxValue;
        private static int variety;
        private static int maxPleasure;
        private static int minPleasure;

        public static int MeasurePleasure(int start)
        {
            Queue<int> mainQueue = new Queue<int>();
            mainQueue.Enqueue(tasks[start]);
            //visited[start] = true;
            int tasksSolved = 1;

            while (mainQueue.Count > 0)
            {
                tasksSolved++;
                Queue<int> next = new Queue<int>();
                
                while (mainQueue.Count > 0)
                {
                    int current = mainQueue.Dequeue();
                    //adjust max/min pleasure
                    //if (current < minPleasure)
                    //{
                    //    minPleasure = current;
                    //}

                    //if (current > maxPleasure)
                    //{
                    //    maxPleasure = current;
                    //}

                    //Console.WriteLine("Current elem: " + current);
                    //Console.WriteLine("Max pleasure: {0}   Min pleasure: {1}", maxPleasure, minPleasure);
                    //check if minPleasure is assigned
                    //int difference = maxPleasure - (minPleasure > 0 ? minPleasure : current);

                    List<int> nextElems = getNextElems(start);


                    foreach (var nextElem in nextElems)
                    {
                        if (nextElem < minPleasure)
                        {
                            minPleasure = current;
                        }

                        if (nextElem >= maxPleasure)
                        {
                            maxPleasure = current;
                        }

                        int difference = maxPleasure - minPleasure;

                        if (difference >= variety)// && !visited[i])
                        {
                            return tasksSolved;
                        }
                        else
                        {
                            next.Enqueue(nextElem);
                            //visited[i] = true;
                        }
                    }
                }

                mainQueue = next;
                start++;
            }

            return tasks.Count;
        }

        private static List<int> getNextElems(int index)
        {
            List<int> result = new List<int>();
            if (index < tasks.Count - 2)
            {
                result.Add(tasks[index + 1]);
                result.Add(tasks[index + 2]);

            }
            else if (index == tasks.Count - 2)
            {
                result.Add(tasks[index + 1]);
            }

            return result;
        } 

        public static int CountTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                int currentDifference = 0;
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    currentDifference = Math.Abs(tasks[j] - tasks[i]);

                    if (currentDifference < variety)
                    {
                        continue;
                    }

                    int firstPartTasks = (i + 3)/2; //including tasks[j]
                    int secondPartTasks = (j - i + 1)/2;

                    minTasks = Math.Min(firstPartTasks + secondPartTasks, minTasks);
                }
            }

            if (minTasks == int.MaxValue)
            {
                return tasks.Count;
            }

            return minTasks;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../test.008.in.txt"));
#endif
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            tasks = Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToList();
            variety = int.Parse(Console.ReadLine());

            ////visited = new bool[tasks.Count + 1];
            //minPleasure = tasks[0];
            //maxPleasure = tasks[1];

            //Console.WriteLine(string.Join(" ", tasks));
            //Console.WriteLine(MeasurePleasure(0));
            Console.WriteLine(CountTasks());
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);
            
        }
    }
}
