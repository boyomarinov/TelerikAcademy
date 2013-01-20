using System;

class ExchangeBitsStar
{

    static void Main()
    {
        Console.Write("Number: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("Starting bit: ");
        byte pos1 = byte.Parse(Console.ReadLine());
        Console.Write("Finish bit: ");
        byte pos2 = byte.Parse(Console.ReadLine());
        Console.Write("Define swapping length: ");
        byte len = byte.Parse(Console.ReadLine());

        uint temp = ((number >> pos1) ^ (number >> pos2)) & ((1U << len) - 1);
        uint result = number ^ ((temp << pos1) | (temp << pos2));
        Console.WriteLine(result);

        Console.WriteLine("Original number: {0}", Convert.ToString(number,2));
        Console.WriteLine("Modified number: {0}", Convert.ToString(result,2));
    }
}
