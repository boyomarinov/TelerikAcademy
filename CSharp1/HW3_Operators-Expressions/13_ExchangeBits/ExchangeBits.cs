using System;

class ExchangeBits
{
    //static int ExtractBit(uint num, int p)
    //{
    //    int mask = 1;
    //    mask = mask << p;
    //    int result = mask & (int)num;
    //    result = result >> p;

    //    return result;
    //}
    //static uint ModifyBit(uint num, int p, int value)
    //{
    //    uint newNumber = 0;
    //    if (value > 0)
    //    {
    //        uint mask = (uint)value;
    //        mask = mask << p;
    //        newNumber = num | mask;
    //    }
    //    else
    //    {
    //        uint mask = (uint)value;
    //        mask = ~(mask << p);
    //        newNumber = num & mask;
    //    }
    //    return newNumber;
    //}

    static uint SwapBits(uint number, byte pos1, byte pos2)
    {
        uint mask = 1;
        byte value1 = 0;
        byte value2 = 0;
        uint maskPos1 = mask << pos1;
        uint maskPos2 = mask << pos2;
        //Extract value of bits on given positions
        if ((number & maskPos1) >> pos1 == 1)
        {
            value1 = 1;
        }
        else
        {
            value1 = 0;
        }
        if ((number & maskPos2) >> pos2 == 1)
        {
            value2 = 1;
        }
        else
        {
            value2 = 0;
        }

        //modify bits on given positions
        if (value1 > 0)
        {
            number = number | maskPos2;
        }
        else
        {
            number = number & ~maskPos2;
        }
        if (value2 > 0)
        {
            number = number | maskPos1;
        }
        else
        {
            number = number & ~maskPos1;
        }

        return number;
    }

    static void Main()
    {
        Console.Write("Number: ");
        uint number = uint.Parse(Console.ReadLine());

        for (byte i = 3, j = 24; i < 6; i++, j++)
        {
            number = SwapBits(number, i, j);
        }
        Console.WriteLine(number);
    }
}

