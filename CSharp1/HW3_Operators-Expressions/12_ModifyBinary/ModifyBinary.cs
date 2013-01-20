using System;

class ModifyBinary
{
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Value (0 or 1): ");
        int value = int.Parse(Console.ReadLine());
        Console.Write("Position: ");
        int p = int.Parse(Console.ReadLine());

        int newNumber = 0;
        if (value > 0)
        {
            int mask = 1;
            mask = mask << p;
            newNumber = number | mask;
        }
        else
        {
            int mask = 1;
            mask = ~(mask << p);
            newNumber = number & mask;
        }
        Console.WriteLine(newNumber);
    }
}

