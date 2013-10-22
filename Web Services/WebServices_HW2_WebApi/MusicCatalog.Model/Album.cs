using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Model
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
            Artists = new HashSet<Artist>();
        }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}