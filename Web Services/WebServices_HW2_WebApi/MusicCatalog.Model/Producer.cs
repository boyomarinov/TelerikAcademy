using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Model
{
    public class Producer
    {
        public Producer()
        {
            Artists = new HashSet<Artist>();
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }

        public int ProducerId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Song> Songs { get; set; } 
    }
}