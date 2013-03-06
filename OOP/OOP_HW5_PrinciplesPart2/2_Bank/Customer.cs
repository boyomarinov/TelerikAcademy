using System;
using System.Collections.Generic;

namespace _2_Bank
{
    abstract class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
