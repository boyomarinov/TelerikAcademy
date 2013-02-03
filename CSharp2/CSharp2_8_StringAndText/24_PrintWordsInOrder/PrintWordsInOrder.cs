using System;
using System.Collections.Generic;

class PrintWordsInOrder
{
    static string[] ReadInput()
    {
        string[] input = Console.ReadLine().Split();
        return input;
    }
    static void PrintInputInAlphabetOrder()
    {
        string[] words = ReadInput();
        List<string> ordered = new List<string>(words);
        ordered.Sort();
        foreach (var item in ordered)
        {
            Console.WriteLine(item);
        }
    }
    static void Main()
    {
        PrintInputInAlphabetOrder();
    }
}
