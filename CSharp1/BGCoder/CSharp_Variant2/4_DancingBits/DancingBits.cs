using System;

class DancingBits
{
    static int CountDancingBits(string number, int k)
    {
        int sumLength = number.Length;
        char previous = '2';
        int result = 0;
        int currentSequence = 0;
        for (int i = 0; i < sumLength; i++)
        {
            if (number[i] == previous)
            {
                currentSequence++;
            }
            else
            {
                if (currentSequence == k)
                {
                    result++;
                }
                currentSequence = 1;
            }
            previous = number[i];
        }
        //get last check
        if (currentSequence == k)
        {
            result++;
        }
        return result;
    }
    static void Main()
    {
        int k, n;
        uint tempNum;
        string binarySum = "";
        k = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());
        string[] input = new string[n];
        for (int i = 0; i < n; i++)
        {
            tempNum = uint.Parse(Console.ReadLine());
            binarySum += Convert.ToString(tempNum, 2);
        }
        
        int result = CountDancingBits(binarySum, k);
        Console.WriteLine(result);
    }
}

