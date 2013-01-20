using System;

class StringConcatenation
{
    static void Main()
    {
        string one = "Hello";
        string second = "World";

        object concatenated = one + " " + second;
        string concatenadetString = concatenated.ToString();

        //Console.WriteLine(concatenated);
        Console.WriteLine(concatenadetString);
    }
}

