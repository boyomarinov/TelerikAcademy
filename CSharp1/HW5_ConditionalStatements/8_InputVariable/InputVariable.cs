using System;

class InputVariable
{
    static void Main()
    {
        string choice;
        int typeInt;
        double typeDouble;
        string typeString;
        Console.Write("Specify type of variable: ");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "int":
                Console.Write("Input an integer: ");
                typeInt = int.Parse(Console.ReadLine());
                typeInt = typeInt + 1;
                Console.WriteLine("Result: {0}", typeInt);
                break;
            case "double":
                Console.Write("Input a double: ");
                typeDouble = double.Parse(Console.ReadLine());
                typeDouble = typeDouble + 1;
                Console.WriteLine("Result: {0}", typeDouble);
                break;
            case "string":
                Console.Write("Input a string: ");
                typeString = Console.ReadLine();
                typeString = typeString + "*";
                Console.WriteLine("Result: {0}", typeString);
                break;
            default:
                Console.WriteLine("Your input doesn't meet the specified criteria!");
                break;
        }
    }
}

