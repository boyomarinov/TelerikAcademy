using System;

class DefineSign
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input three integers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        bool positive = true;
        if (a > 0)
        {
            if (b > 0)
            {
                if (c > 0)
                {
                    positive = true;
                }
                else
                {
                    positive = false;
                }
            }
            else
            {
                if (c > 0)
                {
                    positive = false;
                }
                else
                {
                    positive = true;
                }
            }
        }
        else
        {
            if (b > 0)
            {
                if (c > 0)
                {
                    positive = false;
                }
                else
                {
                    positive = true;
                }
            }
            else
            {
                if (c > 0)
                {
                    positive = true;
                }
                else
                {
                    positive = false;
                }
            }
        }
        if (positive == true)
        {
            Console.WriteLine("+");
        }
        else
        {
            Console.WriteLine("-");
        }
        
    }
}

