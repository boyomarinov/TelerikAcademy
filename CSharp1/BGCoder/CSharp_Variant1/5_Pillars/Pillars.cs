using System;

class Pillars
{
    static char[] ConvertByteToArray(byte b)
    {
        char[] result = new char[8];
        string stringByte = Convert.ToString(b, 2);
        int difference = 8 - stringByte.Length;
        int i;
        for (i = 0; i < difference; i++)
        {
            result[i] = '0';
        }
        int count = 0;
        for (int j = i; j < 8; j++)
        {
            result[j] = stringByte[count++];
        }
        return result;
    }
    static void PopulateMatrix(char[,] matrix, byte[] nums)
    {
        for (int rows = 0; rows < 8; rows++)
        {
            char[] temp = ConvertByteToArray(nums[rows]);
            for (int cols = 0; cols < 8; cols++)
            {
                matrix[rows, cols] = temp[cols];
            }
        }
    }
    static int CountFullCells(char[,] matrix, int startCol, int endCol)
    {
        int count = 0;
        for (int rows = 0; rows < 8; rows++)
        {
            for (int cols = startCol; cols <= endCol; cols++)
            {
                if (matrix[rows, cols] == '1')
                {
                    count++;
                }
            }
        }
        return count;
    }
    static int[] FindVerticalPillar(char[,] matrix)
    {
        //int[0] - correct pillar
        //int[1] - number of full cells
        int[] result = new int[2];
        result[0] = -1;
        result[1] = 0;

        if (CountFullCells(matrix, 1, 7) == 0)
        {
            result[0] = 7;
            result[1] = 0;
        }
        else if (CountFullCells(matrix, 0, 6) == 0)
        {
            result[0] = 0;
            result[1] = 0;
        }
        else
        {
            for (int i = 1; i < 7; i++)
            {
                if (CountFullCells(matrix, 0, i - 1) == CountFullCells(matrix, i + 1, 7))
                {
                    result[0] = 7 - i;
                    result[1] = CountFullCells(matrix, 0, i - 1);
                    break;
                }
            }
        }
        
        return result;
    }

    static void Main()
    {
        char[,] matrix = new char[8, 8];
        byte[] nums = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            nums[i] = byte.Parse(Console.ReadLine());
        }
        PopulateMatrix(matrix, nums);
        int[] res = FindVerticalPillar(matrix);
        if (res[0] == -1)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
        }
    }
}

