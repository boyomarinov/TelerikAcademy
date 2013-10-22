using System;
using System.Collections.Generic;
using System.Linq;


namespace SchoolSystem.Models
{
    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
        }

        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; } 
    }
}
