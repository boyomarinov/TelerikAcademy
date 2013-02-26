//From original .ppt before lection

////7. Write extension method to the String class that 
////capitalizes the first letter of each word. Use the
////method TextInfo.ToTitleCase().


using System;
using System.Globalization;

public static class StringExtension
{
    //Extension method of String class to capitalize all first letters
    public static string CapitalizeFirstLetter(this string str)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
    }
}

class TestOurStringExtension
{
    static void Main()
    {
        //Testing our extension method
        string test = "bla and bla";
        Console.WriteLine(test.CapitalizeFirstLetter());
    }
}

