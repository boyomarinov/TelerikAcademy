using System;
using System.IO;

class Program
{
    static int[,] ReadMatrixFromFile(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        int size = 0;
        using (reader)
        {
            size = int.Parse(reader.ReadLine());
            int[,] matrix = new int[size, size];
            for (int rows = 0; rows < size; rows++)
            {
                string[] numbers = reader.ReadLine().Split();
                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = int.Parse(numbers[cols]);
                }
            }
            return matrix;
        }
    }
    static int GetMaxSubmatrix(int[,] matrix)
    {
        int currentSum = 0;
        int maxSum = 0;
        for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(0) - 1; cols++)
            {
                currentSum = matrix[rows, cols] + matrix[rows + 1, cols] +
                             matrix[rows, cols + 1] + matrix[rows + 1, cols + 1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        return maxSum;
    }
    static void OutputMaxSum(string filePath, string output)
    {
        int[,] matrix = ReadMatrixFromFile(filePath);
        int res = GetMaxSubmatrix(matrix);
        StreamWriter writer = new StreamWriter(output);
        using (writer)
        {
            writer.WriteLine(res);
        }
    }
    static void Main()
    {
        OutputMaxSum("../../input.txt", "../../output.txt");
    }
}
