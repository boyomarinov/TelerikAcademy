////6. Write a program that prints from given array of integers 
////all numbers that are divisible by 7 and 3. Use the built-in 
////extension methods and lambda expressions. Rewrite the same 
////with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

class DivisibleBy7And3
{
    static void Main()
    {
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        //Get values with lambda expressions
        var byLambda = nums.FindAll(x => x % 3 == 0 || x % 7 == 0);

        Console.WriteLine("Lambda found:");
        foreach (var item in byLambda)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        //Get values with LINQ
        var byLinq =
            from n in nums
            where n % 3 == 0 || n % 7 == 0
            select n;

        Console.WriteLine("LINQ found:");
        foreach (var item in byLinq)
        {
            Console.WriteLine(item);
        }
    }
}
