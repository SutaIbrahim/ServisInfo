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
    public class OcjeneController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Ocjene
        public IQueryable<Ocjene> GetOcjene()
        {
            return db.Ocjene;
        }

        // GET: api/Ocjene/5
        [ResponseType(typeof(Ocjene))]
        public IHttpActionResult GetOcjene(int id)
        {
            Ocjene ocjene = db.Ocjene.Find(id);
            if (ocjene == null)
            {
                return NotFound();
            }

            return Ok(ocjene);
        }

        [ResponseType(typeof(Ocjene))]
        [Route("api/Ocjene/GetOcjeneList/{ServisId}")]
        public IHttpActionResult GetOcjeneList(int ServisId)
        {
            List<Ocjene> ocjene = db.Ocjene.Where(x => x.ServisID == ServisId).ToList();
            if (ocjene == null)
            {
                return NotFound();
            }

            return Ok(ocjene);
        }

        // PUT: api/Ocjene/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOcjene(int id, Ocjene ocjene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ocjene.OcjenaID)
            {
                return BadRequest();
            }

            db.Entry(ocjene).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcjeneExists(id))
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

        // POST: api/Ocjene
        [ResponseType(typeof(Ocjene))]
        public IHttpActionResult PostOcjene(Ocjene ocjene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ocjene.Add(ocjene);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ocjene.OcjenaID }, ocjene);
        }

        // DELETE: api/Ocjene/5
        [ResponseType(typeof(Ocjene))]
        public IHttpActionResult DeleteOcjene(int id)
        {
            Ocjene ocjene = db.Ocjene.Find(id);
            if (ocjene == null)
            {
                return NotFound();
            }

            db.Ocjene.Remove(ocjene);
            db.SaveChanges();

            return Ok(ocjene);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OcjeneExists(int id)
        {
            return db.Ocjene.Count(e => e.OcjenaID == id) > 0;
        }
    }
}