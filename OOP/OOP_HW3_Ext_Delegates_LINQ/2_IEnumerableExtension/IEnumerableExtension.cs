////2. Implement a set of extension methods for IEnumerable<T> 
////that implement the following group functions: sum, product,
////min, max, average.

using System;
using System.Linq;
using System.Collections.Generic;

public static class IEnumerableExtension
{
    //Create extension method for IEnumerable to check if collection is empty
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> elements)
    {
        return elements == null || !elements.Any<T>();
    }

    //Extends IEnumerable with sum functionality
    public static dynamic Sum<T>(this IEnumerable<T> elements)
    {
        dynamic sum = 0;
        foreach (T item in elements)
        {
            sum = sum + item;
        }

        return sum;
    }

    //Extends IEnumerable with average element functionality
    public static dynamic Average<T>(this IEnumerable<T> elements)
    {
        //if collection is empty we will divide by zero at the 
        //end and this is something we don't want to do
        if (elements.IsNullOrEmpty())
        {
            return 0;
        }

        dynamic sum = 0;
        int elementsCount = 0;
        foreach (T item in elements)
        {
            sum = sum + item;
            elementsCount++;
        }
        
        return sum / elementsCount;
    }

    //Extends IEnumerable with product functionality
    public static dynamic Product<T>(this IEnumerable<T> elements)
    {
        dynamic product = 1;
        foreach (T item in elements)
        {
            product = product * item;
        }

        return product;
    }

    //Extends IEnumerable with smallest element functionality
    public static T Min<T>(this IEnumerable<T> elements)
        where T : IComparable
    {
        T min = elements.FirstOrDefault();
        foreach (T item in elements)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }

        return min;
    }

    //Extends IEnumerable with biggest element functionality
    public static T Max<T>(this IEnumerable<T> elements)
        where T : IComparable
    {
        T max = elements.FirstOrDefault();
        foreach (T item in elements)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }

    static void Main()
    {
        //test for empty IEnumerable collection
        //IEnumerable<int> elements = Enumerable.Empty<int>();


        List<int> elements = new List<int> { 1, 2, 3, 4, 5 };

        Console.WriteLine(Sum<int>(elements));
        Console.WriteLine(Average<int>(elements));
        Console.WriteLine(Product<int>(elements));
        Console.WriteLine(Min<int>(elements));
        Console.WriteLine(Max<int>(elements));
    }
}
