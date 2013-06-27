using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_OrderedStudents
{
    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int CompareTo(Student other)
        {
            if (string.Compare(this.FirstName, other.FirstName) == 0)
            {
                return string.Compare(this.LastName, other.LastName);
            }
            else
            {
                return string.Compare(this.FirstName, other.FirstName);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
