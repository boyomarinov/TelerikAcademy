using System;

class CheckPBit
{
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Check bit in position: ");
        int p = int.Parse(Console.ReadLine());

        int mask = 1;
        mask = mask << p;
        int result = mask & number;
        result = result >> p;

        Console.WriteLine("{0}", (result == 1) ? true:false);
    }
}

