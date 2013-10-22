using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SchoolSystem.Models;
using SchoolSystem.Data;
using SchoolSystem.Repositories;
using SchoolSystem.Services.Models;

namespace SchoolSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {
        //private MusicCatalogEntities db = new MusicCatalogEntities();
        private IRepository<Student> db; 

        public StudentsController()
        {
            this.db = new EfRepository<Student>(new SchoolSystemContext());
            //db.Configuration.ProxyCreationEnabled = false;
        }

        public StudentsController(IRepository<Student> repository)
        {
            this.db = repository;
        }

        // GET api/Students
        public IQueryable<StudentModel> Get()
        {
            return this.db.All().Select(StudentModel.FromStudent);
        }

        // GET api/Students/5
        public StudentDetailedModel Get(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The name of the Category should be at least 6 characters");
                throw new HttpResponseException(errResponse);
            }

            var studentEntity = this.db.All().First(x => x.StudentId == id);//.Select(StudentModel.FromStudent).FirstOrDefault();
            if (studentEntity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var Student = new StudentDetailedModel()
            {
                StudentId = studentEntity.StudentId,
                FirstName = studentEntity.FirstName,
                LastName = studentEntity.LastName,
                Age = studentEntity.Age,
                Grade = studentEntity.Grade,
                School = studentEntity.School,
                Marks = (
                    from marksEntity in studentEntity.Marks
                    select new MarkModel()
                    {
                        MarkId = marksEntity.MarkId,
                        Subject = marksEntity.Subject,
                        Value = marksEntity.Value
                    }
                ).ToList()
            };

            return Student;
        }

        // PUT api/Students/5
        public HttpResponseMessage Put(int id, Student Student)
        {
            //var studentEntity = db.Get(id);
            this.db.Update(id, Student);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Students
        public HttpResponseMessage PostStudent([FromBody]StudentModel Student)
        {
            var newStudent = Student.CreateStudent();
            this.db.Add(newStudent);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + newStudent.StudentId.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        //// DELETE api/Students/5
        public HttpResponseMessage DeleteStudent(int id)
        {
            this.db.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}