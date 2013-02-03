using System;
using System.IO;

class ConcatenateTwoTextFiles
{
    static void Main()
    {
        string line = "";
        StreamReader reader1 = new StreamReader("../../digits.txt");
        using (reader1)
        {
            line = reader1.ReadToEnd();
        }
        StreamReader reader2 = new StreamReader("../../letters.txt");
        using (reader2)
        {
            line = line + reader2.ReadToEnd();
        }
        StreamWriter write = new StreamWriter("../../concat.txt");
        using (write)
        {
            write.WriteLine(line);
        }
    }
}
