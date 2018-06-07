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
    public class KlijentiController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Klijenti
        public IQueryable<Klijenti> GetKlijenti()
        {
            return db.Klijenti;
        }

        // GET: api/Klijenti/5
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult GetKlijenti(int id)
        {
            Klijenti klijenti = db.Klijenti.Find(id);
            if (klijenti == null)
            {
                return NotFound();
            }

            return Ok(klijenti);
        }

        [ResponseType(typeof(Klijenti))]
        [Route("api/Klijenti/GetByUsername/{username}")]
        public IHttpActionResult GetByUsername(string username)
        {
            Klijenti k = db.Klijenti.Where(x => x.KorisickoIme == username).FirstOrDefault();

            if (k == null)
            {
                return NotFound();
            }

            return Ok(k);
        }

        // PUT: api/Klijenti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlijenti(int id, Klijenti klijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klijenti.KlijentID)
            {
                return BadRequest();
            }

            db.Entry(klijenti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlijentiExists(id))
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

        // POST: api/Klijenti
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult PostKlijenti(Klijenti klijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klijenti.Add(klijenti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = klijenti.KlijentID }, klijenti);
        }

        // DELETE: api/Klijenti/5
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult DeleteKlijenti(int id)
        {
            Klijenti klijenti = db.Klijenti.Find(id);
            if (klijenti == null)
            {
                return NotFound();
            }

            db.Klijenti.Remove(klijenti);
            db.SaveChanges();

            return Ok(klijenti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlijentiExists(int id)
        {
            return db.Klijenti.Count(e => e.KlijentID == id) > 0;
        }
    }
}