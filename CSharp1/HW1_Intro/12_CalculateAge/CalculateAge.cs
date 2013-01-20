using System;

class CalculateAge
{
    static void Main()
    {
        Console.Write("Enter your current age: ");
        int age;
        bool parsed = int.TryParse(Console.ReadLine(), out age);
        if (!parsed)
        {
            Console.WriteLine("Conversion failed or input is invalid.");
        }
        else
        {
            Console.WriteLine("Your age after 10 years will be {0}.", age + 10);
        }
    }
}

