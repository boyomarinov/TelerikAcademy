using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_AbstractHuman
{
    class Student : Human
    {
        private int grade;

        public Student(string fname, string lname, int grade)
            : base(fname, lname)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }
    }
}
