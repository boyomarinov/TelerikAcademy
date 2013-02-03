using System;

class ReverseString
{
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    static void Main()
    {
        string test = "abcdefg";
        Console.WriteLine(Reverse(test));
    }
}
