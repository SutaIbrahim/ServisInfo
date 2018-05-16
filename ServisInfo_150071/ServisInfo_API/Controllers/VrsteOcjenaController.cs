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
    public class VrsteOcjenaController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/VrsteOcjena
        public IQueryable<VrsteOcjena> GetVrsteOcjena()
        {
            return db.VrsteOcjena;
        }

        // GET: api/VrsteOcjena/5
        [ResponseType(typeof(VrsteOcjena))]
        public IHttpActionResult GetVrsteOcjena(int id)
        {
            VrsteOcjena vrsteOcjena = db.VrsteOcjena.Find(id);
            if (vrsteOcjena == null)
            {
                return NotFound();
            }

            return Ok(vrsteOcjena);
        }

        // PUT: api/VrsteOcjena/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVrsteOcjena(int id, VrsteOcjena vrsteOcjena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vrsteOcjena.VrstaOcjeneID)
            {
                return BadRequest();
            }

            db.Entry(vrsteOcjena).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VrsteOcjenaExists(id))
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

        // POST: api/VrsteOcjena
        [ResponseType(typeof(VrsteOcjena))]
        public IHttpActionResult PostVrsteOcjena(VrsteOcjena vrsteOcjena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VrsteOcjena.Add(vrsteOcjena);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vrsteOcjena.VrstaOcjeneID }, vrsteOcjena);
        }

        // DELETE: api/VrsteOcjena/5
        [ResponseType(typeof(VrsteOcjena))]
        public IHttpActionResult DeleteVrsteOcjena(int id)
        {
            VrsteOcjena vrsteOcjena = db.VrsteOcjena.Find(id);
            if (vrsteOcjena == null)
            {
                return NotFound();
            }

            db.VrsteOcjena.Remove(vrsteOcjena);
            db.SaveChanges();

            return Ok(vrsteOcjena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VrsteOcjenaExists(int id)
        {
            return db.VrsteOcjena.Count(e => e.VrstaOcjeneID == id) > 0;
        }
    }
}