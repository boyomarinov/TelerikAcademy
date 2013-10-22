using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolSystem.Models;

namespace SchoolSystem.Services.Models
{
    public class StudentDetailedModel : StudentModel
    {
        public StudentDetailedModel()
        {
            this.Marks = new HashSet<MarkModel>();
        }

        public virtual ICollection<MarkModel> Marks { get; set; }

        public virtual School School { get; set; }
    }
}