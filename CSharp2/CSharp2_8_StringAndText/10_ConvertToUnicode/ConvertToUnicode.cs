using System;
using System.Text;

class ConvertToUnicode
{
    static string Convert(string input)
    {
        StringBuilder result = new StringBuilder();
        string unicode = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            string hex = ((int)input[i]).ToString("X");
            unicode = "\\u" + new string('0', 4 - hex.Length) + hex;
            result.Append(unicode);
        }
        return result.ToString();
    }
    static void Main()
    {
        string str = "Hi!";
        Console.WriteLine(Convert(str));
    }
}
