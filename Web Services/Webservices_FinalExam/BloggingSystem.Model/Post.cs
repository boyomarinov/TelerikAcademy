using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BloggingSystem.Model
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }

        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(12)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public virtual User PostedBy { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } 
    }
}
