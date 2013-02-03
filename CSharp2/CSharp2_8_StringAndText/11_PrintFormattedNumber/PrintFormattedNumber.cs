using System;

class PrintFormattedNumber
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string format = string.Empty;
        //write number as decimal
        format = num.ToString("D");
        Console.WriteLine(format);
        //write number as hex
        format = num.ToString("X"); 
        Console.WriteLine(format);
        //write as percentage
        format = (num/100.0).ToString("P");
        Console.WriteLine(format);
        //write in scientific notation
        format = num.ToString("E");
        Console.WriteLine(format);
        //write aligned right with 15 symbols
        format = String.Format("{0,15}", num);
        Console.WriteLine(format);
    }
}
