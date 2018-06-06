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

        [HttpGet]
        [Route("api/Servisi/GetByDate/{kompanijaID}/{datum}/{datum2}/{status}")]
        public List<KompanijaServisi_Result> GetByDate(string kompanijaID, string datum, string datum2,string status)
        {
            DateTime Datum = Convert.ToDateTime(datum);
            DateTime Datum2 = Convert.ToDateTime(datum2);


            List<KompanijaServisi_Result> servisi = db.esp_KompanijeServisi_GetByDate(Convert.ToInt32(kompanijaID), Datum, Datum2,status).ToList();

            return servisi;
        }

        [HttpGet]
        [Route("api/Servisi/GetDetalji/{id}")]
        public IHttpActionResult GetDetalji(string id)
        {

            ServisDetalji_Result servis = db.esp_Servisi_DetaljiByID(Convert.ToInt32(id)).FirstOrDefault();

            return Ok(servis);
        }


        [HttpGet]
        [Route("api/Servisi/GetServisByPonudaID/{id}")]
        public IHttpActionResult GetServisIDByPonudaID(string id)
        {

            int servisID = Convert.ToInt32(  db.esp_GetServisIDbyPonudaID(Convert.ToInt32(id)).FirstOrDefault());

            return Ok(servisID);
        }


        [HttpGet]
        [Route("api/Servisi/GetCountUtoku/{id}")]
        public int? GetCountUtoku(string id)
        {
            return db.esp_ServisiUTokuCount(Convert.ToInt32(id)).FirstOrDefault();
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