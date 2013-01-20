using System;

class AstrologicalDigits
{
    static int SumNumberDigits(string num)
    {
        string numToUse = num;
        if (numToUse[0] == '-')
        {
            numToUse = num.Remove(0,1);
        }
        int result = 0;
        int i = 0;
        //before decimal point
        while (i < numToUse.Length)
        {
            if (numToUse[i] == '.')
            {
                i++;
                continue;
            }
            result += (int)(numToUse[i] - '0');
            i++;
        }

        return result;
    }
    static int CheckAstrologicalNumber(string num)
    {
        int result = SumNumberDigits(num);
        while (result > 9)
        {
            result = SumNumberDigits(result.ToString());
        }
        return result;
    }
    static void Main()
    {
        string num = Console.ReadLine();
        int result = CheckAstrologicalNumber(num);
        Console.WriteLine(result);
    }
}