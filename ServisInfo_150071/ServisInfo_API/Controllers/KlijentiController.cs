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
    public class KlijentiController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Klijenti
        public IQueryable<Klijenti> GetKlijenti()
        {
            return db.Klijenti;
        }

        // GET: api/Klijenti/5
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult GetKlijenti(int id)
        {
            Klijenti klijenti = db.Klijenti.Find(id);
            if (klijenti == null)
            {
                return NotFound();
            }

            return Ok(klijenti);
        }

        [ResponseType(typeof(Klijenti))]
        [Route("api/Klijenti/GetByUsername/{username}")]
        public IHttpActionResult GetByUsername(string username)
        {
            Klijenti k = db.Klijenti.Where(x => x.KorisickoIme == username).FirstOrDefault();

            if (k == null)
            {
                return NotFound();
            }

            return Ok(k);
        }


        [Route("api/Klijenti/SearchByNaziv/{naziv?}")]
        [HttpGet]
        public IHttpActionResult SearchByNaziv(string naziv = "")
        {

            List<Klijenti> klijenti = db.Klijenti.Where(x => naziv == "" || (x.Prezime + " " + x.Ime).Contains(naziv) || x.KorisickoIme.Contains(naziv)).ToList();

            return Ok(klijenti);
        }


        // PUT: api/Klijenti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlijenti(int id, Klijenti klijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klijenti.KlijentID)
            {
                return BadRequest();
            }

            db.esp_KlijentUpdate(klijenti.KlijentID, klijenti.Ime, klijenti.Prezime, klijenti.Adresa, klijenti.Telefon, klijenti.Email,klijenti.GradID, klijenti.KorisickoIme, klijenti.LozinkaSalt, klijenti.LozinkaHash);

            //db.Entry(klijenti).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!KlijentiExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Klijenti
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult PostKlijenti(Klijenti klijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klijenti.Add(klijenti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = klijenti.KlijentID }, klijenti);
        }

        // DELETE: api/Klijenti/5
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult DeleteKlijenti(int id)
        {
            Klijenti klijenti = db.Klijenti.Find(id);
            if (klijenti == null)
            {
                return NotFound();
            }

            try
            {

       
                List<Ponude> ponude = db.Ponude.Where(p => p.KlijentID == id).ToList();
                List<Ocjene> ocjene = db.Ocjene.Where(p => p.KlijentID == id).ToList();
                foreach (var x in ocjene)
                {
                    var o = db.Ocjene.Where(p => p.OcjenaID == x.OcjenaID).FirstOrDefault();
                    db.Ocjene.Remove(o);
                }
                foreach (var x in ponude)
            {
                var servis = db.Servisi.Where(p => p.PonudaID == x.PonudaID).FirstOrDefault();
                    if (servis != null)
                        db.Servisi.Remove(servis);
            }
            foreach (var x in ponude)
            {
                var pa = db.Ponude.Where(p => p.PonudaID == x.PonudaID).FirstOrDefault();
                db.Ponude.Remove(pa);
            }
            List<Upiti> upiti = db.Upiti.Where(p => p.KlijentID == id).ToList();


                foreach (var x in upiti)
                {
                   var kUpuitu = db.KompanijeUpiti.Where(p => p.UpitID == x.UpitID).ToList();

                    foreach (var y in kUpuitu)
                    {
                        db.KompanijeUpiti.Remove(y);
                    }
                }

                foreach (var x in upiti)
            {
                var u = db.Upiti.Where(p => p.UpitID == x.UpitID).FirstOrDefault();
                db.Upiti.Remove(u);
            }
            db.Klijenti.Remove(klijenti);
            db.SaveChanges();
            }
            catch (ArgumentException e)
            {

            }

            return Ok(klijenti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlijentiExists(int id)
        {
            return db.Klijenti.Count(e => e.KlijentID == id) > 0;
        }
    }
}