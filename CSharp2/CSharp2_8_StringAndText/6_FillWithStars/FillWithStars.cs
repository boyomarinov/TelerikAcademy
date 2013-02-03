using System;

class FillWithStars
{
    //make it reusable
    static string Fill(string str, char fillWith, int estimatedLength)
    {
        string fill = new string(fillWith, estimatedLength - str.Length);
        return str + fill;
    }
    static void Main()
    {
        string original = "12345";
        char c = '*';
        int length = 20;
        Console.WriteLine(Fill(original, c, length));
    }
}
