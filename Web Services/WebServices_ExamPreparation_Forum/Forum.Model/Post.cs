using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Forum.Model
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        public int PostId { get; set; }

        [Required]
        [MinLength(12)]
        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User PostedByUser { get; set; }
        public virtual Thread ForThread { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; } 
    }
}
