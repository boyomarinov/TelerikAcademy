using System;

class BinaryRappresentation
{
    static string ShortToBinary(short num)
    {
        string result = "";
        int mask = 0;
        for (int i = 0; i < 16; i++)
        {
            mask = (num >> i) & 1;
            result = mask.ToString() + result;
        }
        return result;
    }
    static void Main(string[] args)
    {
        short num = 21;
        Console.WriteLine(ShortToBinary(num));
    }
}
