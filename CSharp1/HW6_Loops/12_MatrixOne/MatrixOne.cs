using System;

class MatrixOne
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //int[,] matrix = new int[n, n];
        int row, col;
        for (row = 1; row <= n; row++)
        {
            Console.WriteLine();
            for (col = row; col < row + n; col++)
            {
                Console.Write("{0, 4}", col);
            }
            Console.WriteLine();
        }
    }
}

