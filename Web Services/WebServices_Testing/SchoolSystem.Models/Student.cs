using System;
using System.Collections.Generic;
using System.Linq;


namespace SchoolSystem.Models
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public virtual School School { get; set; }
    }
}
