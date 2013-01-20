using System;

class FillMatrix
{
    static int[,] fillMatrixA(int n)
    {
        int count = 1;
        int[,] matrix = new int[n, n];
        for (int rows = 0; rows < n; rows++)
        {
            for (int cols = 0; cols < n; cols++)
            {
                matrix[cols, rows] = count++;
            }
        }
        return matrix;
    }
    static int[,] fillMatrixB(int n)
    {
        int[,] matrix = new int[n, n];
        int count = 1;
        for (int rows = 0; rows < n; rows++)
        {
            if (rows % 2 == 0)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[cols, rows] = count++;
                }
            }
            else
            {
                for (int cols = n-1; cols >= 0; cols--)
                {
                    matrix[cols, rows] = count++;
                }
            }
        }
        return matrix;
    }
    //TODO: edit
    static int[,] FillMatrixC(int n)
    {
        int[,] matrix = new int[n, n];
        int k = 0;
        int m = 0;
        int value = 1;

        //this loop fills under the main diagonal including
        for (int i = n - 1; i >= 0; i--)
        {
            k = i;
            m = 0;
            while (k < n && m < n)
            {
                matrix[k++, m++] = value++;
            }
        }

        //this loop fills over the main diagonal
        for (int j = 1; j < n; j++)
        {
            k = j;
            m = 0;
            while (k < n && m < n)
            {
                matrix[m++, k++] = value++;
            }
        }
        return matrix;
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, -4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        int n = 4;
        int[,] a = FillMatrixC(n);
        PrintMatrix(a);
    }
}
