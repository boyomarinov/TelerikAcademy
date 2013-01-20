using System;

class Trapezoid
{
    static void PopulateMatrixCanvas(char[,] matrix, int len)
    {
        for (int rows = 0; rows < len + 1; rows++)
        {
            for (int cols = 0; cols < 2*len; cols++)
            {
                matrix[rows, cols] = '.';
            }
        }
    }
    static void MakeTrapezoid(char[,] matrix, int len)
    {
        //first line
        for (int cols = len; cols < 2*len; cols++)
        {
            matrix[0, cols] = '*';
        }
        //last column
        for (int rows = 0; rows < len; rows++)
        {
            matrix[rows, 2*len-1] = '*';
        }
        //bottom line
        for (int cols = 0; cols < 2 * len; cols++)
        {
            matrix[len, cols] = '*';
        }
        //left side (west side)
        int countRows = 1;
        for (int rows = len-1; rows > 0; rows--)
        {
            matrix[rows, countRows++] = '*';
        }
    }
    static void PrintMatrix(char[,] matrix, int len)
    {
        for (int rows = 0; rows < len + 1; rows++)
        {
            for (int cols = 0; cols < 2*len; cols++)
            {
                Console.Write(matrix[rows, cols]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());

        char[,] Matrix = new char[n + 1, 2 * n];

        PopulateMatrixCanvas(Matrix, n);
        MakeTrapezoid(Matrix, n);
        PrintMatrix(Matrix, n);
    }
}

