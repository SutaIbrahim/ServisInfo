﻿using System;
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
    public class KompanijeUpitiController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/KompanijeUpiti
        public IQueryable<KompanijeUpiti> GetKompanijeUpiti()
        {
            return db.KompanijeUpiti;
        }

        // GET: api/KompanijeUpiti/5
        [ResponseType(typeof(KompanijeUpiti))]
        public IHttpActionResult GetKompanijeUpiti(int id)
        {
            KompanijeUpiti kompanijeUpiti = db.KompanijeUpiti.Find(id);
            if (kompanijeUpiti == null)
            {
                return NotFound();
            }

            return Ok(kompanijeUpiti);
        }
        [HttpGet]
        [Route("api/KompanijeUpiti/GetUpitiSvi/{kompanijaID}")]
        public IHttpActionResult GetUpitiSvi(int kompanijaId)
        {
            int broj = db.KompanijeUpiti.Where(x => x.KompanijaID == kompanijaId).Count();
            return Ok(broj);
        }
        [HttpGet]
        [Route("api/KompanijeUpiti/GetCountNeodgovoreni/{kompanijaID}")]
        public int? GetByDate(string kompanijaID)
        {
            return db.esp_NeodgovoreniUpiti(Convert.ToInt32(kompanijaID)).FirstOrDefault();
        }
        [HttpGet]
        [Route("api/KompanijeUpiti/GetKU/{upitID}")]
        public List<KompanijeUpiti> GetKU(string upitID)
        {
            int id = Convert.ToInt32(upitID);

            return db.KompanijeUpiti.Where(x => x.UpitID == id).ToList();
        }


        // PUT: api/KompanijeUpiti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKompanijeUpiti(int id, KompanijeUpiti kompanijeUpiti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kompanijeUpiti.KompanijaUpitID)
            {
                return BadRequest();
            }

            db.Entry(kompanijeUpiti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KompanijeUpitiExists(id))
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

        // POST: api/KompanijeUpiti
        [ResponseType(typeof(KompanijeUpiti))]
        public IHttpActionResult PostKompanijeUpiti(KompanijeUpiti kompanijeUpiti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KompanijeUpiti.Add(kompanijeUpiti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kompanijeUpiti.KompanijaUpitID }, kompanijeUpiti);
        }

        // DELETE: api/KompanijeUpiti/5
        [ResponseType(typeof(KompanijeUpiti))]
        public IHttpActionResult DeleteKompanijeUpiti(int id)
        {
            KompanijeUpiti kompanijeUpiti = db.KompanijeUpiti.Find(id);
            if (kompanijeUpiti == null)
            {
                return NotFound();
            }

            db.KompanijeUpiti.Remove(kompanijeUpiti);
            db.SaveChanges();

            return Ok(kompanijeUpiti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KompanijeUpitiExists(int id)
        {
            return db.KompanijeUpiti.Count(e => e.KompanijaUpitID == id) > 0;
        }
    }
}