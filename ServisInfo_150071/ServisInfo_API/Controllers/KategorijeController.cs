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
using ServisInfo_API.Models;

namespace ServisInfo_API.Controllers
{
    public class KategorijeController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Kategorije
        public IQueryable<Kategorije> GetKategorije()
        {
            return db.Kategorije;
        }

        // GET: api/Kategorije/5
        [ResponseType(typeof(Kategorije))]
        public IHttpActionResult GetKategorije(int id)
        {
            Kategorije kategorije = db.Kategorije.Find(id);
            if (kategorije == null)
            {
                return NotFound();
            }

            return Ok(kategorije);
        }

        // PUT: api/Kategorije/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKategorije(int id, Kategorije kategorije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kategorije.KategorijaID)
            {
                return BadRequest();
            }

            db.Entry(kategorije).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorijeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kategorije
        [ResponseType(typeof(Kategorije))]
        public IHttpActionResult PostKategorije(Kategorije kategorije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kategorije.Add(kategorije);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kategorije.KategorijaID }, kategorije);
        }

        // DELETE: api/Kategorije/5
        [ResponseType(typeof(Kategorije))]
        public IHttpActionResult DeleteKategorije(int id)
        {
            Kategorije kategorije = db.Kategorije.Find(id);
            if (kategorije == null)
            {
                return NotFound();
            }

            db.Kategorije.Remove(kategorije);
            db.SaveChanges();

            return Ok(kategorije);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KategorijeExists(int id)
        {
            return db.Kategorije.Count(e => e.KategorijaID == id) > 0;
        }
    }
}