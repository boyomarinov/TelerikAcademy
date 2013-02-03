using System;

class AcademyTasks
{
    //false understood task
    //static int CountMinTasks(int[] tasks, int variety)
    //{
    //    int[] min = new int[tasks.Length];

    //    //difference by one element
    //    min[0] = 1;
    //    for (int i = 1; i < tasks.Length; i++)
    //    {
    //        min[i] = Math.Abs(tasks[i] - tasks[i - 1]);
    //    }

    //    //difference by two elements
    //    for (int i = 2; i < tasks.Length; i++)
    //    {
    //        min[i] = Math.Min(min[i - 2] + min[i - 1], Math.Abs(tasks[i] - tasks[i - 2]));
    //    }

    //    int sum = 0;
    //    int j = 0;
    //    while (sum < variety)
    //    {
    //        sum += min[j++];
    //    }
    //    return j;
    //}

    static int Count(int[] tasks, int variety)
    {
        int minCount = tasks.Length;
        for (int i = 0; i < tasks.Length; i++)
        {
            int difference = 0;
            int j = i + 1;
            while(difference < variety && j < tasks.Length)
            {
                difference = Math.Abs(tasks[j] - tasks[i]);
                j++;
            }
            int currentCount = (i + 1) / 2 + 1 + (j - i) / 2;
            if (currentCount < minCount && difference >= variety)
            {
                minCount = currentCount;
            }
        }
        return minCount;
    }

    static void Main()
    {

        string[] str = Console.ReadLine().Split(',');
        int[] tasks = new int[str.Length];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = int.Parse(str[i]);
        }

        int variety = int.Parse(Console.ReadLine());

        Console.WriteLine(Count(tasks, variety));

    }
}
