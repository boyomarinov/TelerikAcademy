using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SchoolSystem.Models;

namespace SchoolSystem.Services.Models
{
    public class SchoolModel
    {
        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public static Expression<Func<School, SchoolModel>> FromSchool
        {
            get
            {
                return x => new SchoolModel { SchoolId = x.SchoolId, Name = x.Name, Location = x.Location };
            }
        }

        public School CreateSchool()
        {
            return new School { SchoolId = this.SchoolId, Name = this.Name, Location = this.Location };
        }

        public void UpdateSchool(School school)
        {
            if (this.Name != null)
            {
                school.Name = this.Name;
            }

            if (this.Location != null)
            {
                school.Location = this.Location;
            }
        }
    }
}