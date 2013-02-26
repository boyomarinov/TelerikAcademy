////1. Implement an extension method Substring(int index, int length) 
////for the class StringBuilder that returns new StringBuilder and
////has the same functionality as Substring in the class String.


using System;
using System.Text;

public static class StringBuilderExtensions
{
    //Extension Method for implementing Substring functionality
    public static StringBuilder Substring(this StringBuilder builder, int index, int length)
    {
        StringBuilder result = new StringBuilder();
        string str = builder.ToString();
        
        //write all the data we want in the new StringBuilder
        for (int i = index; i < index + length; i++)
        {
            if (i >= str.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            result.Append(str[i]);
        }

        return result;
    }
}

class TestOurStringBuilder
{
    static void Main()
    {
        StringBuilder test = new StringBuilder();
        test.Append("123456789");

        StringBuilder res = test.Substring(3, 4);
        Console.WriteLine(res.ToString());
    }
}

