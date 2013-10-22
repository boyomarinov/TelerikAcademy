using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Model
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            Producers = new HashSet<Producer>();
        }

        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Producer> Producers { get; set; } 
    }
}