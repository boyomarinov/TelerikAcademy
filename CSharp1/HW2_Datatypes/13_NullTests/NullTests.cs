using System;

class NullTests
{
    static void Main()
    {
        int? testNullInt = null;
        double? testNullDouble = null;
        Console.WriteLine("Original testNullInt: {0}", testNullInt.GetValueOrDefault());
        Console.WriteLine("Original testNullDouble: {0}", testNullDouble.GetValueOrDefault());
        
        Console.WriteLine("Add 19 to testNullInt: {0}", (testNullInt + 19).GetValueOrDefault());
        Console.WriteLine("Add 19 to testNullDouble: {0}", (testNullDouble + 19).GetValueOrDefault());

        testNullInt = 31;
        testNullDouble = 31;
        Console.WriteLine("Modified to 31 testNullInt: {0}", testNullInt.GetValueOrDefault());
        Console.WriteLine("Modified to 31 testNullDouble: {0}", testNullDouble.GetValueOrDefault());
    }
}