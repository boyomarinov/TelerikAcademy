using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolSystem.Models;

namespace SchoolSystem.Services.Models
{
    public class MarkDetailedModel : MarkModel
    {
        public virtual StudentModel Student { get; set; }
    }
}