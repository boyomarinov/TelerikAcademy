using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class Student : People
    {
        private int classNumber;

        //Constructor
        public Student(string name, int classNumber)
            : base(name)
        {
            this.classNumber = classNumber;
        }

        //Property
        public int ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}  {2}",
                this.classNumber, base.Name, base.CommentText);
        }
    }
}
