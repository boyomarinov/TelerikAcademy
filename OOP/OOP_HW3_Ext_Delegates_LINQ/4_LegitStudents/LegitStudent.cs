////4. Write a LINQ query that finds the first name and 
////last name of all students with age between 18 and 24.

using System;
using System.Collections.Generic;
using System.Linq;

class LegitStudent
{
    static void Main()
    {
        //Init students
        List<Student> students = new List<Student>();
        students.Add(new Student("Joro", "Ivanov", 25));
        students.Add(new Student("Alexander", "Georgiev", 20));
        students.Add(new Student("Canko", "Cankovski", 22));
        students.Add(new Student("Maria", "Atanassova", 23));

        //LINQ query for selecting student between 18 and 24
        var customAge =
            from st in students
            where st.Age >= 18 && st.Age <= 24
            select st;

        Console.WriteLine("Those with age between 18 and 24 are:");
        foreach (var item in customAge)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }

    }
}

