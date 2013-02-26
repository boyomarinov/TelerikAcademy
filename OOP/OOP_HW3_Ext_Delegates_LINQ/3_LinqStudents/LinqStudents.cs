////3. Write a method that from a given array of students finds 
////all students whose first name is before its last name 
////alphabetically. Use LINQ query operators.

using System;
using System.Collections.Generic;
using System.Linq;

class LinqStudents
{
    static void Main()
    {
        //init
        List<Student> students = new List<Student>();
        students.Add(new Student("Joro", "Ivanov", 25));
        students.Add(new Student("Alexander", "Georgiev", 20));
        students.Add(new Student("Canko", "Cankovski", 22));
        students.Add(new Student("Maria", "Atanassova", 23));

        //LINQ query for selecting students whose first name
        //is lexicographicaly smaller compared to their last name
        var selected =
            from st in students
            where string.Compare(st.FirstName, st.LastName) < 0
            select st;
        
        foreach (var item in selected)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }

    }
}