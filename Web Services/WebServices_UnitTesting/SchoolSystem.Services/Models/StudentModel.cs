using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SchoolSystem.Models;

namespace SchoolSystem.Services.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return x => new StudentModel { StudentId = x.StudentId, FirstName = x.FirstName, LastName = x.LastName, Age = x.Age, Grade = x.Grade};
            }
        }

        public Student CreateStudent()
        {
            return new Student { StudentId = this.StudentId, FirstName = this.FirstName, LastName = this.LastName, Age = this.Age, Grade = this.Grade };
        }

        public void UpdateStudent(Student student)
        {
            if (this.FirstName != null)
            {
                student.FirstName = this.FirstName;
            }

            if (this.LastName != null)
            {
                student.LastName = this.LastName;
            }

            //if (this.Age != null)
            //{
                student.Age = this.Age;
            //}

            //if (this.Grade != null)
            //{
                student.Grade = this.Grade;
            //}
        }
    }
}