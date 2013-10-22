using System;
using System.Data.Entity;
using Forum.Model;

namespace Forum.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
            : base("ForumDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}
