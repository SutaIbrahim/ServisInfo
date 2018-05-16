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
    public class PonudeController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Ponude
        public IQueryable<Ponude> GetPonude()
        {
            return db.Ponude;
        }

        // GET: api/Ponude/5
        [ResponseType(typeof(Ponude))]
        public IHttpActionResult GetPonude(int id)
        {
            Ponude ponude = db.Ponude.Find(id);
            if (ponude == null)
            {
                return NotFound();
            }

            return Ok(ponude);
        }

        // PUT: api/Ponude/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPonude(int id, Ponude ponude)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ponude.PonudaID)
            {
                return BadRequest();
            }

            db.Entry(ponude).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PonudeExists(id))
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

        // POST: api/Ponude
        [ResponseType(typeof(Ponude))]
        public IHttpActionResult PostPonude(Ponude ponude)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ponude.Add(ponude);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ponude.PonudaID }, ponude);
        }

        // DELETE: api/Ponude/5
        [ResponseType(typeof(Ponude))]
        public IHttpActionResult DeletePonude(int id)
        {
            Ponude ponude = db.Ponude.Find(id);
            if (ponude == null)
            {
                return NotFound();
            }

            db.Ponude.Remove(ponude);
            db.SaveChanges();

            return Ok(ponude);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PonudeExists(int id)
        {
            return db.Ponude.Count(e => e.PonudaID == id) > 0;
        }
    }
}