////5. Using the extension methods OrderBy() and ThenBy()
////with lambda expressions sort the students by first 
////name and last name in descending order. Rewrite the 
////same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

class SortStudents
{
    static void Main()
    {
        //Init students
        List<Student> students = new List<Student>();
        students.Add(new Student("Joro", "Ivanov", 25));
        students.Add(new Student("Alexander", "Georgiev", 20));
        students.Add(new Student("Canko", "Cankovski", 22));
        students.Add(new Student("Maria", "Atanassova", 23));
        students.Add(new Student("Alexander", "Tanchev", 24));

        //Sort with LINQ
        var sorted =
            from st in students
            orderby st.FirstName, st.LastName
            select st;

        Console.WriteLine("Sorted with LINQ:");
        foreach (var item in sorted)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
        Console.WriteLine();

        //Sort with lambda functions
        var lambdaSorted = students.OrderBy(student => student.FirstName).ThenBy(student => student.LastName);

        Console.WriteLine("Sorted with Lambda functions:");
        foreach (var item in lambdaSorted)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
    }
}
