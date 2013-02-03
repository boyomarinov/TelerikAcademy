using System;
using System.Text.RegularExpressions;

class Program
{
    static int Count(int[, ,] matrix, long sum)
    {
        int count = 0;
        long currentSum = 0;

        for (int i = 0; i < matrix.GetLength(0)-1; i++)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int k = 0; k < matrix.GetLength(2); k++)
                {
                    currentSum += matrix[i, j, k];
                }
            }
            if (currentSum == sum / 2)
            {
                count++;
            }
        }

        currentSum = 0;
        for (int i = 0; i < matrix.GetLength(1)-1; i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(2); k++)
                {
                    currentSum += matrix[j, i, k];
                }
            }
            if (currentSum == sum / 2)
            {
                count++;
            }
        }

        currentSum = 0;
        for (int i = 0; i < matrix.GetLength(2)-1; i++)
        {
           
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    currentSum += matrix[j, k, i];
                }
            }
            if (currentSum == sum / 2)
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        //#if DEBUG
        //        Console.SetIn(new System.IO.StreamReader("../../test.txt"));
        //#endif
        int w, h, d;
        string[] dimension = Console.ReadLine().Split();
        w = int.Parse(dimension[0]);
        h = int.Parse(dimension[1]);
        d = int.Parse(dimension[2]);
        int[, ,] matrix = new int[w, h, d];

        long sum = 0;
        for (int height = 0; height < h; height++)
        {
            string[] row = Regex.Split(Console.ReadLine(), @" \| ");
            for (int depth = 0; depth < d; depth++)
            {
                string[] toInput = row[depth].Split();
                for (int width = 0; width < w; width++)
                {
                    matrix[width, height, depth] = int.Parse(toInput[width]);
                    sum += matrix[width, height, depth];
                }
            }
        }

        Console.WriteLine(Count(matrix, sum));
    }
}
