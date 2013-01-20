using System;

class ExtractBit
{
    static void Main()
    {
        //Analog to 10_CheckPBit
        Console.Write("Number: ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("Value of bit in position: ");
        int b = int.Parse(Console.ReadLine());

        int mask = 1;
        mask = mask << b;
        int value = mask & i;
        value = value >> b;

        Console.WriteLine("Value = {0}", value);
    }
}
