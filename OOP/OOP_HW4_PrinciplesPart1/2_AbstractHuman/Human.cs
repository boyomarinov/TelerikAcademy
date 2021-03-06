﻿using System;
using System.Collections.Generic;

namespace _2_AbstractHuman
{
    abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName = "")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public override string ToString()
        {
            return (this.firstName + " " + this.lastName);
        }
    }
}
