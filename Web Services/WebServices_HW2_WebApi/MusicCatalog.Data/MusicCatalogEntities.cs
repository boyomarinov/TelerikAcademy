using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MusicCatalog.Model;

namespace MusicCatalog.Data
{
    public class MusicCatalogEntities : DbContext
        
    {
        public MusicCatalogEntities()
            : base("MusicCatalog")
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}