using System;

class Lines
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
    static void PopulateMatrix(char[][] matrix, byte[] nums)
    {
        for (int rows = 0; rows < 8; rows++)
        {
            matrix[rows] = ConvertByteToArray(nums[rows]);
        }
    }
    //rows
    static int MaxLineInArray(char[] arr)
    {
        int max = 0;
        char previous = '2';
        int currentSequence = 0;
        for (int i = 0; i < 8; i++)
        {
            if (arr[i] == previous && previous == '1')
            {
                currentSequence++;
            }
            else
            {
                if (currentSequence > max)
                {
                    max = currentSequence;
                }
                currentSequence = 1;
            }
            previous = arr[i];
        }
        if (currentSequence == 8)
        {
            max = currentSequence;
        }
        return max;
    }
    static int[] MaxLinesInRows(char[][] matrix)
    {
        int rowLength = 0, rowCount = 0;
        for (int rows = 0; rows < 8; rows++)
        {
            int curr = MaxLineInArray(matrix[rows]);
            if (curr == rowLength && curr != 1)
            {
                rowCount++;
            }
            else if (curr > rowLength)
            {
                rowLength = curr;
                rowCount = 1;
            }
        }
        int[] result = { rowLength, rowCount };
        return result;
    }
    //cols
    static int[] MaxLinesInCols(char[][] matrix)
    {
        int colLength = 0, colCount = 0;
        for (int cols = 0; cols < 8; cols++)
        {
            int maxFromCurrentCol = 0;
            char previous = '2';
            int currentSequence = 0;
            for (int rows = 0; rows < 8; rows++)
            {
                if (matrix[rows][cols] == previous && previous == '1')
                {
                    currentSequence++;
                }
                else
                {
                    if (currentSequence >= maxFromCurrentCol)
                    {
                        maxFromCurrentCol = currentSequence;
                    }
                    currentSequence = 1;
                }
                previous = matrix[rows][cols];
            }
            if (currentSequence == 8 || currentSequence == 7)
            {
                maxFromCurrentCol = currentSequence;
            }
            if (maxFromCurrentCol == colLength && maxFromCurrentCol != 1)
            {
                colCount++;
            }
            else if (maxFromCurrentCol > colLength)
            {
                colLength = maxFromCurrentCol;
                colCount = 1;
            }
        }
        int[] result = { colLength, colCount };
        return result;
    }
    static void LongestLines(char[][] matrix)
    {
        int[] rows = MaxLinesInRows(matrix);
        int[] cols = MaxLinesInCols(matrix);
        if (rows[0] == cols[0])
        {
            Console.WriteLine(rows[0]);
            if (rows[0] == 1)
            {
                Console.WriteLine(rows[1]);
            }
            else
            {
                Console.WriteLine(rows[1] + cols[1]);
            }

        }
        else
        {
            if (rows[0] > cols[0])
            {
                Console.WriteLine(rows[0]);
                Console.WriteLine(rows[1]);
            }
            else
            {
                Console.WriteLine(cols[0]);
                Console.WriteLine(cols[1]);
            }
        }
    }
    static void PrintMatrix(char[][] matrix)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(matrix[i][j].ToString());
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        byte[] byteArr = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            byteArr[i] = byte.Parse(Console.ReadLine());
        }
        char[][] matrix = new char[8][];
        PopulateMatrix(matrix, byteArr);
        //PrintMatrix(matrix);
        LongestLines(matrix);
    }
}

