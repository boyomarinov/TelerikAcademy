using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SchoolSystem.Models;

namespace SchoolSystem.Services.Models
{
    public class MarkModel
    {
        public int MarkId { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }

        public static Expression<Func<Mark, MarkModel>> FromMark
        {
            get
            {
                return x => new MarkModel { MarkId = x.MarkId, Subject = x.Subject, Value = x.Value};
            }
        }

        public Mark CreateMark()
        {
            return new Mark { MarkId = this.MarkId, Subject = this.Subject, Value = this.Value };
        }

        public void UpdateMark(Mark mark)
        {
            if (this.Subject != null)
            {
                mark.Subject = this.Subject;
            }

            //if (this.Value != null)
            //{
                mark.Value = this.Value;
            //}
        }
    }
}