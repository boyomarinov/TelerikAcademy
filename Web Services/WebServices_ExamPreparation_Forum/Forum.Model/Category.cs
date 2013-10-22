using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Forum.Model
{
    public class Category
    {
        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }

        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
