using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingSystem.Model;

namespace BloggingSystem.Data
{
    public class BloggingSystemDbContext : DbContext
    {
        public BloggingSystemDbContext()
            :base("BloggingSystemDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
