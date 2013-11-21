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

namespace WebApiDemo2.Controllers
{
    public class PersoonController : ApiController
    {
        private MijnContext db = new MijnContext();
        public PersoonController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET api/Persoon
        public IEnumerable<Persoon> GetPersoons()
        {
            return db.Personen.AsEnumerable();
        }

        // GET api/Persoon/5
        public Persoon GetPersoon(int id)
        {
            Persoon persoon = db
                .Personen
                .Include(p => p.Producten)
                .SingleOrDefault(p => p.Id == id);

            if (persoon == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return persoon;
        }

        // PUT api/Persoon/5
        public HttpResponseMessage PutPersoon(int id, Persoon persoon)
        {
            if (ModelState.IsValid && id == persoon.Id)
            {
                db.Entry(persoon).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Persoon
        public HttpResponseMessage PostPersoon(Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Personen.Add(persoon);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, persoon);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = persoon.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Persoon/5
        public HttpResponseMessage DeletePersoon(int id)
        {
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Personen.Remove(persoon);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, persoon);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}