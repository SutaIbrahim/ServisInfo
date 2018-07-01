using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServisInfo_API.Models;

namespace ServisInfo_API.App_Start
{
    public class UpitiController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Upiti
        public IQueryable<Upiti> GetUpiti()
        {
            return db.Upiti;
        }

        // GET: api/Upiti/5
        [ResponseType(typeof(Upiti))]
        public IHttpActionResult GetUpiti(int id)
        {
            Upiti upiti = db.Upiti.Find(id);
            if (upiti == null)
            {
                return NotFound();
            }

            return Ok(upiti);
        }

        //[HttpGet]
        //[Route("api/Upiti/GetByDate/{datum1}/{datum2}")]
        //public List<KompanijeUpiti_Result> GetByDate(string datum1,string datum2)
        //{
        //    //DateTime Datum1 = DateTime.Parse(datum1);
        //   // DateTime Datum2 = DateTime.Parse(datum2);



        //    return db.esp_KompanijeUpiti_GetByDate(null,null).ToList();
        //}

            //desktop
        [HttpGet]
        [Route("api/Upiti/GetByDate/{kompanijaID}/{datum}/{datum2}")]
        public List<KompanijaUpiti_Result> GetByDate(string kompanijaID,string datum, string datum2)
        {
            DateTime Datum = Convert.ToDateTime(datum);
            DateTime Datum2 = Convert.ToDateTime(datum2);

            List<KompanijaUpiti_Result> upiti= db.esp_KompanijeUpiti_GetByDate(Convert.ToInt32(kompanijaID),Datum,Datum2).ToList();

            return upiti;
        }


        //xamarin
        [HttpGet]
        [Route("api/Upiti/GetByDateAndKlijent/{klijentID}/{datum}/{datum2}")]
        public List<UpitiKlijentByDate_Result> GetByDateAndKlijent(string klijentID, string datum, string datum2)
        {
            DateTime Datum = Convert.ToDateTime(datum);
            DateTime Datum2 = Convert.ToDateTime(datum2);

            List<UpitiKlijentByDate_Result> upiti = db.esp_KlijentiUpiti_GetByDate(Convert.ToInt32(klijentID), Datum, Datum2).ToList();

            return upiti;
        }

        [HttpGet]
        [Route("api/Upiti/GetDetalji/{id}")]
        public IHttpActionResult GetDetalji(string id)
        {

            DetaljiUpita_Result upit = db.esp_Upiti_GetDetalji(Convert.ToInt32(id)).FirstOrDefault();

            return Ok(upit);
        }

        [HttpGet]
        [Route("api/Upiti/GetZadnjiUpit")]
        public IHttpActionResult GetZadnjiUpit()
        {
            Upiti upit = db.Upiti.OrderByDescending(p => p.Datum)
                       .FirstOrDefault();

            return Ok(upit);
        }

        [HttpGet]
        [Route("api/Upiti/GetPonudaID/{KompanijaID}/{UpitID}")]
        public IHttpActionResult GetPonudaID(string KompanijaID, string UpitID)
        {

            int? ponudaID = db.esp_Upiti_GetPonudaID(Convert.ToInt32(KompanijaID), Convert.ToInt32(UpitID)).FirstOrDefault();

            return Ok(ponudaID);
        }

        // PUT: api/Upiti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUpiti(int id, Upiti upiti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upiti.UpitID)
            {
                return BadRequest();
            }

            db.Entry(upiti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpitiExists(id))
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

        // POST: api/Upiti
        [ResponseType(typeof(Upiti))]
        public IHttpActionResult PostUpiti(Upiti upiti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Upiti.Add(upiti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = upiti.UpitID }, upiti);
        }

        // DELETE: api/Upiti/5
        [ResponseType(typeof(Upiti))]
        public IHttpActionResult DeleteUpiti(int id)
        {
            Upiti upiti = db.Upiti.Find(id);
            if (upiti == null)
            {
                return NotFound();
            }

            db.Upiti.Remove(upiti);
            db.SaveChanges();

            return Ok(upiti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UpitiExists(int id)
        {
            return db.Upiti.Count(e => e.UpitID == id) > 0;
        }
    }
}