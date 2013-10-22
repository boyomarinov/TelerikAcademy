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
    public class SchoolsController : ApiController
    {
        //private MusicCatalogEntities db = new MusicCatalogEntities();
        private IRepository<School> db; 

        public SchoolsController()
        {
            this.db = new EfRepository<School>(new SchoolSystemContext());
            //db.Configuration.ProxyCreationEnabled = false;
        }

        public SchoolsController(IRepository<School> repository)
        {
            this.db = repository;
        }

        // GET api/Schools
        public IQueryable<SchoolModel> Get()
        {
            return this.db.All().Select(SchoolModel.FromSchool);
        }

        // GET api/Schools/5
        public SchoolDetailedModel Get(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The name of the Category should be at least 6 characters");
                throw new HttpResponseException(errResponse);
            }

            var schoolEntity = this.db.All().First(x => x.SchoolId == id);//.Select(SchoolModel.FromSchool).FirstOrDefault();
            if (schoolEntity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var School = new SchoolDetailedModel()
            {
                SchoolId = schoolEntity.SchoolId,
                Name = schoolEntity.Name,
                Location = schoolEntity.Location,
                Students = schoolEntity.Students.AsQueryable().Select(StudentModel.FromStudent).ToList()
            };

            return School;
        }

        // PUT api/Schools/5
        public HttpResponseMessage Put(int id, School School)
        {
            //var SchoolEntity = db.Get(id);
            this.db.Update(id, School);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Schools
        public HttpResponseMessage PostSchool([FromBody]SchoolModel School)
        {
            var newSchool = School.CreateSchool();
            this.db.Add(newSchool);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + newSchool.SchoolId.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        //// DELETE api/Schools/5
        public HttpResponseMessage DeleteSchool(int id)
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