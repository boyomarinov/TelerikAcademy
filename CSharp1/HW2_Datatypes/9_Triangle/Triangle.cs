using System;
using System.Linq;

class Triangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        char copyrightSymbol = (char)169;
        //Console.WriteLine(copyRightSymbol);

        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3 - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= i; j++)
            {
                Console.Write(copyrightSymbol);
            }
            for (int j = i-1; j > 0; j--)
            {
                Console.Write(copyrightSymbol);
            }
            Console.WriteLine();
        }
    }        
}

