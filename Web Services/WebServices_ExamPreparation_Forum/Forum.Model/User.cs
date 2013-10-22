using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Forum.Model
{
    public class User
    {
        
        public User()
        {
            this.Threads = new HashSet<Thread>();
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }

        public int UserId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [StringLength(30)]
        public string Nickname { get; set; }

        [MinLength(40)]
        [MaxLength(40)]
        [StringLength(40)]
        public string AuthCode { get; set; }

        [MinLength(50)]
        [MaxLength(50)]
        [StringLength(50)]
        public string SessionKey { get; set; }

        public virtual ICollection<Thread> Threads { get; set; } 
        public virtual ICollection<Post> Posts { get; set; } 
        public virtual ICollection<Comment> Comments { get; set; } 
    }
}
