using System;

class GCD
{
    static int GCDMod(int a, int b)
    {
        int temp = 0;
        if (b == 0)
        {
            return a;
        }
        while (b != 0)
        {
            temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    static int GCDSubstraction(int a, int b)
    {
        if (a == 0)
        {
            return b;
        }
        while (b != 0)
        {
            if (a > b)
            {
                a = a - b;
            }
            else
            {
                b = b - a;
            }
        }
        return a;
    }
    static void Main()
    {
        Console.WriteLine("Input two numbers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("GCD Mod: {0}", GCDMod(a, b));
        Console.WriteLine("GCD Substraction: {0}", GCDSubstraction(a, b));
    }
}
