using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class School
    {
        private string name;
        private List<Class> classes;

        #region Constructor
        public School(string name)
        {
            this.name = name;
            this.classes = new List<Class>();
        }

        public School(string name, List<Class> classes)
        {
            this.name = name;
            this.classes = classes;
        }
        #endregion

        //Property
        public List<Class> studentClasses
        {
            get { return this.classes; }
        }

        public void AddClass(Class toAdd)
        {
            if (!this.studentClasses.Contains(toAdd))
            {
                this.studentClasses.Add(toAdd);
            }
            else
            {
                Console.WriteLine("Class already exists in this school.");
            }
        }

        public void Print()
        {
            Console.WriteLine(this.name);
            Console.WriteLine();

            foreach (var item in classes)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }

    }
}
