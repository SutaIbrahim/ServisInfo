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

        public List<Kompanije_Result> GetSlicneKompanije(int kompanijaID)
        {
            UcitajKompanije(kompanijaID);
            List<Ocjene>  ocjenePosmatraneKompanije= db.esp_Ocjene_GetByKompanijaID(kompanijaID).ToList();

            List<Ocjene> zajedniceOcjene1 = new List<Ocjene>();
            List<Ocjene> zajedniceOcjene2 = new List<Ocjene>();
            List<Kompanije_Result> preporuceneKompanije = new List<Kompanije_Result>();

            foreach(var x in kompanijeDict)
            {
                foreach(var o in ocjenePosmatraneKompanije)
                {
                    if(x.Value.Where(i=>i.KlijentID == o.KlijentID).Count() > 0)
                    {
                        zajedniceOcjene1.Add(o);
                        zajedniceOcjene2.Add(x.Value.Where(i => i.KlijentID == o.KlijentID).First());
                    }
                    //41:30 yt
                }
            }





        }


        private void UcitajKompanije(int kompanijaID)
        {
            List<Kompanije> kompanije = db.Kompanije.Where(x => x.KompanijaID != kompanijaID).ToList();
            List<Ocjene> ocjene = new List<Ocjene>();

            foreach(var x in kompanije) {

                ocjene = db.esp_Ocjene_GetByKompanijaID(x.KompanijaID).ToList();
                if (ocjene.Count > 0)
                {
                    kompanijeDict.Add(x.KompanijaID, ocjene);
                }
            }
        }



    }
}