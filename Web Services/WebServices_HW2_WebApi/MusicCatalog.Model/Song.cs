using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Model
{
    public class Song
    {
        public Song()
        {
            Artists = new HashSet<Artist>();
        }

        public int SongId { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }

        public int Duration { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}