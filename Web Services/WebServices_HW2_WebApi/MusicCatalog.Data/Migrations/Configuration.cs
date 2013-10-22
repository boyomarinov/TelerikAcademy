using MusicCatalog.Model;

namespace MusicCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MusicCatalog.Data.MusicCatalogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicCatalog.Data.MusicCatalogEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Albums.AddOrUpdate(
              a => a.Title,
              new Album { Title = "Andrew Peters" },
              new Album { Title = "Brice Lambson" },
              new Album { Title = "Rowan Miller" }
            );
        }
    }
}
