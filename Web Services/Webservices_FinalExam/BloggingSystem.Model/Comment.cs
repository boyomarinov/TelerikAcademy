using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace BloggingSystem.Model
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [MinLength(12)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public virtual User CommentedBy { get; set; }
        public virtual Post ForPost { get; set; }
    }
}
