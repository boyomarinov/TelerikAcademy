using System;

class Program
{
    static int ConvertCharArrayToInt(char[] arr, int len)
    {
        int result = 0;
        int deg = 0;
        for (int i = len-1; i >= 0; i--)
        {
            if(arr[i] == '1')
            {
                result += (int)Math.Pow(2, deg);
            }
            deg++;
        }
        return result;
    }
    static char[] ReverseCharArray(char[] arr, int len)
    {
        char[] result = new char[len];
        int index = 0;
        for (int i = len - 1; i >= 0; i--)
        {
            result[index] = arr[i];
            index++;
        }
        return result;
    }

    static int ReturnPTilda(int num)
    {
        int result;
        string binary = Convert.ToString(num, 2);
        int i=0;
        char[] reversedBinary = new char[binary.Length];
        for (i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                reversedBinary[i] = '0';
            }
            else
            {
                reversedBinary[i] = '1';
            }
        }
        result = ConvertCharArrayToInt(reversedBinary, binary.Length);
        return result;
    }
    static int ReturnPTwoPoints(int num)
    {
        int result;
        string binary = Convert.ToString(num, 2);
        int size = binary.Length;
        char[] arr = new char[binary.Length];
        for (int i = 0; i < size; i++)
        {
            arr[i] = binary[i];
        }
        char[] reversed = ReverseCharArray(arr, size);
        result = ConvertCharArrayToInt(reversed, size);
        return result;
    }
    static int MitkoAlgorithm(int num)
    {
        int pTilda = ReturnPTilda(num);
        int pTwoPoints = ReturnPTwoPoints(num);
        int result = (num ^ pTilda) & pTwoPoints;
        return result;
    }

    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());
        int temp;
        while (n > 0)
        {
            temp = int.Parse(Console.ReadLine());
            Console.WriteLine(MitkoAlgorithm(temp));
            n--;
        }
    }
}
