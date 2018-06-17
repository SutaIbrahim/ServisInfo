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
    public class MarkeUredjajaController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/MarkeUredjaja
        public IQueryable<MarkeUredjaja> GetMarkeUredjaja()
        {
            return db.MarkeUredjaja;
        }

        // GET: api/MarkeUredjaja/5
        [ResponseType(typeof(MarkeUredjaja))]
        public IHttpActionResult GetMarkeUredjaja(int id)
        {
            MarkeUredjaja markeUredjaja = db.MarkeUredjaja.Find(id);
            if (markeUredjaja == null)
            {
                return NotFound();
            }

            return Ok(markeUredjaja);
        }

        // PUT: api/MarkeUredjaja/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarkeUredjaja(int id, MarkeUredjaja markeUredjaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != markeUredjaja.MarkaUredjajaID)
            {
                return BadRequest();
            }

            db.Entry(markeUredjaja).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkeUredjajaExists(id))
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

        // POST: api/MarkeUredjaja
        [ResponseType(typeof(MarkeUredjaja))]
        public IHttpActionResult PostMarkeUredjaja(MarkeUredjaja markeUredjaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MarkeUredjaja.Add(markeUredjaja);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = markeUredjaja.MarkaUredjajaID }, markeUredjaja);
        }

        // DELETE: api/MarkeUredjaja/5
        [ResponseType(typeof(MarkeUredjaja))]
        public IHttpActionResult DeleteMarkeUredjaja(int id)
        {
            MarkeUredjaja markeUredjaja = db.MarkeUredjaja.Find(id);
            if (markeUredjaja == null)
            {
                return NotFound();
            }

            db.MarkeUredjaja.Remove(markeUredjaja);
            db.SaveChanges();

            return Ok(markeUredjaja);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarkeUredjajaExists(int id)
        {
            return db.MarkeUredjaja.Count(e => e.MarkaUredjajaID == id) > 0;
        }
    }
}