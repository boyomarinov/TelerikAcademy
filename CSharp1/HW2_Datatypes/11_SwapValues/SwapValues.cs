using System;

class SwapValues
{
    
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("Original a: {0}", a);
        Console.WriteLine("Original b: {0}", b);

        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine("After swapping... a={0}", a);
        Console.WriteLine("After swapping... b={0}", b);
    }
}

