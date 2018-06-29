using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class PonudeByDate_Result
    {
        public int PonudaID { get; set; }
        public System.DateTime DatumKreiranja { get; set; }
        public string Cijena { get; set; }
        public bool Prihvacena { get; set; }
        public int UpitID { get; set; }
        public int KlijentID { get; set; }
        public string Klijent_ime_i_prezime { get; set; }
        public Nullable<int> KategorijaID { get; set; }
        public string Naziv_kategorije { get; set; }
        public string Naziv_kompanije { get; set; }
        public decimal TrajanjeDani { get; set; }
        public decimal TrajanjeSati { get; set; }

        public string DatumKreiranjaS { get; set; }

    }
}
