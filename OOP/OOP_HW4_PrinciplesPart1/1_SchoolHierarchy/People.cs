using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class People : Comment
    {
        protected string name;

        //Constructor
        public People(string name)
            : base()
        {
            this.name = name;
        }

        public People(string name, string comment)
            : base(comment)
        {
            this.name = name;
        }

        //Property
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
