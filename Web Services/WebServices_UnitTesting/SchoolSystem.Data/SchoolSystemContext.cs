using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class SchoolSystemContext : DbContext
    {
        public SchoolSystemContext()
            : base("SchoolsSystemDB")
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }
    }
}
