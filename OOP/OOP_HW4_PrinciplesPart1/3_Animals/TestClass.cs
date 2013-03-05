using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_Animals
{
    class TestClass
    {
        static void CalculateAverageAge(List<Animal> animals)
        {
            var average = animals.Average(x => x.Age);
            Console.WriteLine("Average age: {0:F2}", average);
        }

        static void Main()
        {
            //Dogs
            List<Animal> dogs = new List<Animal>();
            dogs.Add(new Dog(3, "Sharo", 'm'));
            dogs.Add(new Dog(5, "Laika", 'f'));
            dogs.Add(new Dog(6, "Tara", 'f'));

            CalculateAverageAge(dogs);
            foreach (var item in dogs)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }


            //Frogs
            List<Animal> frogs = new List<Animal>();
            frogs.Add(new Frog(1, "Kurmit", 'm'));
            frogs.Add(new Frog(2, "Kikeritsa", 'f'));
            frogs.Add(new Frog(1, "Vodolazii", 'm'));

            CalculateAverageAge(frogs);
            foreach (var item in frogs)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }



        }
    }
}
