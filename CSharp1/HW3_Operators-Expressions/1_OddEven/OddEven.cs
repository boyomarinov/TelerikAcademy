using System;

class OddEven
{
    static bool checkEven(int num)
    {
        return num % 2 == 0;
    }
    static void Main()
    {
        int number;
        bool parsed = int.TryParse(Console.ReadLine(), out number);
        if (parsed)
        {
            if (checkEven(number))
            {
                Console.WriteLine("{0} is even.", number);
            }
            else
            {
                Console.WriteLine("{0} is odd.", number);
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
        
    }
}

