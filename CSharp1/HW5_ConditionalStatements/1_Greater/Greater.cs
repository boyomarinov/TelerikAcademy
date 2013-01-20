using System;

class Greater
{
    static void Main()
    {
        int first, second;
        Console.WriteLine("Compare integers: ");
        first = int.Parse(Console.ReadLine());
        second = int.Parse(Console.ReadLine());
        int temp;
        if (first > second)
        {
            temp = first;
            first = second;
            second = temp;
        }
        Console.WriteLine("First: {0}", first);
        Console.WriteLine("Second: {0}", second);
    }
}

