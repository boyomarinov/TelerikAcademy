using System;
using System.Collections.Generic;

class FallDown
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
        for (int j=i; j < 8; j++)
        {
            result[j] = stringByte[count++];
        }
        return result;
    }
    static void PopulateMatrix(char[,] matrix, List<byte> nums)
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
    static char[,] FallDownFunction(char[,] matrix)
    {
        int[] countCol = new int[8];
        for (int cols = 0; cols < 8; cols++)
        {
            int countForRow = 0;
            for (int rows = 0; rows < 8; rows++)
            {
                if (matrix[rows, cols] == '1')
                {
                    countForRow++;
                }
            }
            countCol[cols] = countForRow;
        }

        char[,] result = new char[8, 8];
        //populate matrix with zeros
        for (int cols = 0; cols < 8; cols++)
        {
            for (int rows = 0; rows < 8; rows++)
            {
                result[rows, cols] = '0';
            }
        }
        //put the ones in place
        for (int cols = 0; cols < 8; cols++)
        {
            int count = countCol[cols];
            int index = 7;
            while (count > 0 && index >= 0)
            {
                result[index, cols] = '1';
                count--;
                index--;
            }
        }
        return result;
    }
    static byte ReadMatrixLine(char[] line)
    {
        string matrixLine = line[0].ToString();
        for (int i = 1; i < 8; i++)
        {
            matrixLine = matrixLine + line[i].ToString();
        }
        byte result = byte.Parse(matrixLine);
        return result;
    }
    static byte ConvertStringToByte(string str)
    {
        byte result = 0;
        byte index = 7;
        for (int i = 0; i < 8; i++)
        {
            if (str[i] == '1')
            {
                result += (byte)Math.Pow(2, index);
            }
            index--;
        }
        return result;
    }
    static byte[] ConvertMatrixToArray(char[,] matrix)
    {
        byte[] result = new byte[8];
        for (int rows = 0; rows < 8; rows++)
        {
            string matrixLine = matrix[rows, 0].ToString();
            for (int cols = 1; cols < 8; cols++)
            {
                matrixLine = matrixLine + matrix[rows, cols].ToString();
            }
            result[rows] = ConvertStringToByte(matrixLine);
        }
        return result;
    }
    static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(matrix[i,j].ToString());
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        char[,] binaryMatrix = new char[8, 8];
        List<byte> array = new List<byte>(8);
        byte n0, n1, n2, n3, n4, n5, n6, n7;
        n0 = byte.Parse(Console.ReadLine());
        n1 = byte.Parse(Console.ReadLine());
        n2 = byte.Parse(Console.ReadLine());
        n3 = byte.Parse(Console.ReadLine());
        n4 = byte.Parse(Console.ReadLine());
        n5 = byte.Parse(Console.ReadLine());
        n6 = byte.Parse(Console.ReadLine());
        n7 = byte.Parse(Console.ReadLine());

        array.Add(n0);
        array.Add(n1);
        array.Add(n2);
        array.Add(n3);
        array.Add(n4);
        array.Add(n5);
        array.Add(n6);
        array.Add(n7);
        PopulateMatrix(binaryMatrix, array);
        //PrintMatrix(binaryMatrix);
        //Console.WriteLine();
        char[,] newmatrix = FallDownFunction(binaryMatrix);
        //PrintMatrix(newmatrix);
        //Console.WriteLine();
        byte[] final = ConvertMatrixToArray(newmatrix);
        foreach (byte item in final)
        {
            Console.WriteLine(item);
        }
    }
}

