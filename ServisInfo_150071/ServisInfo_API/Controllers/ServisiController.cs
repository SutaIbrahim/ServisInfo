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
    public class ServisiController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Servisi
        public IQueryable<Servisi> GetServisi()
        {
            return db.Servisi;
        }

        // GET: api/Servisi/5
        [ResponseType(typeof(Servisi))]
        public IHttpActionResult GetServisi(int id)
        {
            Servisi servisi = db.Servisi.Find(id);
            if (servisi == null)
            {
                return NotFound();
            }

            return Ok(servisi);
        }

        // PUT: api/Servisi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServisi(int id, Servisi servisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servisi.ServisID)
            {
                return BadRequest();
            }

            db.Entry(servisi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServisiExists(id))
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

        // POST: api/Servisi
        [ResponseType(typeof(Servisi))]
        public IHttpActionResult PostServisi(Servisi servisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servisi.Add(servisi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servisi.ServisID }, servisi);
        }

        // DELETE: api/Servisi/5
        [ResponseType(typeof(Servisi))]
        public IHttpActionResult DeleteServisi(int id)
        {
            Servisi servisi = db.Servisi.Find(id);
            if (servisi == null)
            {
                return NotFound();
            }

            db.Servisi.Remove(servisi);
            db.SaveChanges();

            return Ok(servisi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServisiExists(int id)
        {
            return db.Servisi.Count(e => e.ServisID == id) > 0;
        }
    }
}