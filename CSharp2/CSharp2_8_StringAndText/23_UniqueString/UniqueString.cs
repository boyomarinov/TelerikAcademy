using System;
using System.Text;

class UniqueString
{
    static string RemoveEqual(string input)
    {
        StringBuilder result = new StringBuilder();
        int index = 0;
        while (index < input.Length)
        {
            //get current unique element
            char current = input[index];

            //write it in our result
            result.Append(current.ToString());

            //skip next element which are equal
            while (current == input[index] && index < input.Length - 1)
            {
                index++;
            }
            if (index == input.Length - 1)
            {
                break;
            }
        }
        return result.ToString();
    }
    static void Main()
    {
        string str = "aaaaabbbbbcdddeeeedssaa";
        Console.WriteLine(RemoveEqual(str));
    }
}
