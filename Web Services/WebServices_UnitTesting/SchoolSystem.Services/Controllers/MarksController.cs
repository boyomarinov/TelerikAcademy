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
    public class MarksController : ApiController
    {
        private IRepository<Mark> db; 

        public MarksController()
        {
            this.db = new EfRepository<Mark>(new SchoolSystemContext());
        }

        public MarksController(IRepository<Mark> repository)
        {
            this.db = repository;
        }

        // GET api/Marks
        public IQueryable<MarkModel> Get()
        {
            return this.db.All().Select(MarkModel.FromMark);
        }

        // GET api/Marks/5
        public MarkDetailedModel Get(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The name of the Category should be at least 6 characters");
                throw new HttpResponseException(errResponse);
            }

            var markEntity = this.db.All().First(x => x.MarkId == id);//.Select(MarkModel.FromMark).FirstOrDefault();
            if (markEntity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var mark = new MarkDetailedModel()
            {
                MarkId = markEntity.MarkId,
                Subject = markEntity.Subject,
                Value = markEntity.Value,
                Student = StudentModel.FromStudent.Compile()(markEntity.Student)
            };

            return mark;
        }

        // PUT api/Marks/5
        public HttpResponseMessage Put(int id, Mark mark)
        {
            //var MarkEntity = db.Get(id);
            this.db.Update(id, mark);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Marks
        public HttpResponseMessage PostMark([FromBody]MarkModel mark)
        {
            var newMark = mark.CreateMark();
            this.db.Add(newMark);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + newMark.MarkId.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        //// DELETE api/Marks/5
        public HttpResponseMessage DeleteMark(int id)
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