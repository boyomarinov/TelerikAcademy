using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class Teacher : People
    {
        //private Comment comment;

        public Teacher(string name)
            : base(name)
        { }

        public Teacher(string name, string comment)
            : base(name, comment)
        { }

        public override string ToString()
        {
            return String.Format("{0}  {1}", base.Name, base.CommentText);
        }
    }
}
