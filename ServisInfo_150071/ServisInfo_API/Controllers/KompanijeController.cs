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
    public class KompanijeController : ApiController
    {
        private ServisInfoEntities db = new ServisInfoEntities();

        // GET: api/Kompanije
        public IQueryable<Kompanije> GetKompanije()
        {
            return db.Kompanije;
        }

        // GET: api/Kompanije/5
        [ResponseType(typeof(Kompanije))]
        public IHttpActionResult GetKompanije(int id)
        {
            Kompanije kompanije = db.Kompanije.Find(id);
            if (kompanije == null)
            {
                return NotFound();
            }

            return Ok(kompanije);
        }

        [ResponseType(typeof(Kompanije))]
        [Route("api/Kompanije/GetByKorisnickoIme/{korisnickoIme}")]
        public IHttpActionResult GetByKorisnickoIme(string korisnickoIme)
        {
            Kompanije kompanija = db.esp_Kompanije_GetByKorisnickoIme(korisnickoIme).FirstOrDefault();

            if (kompanija == null)
            {
                return NotFound();
            }

            return Ok(kompanija);
        }


        [Route("api/Kompanije/SearchByNaziv/{naziv?}")]
        [HttpGet]
        public IHttpActionResult SearchByNaziv(string naziv = "")
        {

            List<Kompanije_Result> kompanije = db.esp_Kompanije_SearchByNaziv(naziv).ToList();

            return Ok(kompanije);
        }







        // PUT: api/Kompanije/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKompanije(int id, Kompanije k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != k.KompanijaID)
            {
                return BadRequest();
            }

            db.esp_KompanijeUpdate(id, k.Naziv, k.Adresa, k.Email, k.Telefon, k.KorisickoIme, k.LozinkaSalt, k.LozinkaHash);

            if (k.kategorije != null)
            {

                List<KompanijeKategorije> Kategorije = db.KompanijeKategorije.Where(y => y.KompanijaID == k.KompanijaID).ToList(); //trenutne kategorije

                List<int> trenutneKategorije = new List<int>();
                // dodavanje ID trenutnih kategorija
                foreach (var i in Kategorije)
                {
                    trenutneKategorije.Add(i.KategorijaID);
                }

                List<int> isteKategorije = new List<int>();
                // dodavanje ID istih kategorija
                foreach (var ku in Kategorije)
                {
                    foreach (var u in k.kategorije)
                    {
                        if (ku.KategorijaID == u.KategorijaID)
                        {
                            isteKategorije.Add(ku.KategorijaID);
                        }
                    }
                }

                foreach (var u in k.kategorije)
                {
                    if (isteKategorije.Contains(u.KategorijaID))
                    {
                    }
                    else
                    {
                        db.esp_KompanijeKategorije_Insert(k.KompanijaID, u.KategorijaID);
                        isteKategorije.Add(u.KategorijaID); // dodavanje ID -a kako bi kasnije provjerili koje uloge treba brisati
                    }
                }

                //brisanje neoznacenih uloga
                foreach (var x in trenutneKategorije)
                {
                    if (isteKategorije.Contains(x))
                    {
                    }
                    else
                    {
                        KompanijeKategorije zaBrisanje = db.KompanijeKategorije.Where(y => y.KompanijaID == k.KompanijaID && y.KategorijaID == x).FirstOrDefault();
                        db.KompanijeKategorije.Remove(zaBrisanje);
                        db.SaveChanges();
                    }
                }
            }


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kompanije
        [ResponseType(typeof(Kompanije))]
        public IHttpActionResult PostKompanije(Kompanije kompanije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kompanije.Add(kompanije);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kompanije.KompanijaID }, kompanije);
        }

        // DELETE: api/Kompanije/5
        [ResponseType(typeof(Kompanije))]
        public IHttpActionResult DeleteKompanije(int id)
        {
            Kompanije kompanije = db.Kompanije.Find(id);
            if (kompanije == null)
            {
                return NotFound();
            }

            db.Kompanije.Remove(kompanije);
            db.SaveChanges();

            return Ok(kompanije);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KompanijeExists(int id)
        {
            return db.Kompanije.Count(e => e.KompanijaID == id) > 0;
        }
    }
}