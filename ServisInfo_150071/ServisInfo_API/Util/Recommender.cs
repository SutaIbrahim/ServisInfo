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

            foreach (var x in kompanijeDict)
            {
                foreach (var o in ocjenePosmatraneKompanije)
                {
                    if (x.Value.Where(i => i.KlijentID == o.KlijentID).Count() > 0)
                    {
                        zajedniceOcjene1.Add(o);
                        zajedniceOcjene2.Add(x.Value.Where(i => i.KlijentID == o.KlijentID).First());
                    }
                    //41:30 yt
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

            //cold start
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

            // select top 5
            int brojac = 0;
            foreach (var x in preporuceneKompanije)
            {
                filter.Add(x);

                brojac++;
                if (brojac > 4)
                    break;
            }


            //dodaj jednu kompaniju bez ocjene u listu
            Kompanije bezOcjene = db.esp_Recommender_ColdStart_PreporuciKompanijeBezOcjena(kompanijaID, kategorijaID).FirstOrDefault();
            filter.Add(db.esp_Kompanije_GetDetalji(bezOcjene.KompanijaID).First());

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