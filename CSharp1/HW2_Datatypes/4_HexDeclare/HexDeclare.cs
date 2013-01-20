using System;

class HexDeclare
{
    static void Main()
    {
        string value = "0xFE";
        int decValue = Convert.ToInt32(value, 16);
        Console.WriteLine("{0} -> {1}", value, decValue);
    }
}

