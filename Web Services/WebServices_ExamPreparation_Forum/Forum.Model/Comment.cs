using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Forum.Model
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [MinLength(12)]
        [Column(TypeName="ntext")]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual User PostedByUser { get; set; }
        public virtual Post ForPost { get; set; }
    }
}
