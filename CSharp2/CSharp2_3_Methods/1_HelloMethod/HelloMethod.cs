using System;

class HelloMethod
{
    static void PrintGreeting(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        PrintGreeting(name);
    }
}

