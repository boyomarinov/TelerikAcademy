using System.Collections.Generic;
using System.ComponentModel;
using Forum.Model;

namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Forum.Data.ForumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Forum.Data.ForumDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Categories.AddOrUpdate(
            //  c => c.Name,
            //  new Category { Name = "Spam" }
            //);


            //Category testCategory = new Category()
            //{
            //    Name = "Category Title"
            //};
            //context.Categories.Add(testCategory);
            ////context.SaveChanges();

            //Thread testThread = new Thread()
            //{
            //    Content = "Some content",
            //};
            //testThread.Categories.Add(testCategory);
            //context.Threads.Add(testThread);
            ////context.SaveChanges();

            //Post testPost = new Post()
            //{
            //    PostDate = DateTime.Now,
            //    Content = "Post content",
            //    ForThread = testThread
            //};
            //context.Posts.Add(testPost);
            ////context.SaveChanges();

            //User testUser = new User()
            //{
            //    Nickname = "Nickname",
            //    Username = "Username",
            //    AuthCode = "0123456789012345678901234567890123456789",
            //};
            ////testUser.Threads.Add(testThread);
            ////testUser.Posts.Add(testPost);

            //context.SaveChanges();
        }
    }
}
