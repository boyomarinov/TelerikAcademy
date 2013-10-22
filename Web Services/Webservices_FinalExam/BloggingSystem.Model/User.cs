using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace BloggingSystem.Model
{
    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [StringLength(30)]
        public string DisplayName { get; set; }

        [MinLength(40)]
        [MaxLength(40)]
        [StringLength(40)]
        public string AuthCode { get; set; }

        [MinLength(50)]
        [MaxLength(50)]
        [StringLength(50)]
        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; } 
    }
}
