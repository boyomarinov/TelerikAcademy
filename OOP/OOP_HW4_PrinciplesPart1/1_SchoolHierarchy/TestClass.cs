using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class TestClass
    {
        static void Main()
        {
            //create school and classes
            School tues = new School("TBG");
            Class one = new Class("8a");
            Class second = new Class("10b");

            //create a student and assign him to a class
            Student goshko = new Student("Georgi Ivanov", 9);
            Student iliana = new Student("Iliana Dimitrova", 11);
            Student ivancho = new Student("Ivan Gushkov", 13);
            Student mariika = new Student("Mariq Stefanova", 18);

            //add comment to a student
            goshko.AddComment("Best student in class");

            //add students to a class
            one.AddStudent(goshko);
            one.AddStudent(iliana);
            second.AddStudent(ivancho);
            second.AddStudent(mariika);

            //add teacher to class
            Teacher petrova = new Teacher("G-ja Petrova", "Matematika");
            Teacher ivanova = new Teacher("Gospojica Ivanova");
            one.AddTeacher(petrova);
            second.AddTeacher(ivanova);

            //add classes to school
            tues.AddClass(one);
            tues.AddClass(second);

            //Print info for school
            tues.Print();

        }
    }
}
