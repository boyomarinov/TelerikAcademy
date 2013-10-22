using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.Services.Models
{
    public class SchoolDetailedModel : SchoolModel
    {
        public SchoolDetailedModel()
        {
            this.Students = new HashSet<StudentModel>();
        }

        public virtual ICollection<StudentModel> Students { get; set; }
    }
}