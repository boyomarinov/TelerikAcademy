using System;
using System.Collections.Generic;

namespace Task4_RiskWinsRiskLoses
{
    public static class Program
    {
        private static int[] powersOf10 = new int[] {1, 10, 100, 1000, 10000, 100000};

        public static int[] GenerateNext(int num)
        {
            int[] result = new int[10];
            int resultIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                int currentDigit = (num / powersOf10[i]) % 10;
                result[resultIndex++] = num + powersOf10[i] * (NextDigit(currentDigit, true) - currentDigit);
                result[resultIndex++] = num + powersOf10[i] * (NextDigit(currentDigit, false) - currentDigit);
            }

            return result;
        }

        //direction == true -> +1
        private static int NextDigit(int digit, bool direction)
        {
            if (direction)
            {
                if (digit == 9)
                {
                    return 0;
                }
            }
            else
            {
                if (digit == 0)
                {
                    return 9;
                }
            }

            return digit + ((direction) ? +1 : -1);
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader(@"../../input.txt"));
#endif

            Queue<int> mainQueue = new Queue<int>();
            int start = int.Parse(Console.ReadLine());
            int target = int.Parse(Console.ReadLine());
            int forbiddenCount = int.Parse(Console.ReadLine());
            HashSet<int> forbiddenForest = new HashSet<int>();
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < forbiddenCount; i++)
            {
                forbiddenForest.Add(int.Parse(Console.ReadLine()));
            }
            int level = 0;
            mainQueue.Enqueue(start);
            visited.Add(start);

            while (mainQueue.Count > 0)
            {
                Queue<int> currentQueue = new Queue<int>();
                level++;
                while (mainQueue.Count > 0)
                {
                    int current = mainQueue.Dequeue();

                    if (current == target)
                    {
                        Console.WriteLine(level - 1);
                        Environment.Exit(0);
                    }

                    int[] currentChildren = GenerateNext(current);
                    for (int i = 0; i < 10; i++)
                    {
                        if (!forbiddenForest.Contains(currentChildren[i]) && !visited.Contains(currentChildren[i]))
                        {
                            currentQueue.Enqueue(currentChildren[i]);
                            visited.Add(currentChildren[i]);
                        }
                    }
                }
                mainQueue = currentQueue;
            }

            Console.WriteLine("-1");
        }
    }
}
