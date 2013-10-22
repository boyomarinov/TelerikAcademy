using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class SchoolSystemContext : DbContext
    {
        public SchoolSystemContext()
            : base("SchoolSystem")
        {
        }

        public DbSet<School> Schools;

        public DbSet<Student> Students;

        public DbSet<Mark> Marks;
    }
}
