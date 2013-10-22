using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Forum.Model
{
    public class Thread
    {
        public Thread()
        {
            this.Posts = new HashSet<Post>();
            this.Categories = new HashSet<Category>();
        }

        public int ThreadId { get; set; }

        [Required]
        [MinLength(10)]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [MinLength(12)]
        public string Content { get; set; }

        public virtual User CreatedByUser { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Post> Posts { get; set; } 
    }
}
