using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicCatalog.Data;
using MusicCatalog.Model;

namespace MusicCatalog.Controllers
{
    public class ProducersController : ApiController
    {
        private MusicCatalogEntities db = new MusicCatalogEntities();

        public ProducersController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Producers
        public IEnumerable<Producer> GetProducers()
        {
            return db.Producers.AsEnumerable();
        }

        // GET api/Producers/5
        public Producer GetProducer(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return producer;
        }

        // PUT api/Producers/5
        public HttpResponseMessage PutProducer(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != producer.ProducerId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(producer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Producers
        public HttpResponseMessage PostProducer(Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producer);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, producer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = producer.ProducerId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Producers/5
        public HttpResponseMessage DeleteProducer(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Producers.Remove(producer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, producer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}