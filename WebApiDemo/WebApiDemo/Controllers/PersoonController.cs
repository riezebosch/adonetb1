using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class PersoonController : ApiController
    {
        private MijnContext db = new MijnContext();

        // GET api/Persoon
        public IQueryable<Persoon> GetPersonen()
        {
            return db.Personen;
        }

        // GET api/Persoon/5
        [ResponseType(typeof(Persoon))]
        public IHttpActionResult GetPersoon(int id)
        {
            //  De Find vervangen met FirstOrDefault omdat de Find niet kan in combinatie met een Include
            Persoon persoon = db.Personen.Include(p => p.Producten).FirstOrDefault(p => p.Id == id);
            if (persoon == null)
            {
                return NotFound();
            }

            return Ok(persoon);
        }

        // PUT api/Persoon/5
        public IHttpActionResult PutPersoon(int id, Persoon persoon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persoon.Id)
            {
                return BadRequest();
            }

            db.Entry(persoon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST api/Persoon
        [ResponseType(typeof(Persoon))]
        public IHttpActionResult PostPersoon(Persoon persoon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personen.Add(persoon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = persoon.Id }, persoon);
        }

        // DELETE api/Persoon/5
        [ResponseType(typeof(Persoon))]
        public IHttpActionResult DeletePersoon(int id)
        {
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return NotFound();
            }

            db.Personen.Remove(persoon);
            db.SaveChanges();

            return Ok(persoon);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool PersoonExists(int id)
        {
            return db.Personen.Count(e => e.Id == id) > 0;
        }
    }
}