using System;
using System.IO;

class ReadOddLines
{
    static void Main()
    {
        int n = 1;
        string line = "";
        StreamReader reader = new StreamReader("../../lorem.txt");
        using (reader)
        {
            line = reader.ReadLine();
            if (n % 2 == 1)
            {
                Console.WriteLine(line);
            }
            n++;
        }
    }
}
