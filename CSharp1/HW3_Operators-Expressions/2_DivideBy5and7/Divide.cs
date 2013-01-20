using System;

class Divide
{
    static bool checkDivisionBy5and7(int number)
    {
        return (number % 5 == 0) && (number % 7 == 0);
    }
    static void Main()
    {
        int number;
        bool parsed = int.TryParse(Console.ReadLine(), out number);
        if (parsed)
        {
            if (checkDivisionBy5and7(number))
            {
                Console.WriteLine("The number is divisable by 5 and 7.");
            }
            else
            {
                Console.WriteLine("The number is NOT divisable by 5 and 7.");
            }

        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}

