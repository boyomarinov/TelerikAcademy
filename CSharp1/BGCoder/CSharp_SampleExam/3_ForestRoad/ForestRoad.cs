using System;

class ForestRoad
{
    static char[,] PopulateMatrix(int n)
    {
        char[,] result = new char[2 * n - 1, n];
        for (int rows = 0; rows < 2 * n - 1; rows++)
        {
            for (int cols = 0; cols < n; cols++)
            {
                result[rows, cols] = '.';
            }
        }
        return result;
    }
    static char[,] CreateRoad(char[,] arr, int n)
    {
        //upper half
        int countRows = 0;
        for (int rows = 0; rows < n; rows++)
        {
            arr[rows, countRows++] = '*';
        }
        //bottom half
        int countRowsFromBottom = 0;

        for (int rows = 2*n - 2; rows >= n; rows--)
        {
            arr[rows, countRowsFromBottom++] = '*';
        }

        return arr;
    }
    static void PrintRoad(char[,] arr, int n)
    {
        for (int rows = 0; rows < 2 * n - 1; rows++)
        {
            for (int cols = 0; cols < n; cols++)
            {
                Console.Write(arr[rows, cols]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());
        char[,] map = PopulateMatrix(n);
        CreateRoad(map, n);
        PrintRoad(map, n);
    }
}
