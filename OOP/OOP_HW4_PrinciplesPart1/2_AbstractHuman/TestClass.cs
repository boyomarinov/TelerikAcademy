using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_AbstractHuman
{
    class TestClass
    {
        static void Main()
        {
            //Populate list of 10 students
            List<Student> students = new List<Student>();

            students.Add(new Student("Angel", "Angelov", 5));
            students.Add(new Student("Alexander", "Aleksandrov", 4));
            students.Add(new Student("Boris", "Borisov", 6));
            students.Add(new Student("Vasil", "Vasilev", 3));
            students.Add(new Student("Georgi", "Georgiev", 4));
            students.Add(new Student("Ivan", "Ivanov", 6));
            students.Add(new Student("Naum", "Naumov", 3));
            students.Add(new Student("Ognqn", "Ognqnov", 6));
            students.Add(new Student("Preslav", "Preslavov", 5));
            students.Add(new Student("Todor", "Todorov", 6));

            //Sort them by grade in ascending order
            var sortedStudents =
                from st in students
                orderby st.Grade ascending
                select st;


            //Populate list of 10 workers
            List<Worker> workers = new List<Worker>();

            workers.Add(new Worker("A4o", "Traktorista", 180, 30));
            workers.Add(new Worker("Sasho", "Zavarchika", 190, 40));
            workers.Add(new Worker("Boreto", "Strugarq", 200, 30));
            workers.Add(new Worker("Vasko", "Chuka", 220, 45));
            workers.Add(new Worker("Joro", "Gipsa", 210, 25));
            workers.Add(new Worker("Ivan", "Kranista", 400, 40));
            workers.Add(new Worker("Naum", "Dvenaum", 600, 2));
            workers.Add(new Worker("Ognqn", "Oksijena", 200, 35));
            workers.Add(new Worker("Papi", "Lopatata", 150, 40));
            workers.Add(new Worker("Tosho", "Bagerista", 240, 40));

            //Sort workers by money they earn per hour
            var sortedWorkers = workers.OrderBy(w => w.MoneyPerHour());

            //Make collection of all the sorted resuls
            List<Human> all = new List<Human>(sortedStudents.ToList());
            all.AddRange(sortedWorkers.ToList());

            //Sort them by first and last name
            var finalSorted =
                from h in all
                orderby h.FirstName, h.LastName
                select h;

            //Print result
            foreach (var item in finalSorted)
            {
                Console.WriteLine(item);
            }
        }
    }
}
