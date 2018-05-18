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
    public class KompanijeController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Kompanije
        public IQueryable<Kompanije> GetKompanije()
        {
            return db.Kompanije;
        }

        // GET: api/Kompanije/5
        [ResponseType(typeof(Kompanije))]
        public IHttpActionResult GetKompanije(int id)
        {
            Kompanije kompanije = db.Kompanije.Find(id);
            if (kompanije == null)
            {
                return NotFound();
            }

            return Ok(kompanije);
        }

        [ResponseType(typeof(Kompanije))]
        [Route("api/Kompanije/GetByKorisnickoIme/{korisnickoIme}")]
        public IHttpActionResult GetByKorisnickoIme(string korisnickoIme)
        {
            Kompanije kompanija = db.esp_Kompanije_GetByKorisnickoIme(korisnickoIme).FirstOrDefault();

            if (kompanija == null)
            {
                return NotFound();
            }

            return Ok(kompanija);
        }





        

        // PUT: api/Kompanije/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKompanije(int id, Kompanije kompanije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kompanije.KompanijaID)
            {
                return BadRequest();
            }

            db.Entry(kompanije).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KompanijeExists(id))
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

        // POST: api/Kompanije
        [ResponseType(typeof(Kompanije))]
        public IHttpActionResult PostKompanije(Kompanije kompanije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kompanije.Add(kompanije);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kompanije.KompanijaID }, kompanije);
        }

        // DELETE: api/Kompanije/5
        [ResponseType(typeof(Kompanije))]
        public IHttpActionResult DeleteKompanije(int id)
        {
            Kompanije kompanije = db.Kompanije.Find(id);
            if (kompanije == null)
            {
                return NotFound();
            }

            db.Kompanije.Remove(kompanije);
            db.SaveChanges();

            return Ok(kompanije);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KompanijeExists(int id)
        {
            return db.Kompanije.Count(e => e.KompanijaID == id) > 0;
        }
    }
}