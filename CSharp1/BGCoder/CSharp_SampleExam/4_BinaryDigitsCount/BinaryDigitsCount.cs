using System;

class BinaryDigitsCount
{
    static int countDigits(uint num, byte digit)
    {
        string str = Convert.ToString(num, 2);
        int countOnes = 0;
        int countZeros = 0;
        foreach (var item in str)
        {
            if (item == '1')
            {
                countOnes++;
            }
            if(item == '0')
            {
                countZeros++;
            }
        }
        if (digit == 1)
        {
            return countOnes;
        }
        else
        {
            return countZeros;
        }
    }

    static void Main()
    {
        byte digit;
        uint n;
        digit = byte.Parse(Console.ReadLine());
        n = uint.Parse(Console.ReadLine());
        //List<int> list = new List<int>();
        uint tempResult = 0;
        int countedTempResult = 0;
        while (n > 0)
        {
            tempResult = uint.Parse(Console.ReadLine());
            countedTempResult = countDigits(tempResult, digit);
            Console.WriteLine(countedTempResult);
            n--;
        }
    }
}

