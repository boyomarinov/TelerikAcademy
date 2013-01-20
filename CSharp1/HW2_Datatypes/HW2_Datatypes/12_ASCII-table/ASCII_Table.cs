using System;

class ASCII_Table
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        for (short i = 0; i < 256; i++)
        {
            Console.Write("{0}   ", (char)i);
            if (i % 10 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}

