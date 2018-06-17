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
    public class ModeliUredjajaController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/ModeliUredjaja
        public IQueryable<ModeliUredjaja> GetModeliUredjaja()
        {
            return db.ModeliUredjaja;
        }

        // GET: api/ModeliUredjaja/5
        [ResponseType(typeof(ModeliUredjaja))]
        public IHttpActionResult GetModeliUredjaja(int id)
        {
            ModeliUredjaja modeliUredjaja = db.ModeliUredjaja.Find(id);
            if (modeliUredjaja == null)
            {
                return NotFound();
            }

            return Ok(modeliUredjaja);
        }

        [Route("api/ModeliUredjaja/GetByMarkaId/{markaId}")]
        public IHttpActionResult GetByMarkaId(string markaId)
        {

            int id = Convert.ToInt32(markaId);

            List<ModeliUredjaja> modeli = db.ModeliUredjaja.Where(x => x.MarkaUredjajaID == id).ToList();


            return Ok(modeli);
        }
        // PUT: api/ModeliUredjaja/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModeliUredjaja(int id, ModeliUredjaja modeliUredjaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modeliUredjaja.ModelUredjajaID)
            {
                return BadRequest();
            }

            db.Entry(modeliUredjaja).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeliUredjajaExists(id))
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



        // POST: api/ModeliUredjaja
        [ResponseType(typeof(ModeliUredjaja))]
        public IHttpActionResult PostModeliUredjaja(ModeliUredjaja modeliUredjaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModeliUredjaja.Add(modeliUredjaja);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modeliUredjaja.ModelUredjajaID }, modeliUredjaja);
        }

        // DELETE: api/ModeliUredjaja/5
        [ResponseType(typeof(ModeliUredjaja))]
        public IHttpActionResult DeleteModeliUredjaja(int id)
        {
            ModeliUredjaja modeliUredjaja = db.ModeliUredjaja.Find(id);
            if (modeliUredjaja == null)
            {
                return NotFound();
            }

            db.ModeliUredjaja.Remove(modeliUredjaja);
            db.SaveChanges();

            return Ok(modeliUredjaja);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeliUredjajaExists(int id)
        {
            return db.ModeliUredjaja.Count(e => e.ModelUredjajaID == id) > 0;
        }
    }
}