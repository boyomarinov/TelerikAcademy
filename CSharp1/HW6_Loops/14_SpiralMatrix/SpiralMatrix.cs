using System;

class SpiralMatrix
{
    static int[,] CreateSpiralMatrix(int n)
    {
        int[,] result = new int[n, n];
        int numberToAdd = 1;
        int globalCounter = n;
        int tempvalue = -n;
        int sum = -1;

        do
        {
            tempvalue = -1 * tempvalue / n;
            for (int i = 0; i < globalCounter; i++)
            {
                sum += tempvalue;
                result[sum / n, sum % n] = numberToAdd;
                numberToAdd++;
            }
            tempvalue *= n;
            globalCounter--;
            for (int i = 0; i < globalCounter; i++)
            {
                sum += tempvalue;
                result[sum / n, sum % n] = numberToAdd;
                numberToAdd++;
            }
        } while (globalCounter > 0);

        return result;
    }
    static void Print(int[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int n;
        Console.WriteLine("Input number for matrix dimensions: ");
        n = int.Parse(Console.ReadLine());
        int[,] matrix = CreateSpiralMatrix(n);
        Print(matrix, n);
    }
}

