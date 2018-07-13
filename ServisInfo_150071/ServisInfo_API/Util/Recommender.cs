using ServisInfo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServisInfo_API.Util
{
    public class Recommender
    {
        private ServisInfoEntities db = new ServisInfoEntities();
        private Dictionary<int, List<Ocjene>> kompanijeDict = new Dictionary<int, List<Ocjene>>();

        public List<KompanijeDetalji_Result> GetSlicneKompanije(int kompanijaID, int kategorijaID)
        {
            UcitajKompanije(kompanijaID, kategorijaID);
            List<Ocjene> ocjenePosmatraneKompanije = db.esp_Ocjene_GetByKompanijaID(kompanijaID).ToList();

            List<Ocjene> zajedniceOcjene1 = new List<Ocjene>();
            List<Ocjene> zajedniceOcjene2 = new List<Ocjene>();
            List<KompanijeDetalji_Result> preporuceneKompanije = new List<KompanijeDetalji_Result>();


            //preporuci slicne kompanije
            foreach (var x in kompanijeDict)
            {
                foreach (var o in ocjenePosmatraneKompanije)
                {
                    if (x.Value.Where(i => i.KlijentID == o.KlijentID).Count() > 0)
                    {
                        zajedniceOcjene1.Add(o);
                        zajedniceOcjene2.Add(x.Value.Where(i => i.KlijentID == o.KlijentID).First());
                    }
                }
                double slicnost = GetSlicnost(zajedniceOcjene1, zajedniceOcjene2);
                if (slicnost > 0.85)
                {
                    preporuceneKompanije.Add(db.esp_Kompanije_GetDetalji(x.Key).First());
                }
                zajedniceOcjene1.Clear();
                zajedniceOcjene2.Clear();
            }


            if (preporuceneKompanije.Count() != 0)
            {
                //sortiranje
                preporuceneKompanije = preporuceneKompanije.OrderByDescending(p => p.ProsjecnaOcjena).ToList();

            }

            //cold start, ukoliko klijent jos nije ocijenio nijednu kompaniju -
            //dodaj top 5 sa najvecom prosjecnom ocjenom
            else
            {
                List<Kompanije> CS = new List<Kompanije>();

                CS = db.esp_Recommender_ColdStart(kompanijaID, kategorijaID).ToList();
                foreach (var x in CS)
                {
                    preporuceneKompanije.Add(db.esp_Kompanije_GetDetalji(x.KompanijaID).First());
                }

                //sortiranje
                preporuceneKompanije = preporuceneKompanije.OrderByDescending(p => p.ProsjecnaOcjena).ToList();

            }

            List<KompanijeDetalji_Result> filter = new List<KompanijeDetalji_Result>();

            //filtriraj prvih 5 i dodaj jednu kompaniju bez ocjene
            if (preporuceneKompanije.Count > 5)
            {
                // select top 5
                foreach (var x in preporuceneKompanije)
                {
                    filter.Add(x);

                    if (filter.Count>=5)
                        break;
                }

                //dodaj jednu kompaniju bez ocjene u listu -- 6. stavka
                Kompanije bezOcjene = db.esp_Recommender_ColdStart_PreporuciKompanijeBezOcjena(kompanijaID, kategorijaID).FirstOrDefault();
                if (bezOcjene != null) // ako ne postoji kompanija bez ocjene
                {
                    filter.Add(db.esp_Kompanije_GetDetalji(bezOcjene.KompanijaID).First());
                }
            }
            else
            {
                // ukoliko nema toliko zajednickih kompanija i mal je broj ocjenjenih kompanija(cold start,pocetak rada aplikacije) popuni listu sa random kompanijama
                foreach(var x in preporuceneKompanije)
                {
                    filter.Add(x);
                }

                int brojac = 0;
                int loopStop = 0;

                while (filter.Count < 6 && loopStop<100)
                {
                    //popuni listu random kompanijama bez ocjena
                    Kompanije bezOcjene = db.esp_Recommender_ColdStart_PreporuciKompanijeBezOcjena(kompanijaID, kategorijaID).FirstOrDefault();
                    KompanijeDetalji_Result kd = db.esp_Kompanije_GetDetalji(bezOcjene.KompanijaID).First();

                    bool postoji = false;
                    foreach(var x in filter.ToList())
                    {
                        postoji = false;
                        if (kd.KompanijaID == x.KompanijaID)// ukoliko vec postoji kompanija u listi, nemoj je dodavati
                        {
                            brojac--;
                            postoji = true;
                        }
                    }

                    if (postoji == false)
                    {
                        filter.Add(db.esp_Kompanije_GetDetalji(bezOcjene.KompanijaID).First());
                    }

                    brojac++;
                    loopStop++; // zaustavi beskonacnu petlju ako vise nema kompanija na listi, lista preporucenih kompanija ce biti manja od 6
                }

            }

            return filter;

        }

        private double GetSlicnost(List<Ocjene> zajedniceOcjene1, List<Ocjene> zajedniceOcjene2)
        {
            if (zajedniceOcjene1.Count != zajedniceOcjene2.Count)
            {
                return 0;
            }

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajedniceOcjene1.Count; i++)
            {
                brojnik += Convert.ToDouble(zajedniceOcjene1[i].Ocjena * zajedniceOcjene2[i].Ocjena);
                nazivnik1 += Convert.ToDouble(zajedniceOcjene1[i].Ocjena * zajedniceOcjene1[i].Ocjena);
                nazivnik2 += Convert.ToDouble(zajedniceOcjene2[i].Ocjena * zajedniceOcjene2[i].Ocjena);
            }

            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);

            double nazivnik = nazivnik1 * nazivnik2;

            if (nazivnik == 0)
            {
                return 0;
            }

            return brojnik / nazivnik;
        }

        private void UcitajKompanije(int kompanijaID, int kategorijaID)
        {
            List<Kompanije> kompanije = db.esp_Recommender_GetKompanijeByKategorijaID(kompanijaID, kategorijaID).ToList();
            List<Ocjene> ocjene = new List<Ocjene>();

            foreach (var x in kompanije)
            {
                ocjene = db.esp_Ocjene_GetByKompanijaID(x.KompanijaID).ToList();
                if (ocjene.Count > 0)
                {
                    kompanijeDict.Add(x.KompanijaID, ocjene);
                }
            }
        }


    }
}