using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class ServisDetalji_Result
    {
        public int ServisID { get; set; }
        public int PonudaID { get; set; }
        public int UpitID { get; set; }
        public int KlijentID { get; set; }
        public string Ime_klijenta { get; set; }
        public Nullable<decimal> Završna_cijena { get; set; }
        public System.DateTime DatumPrihvatanja { get; set; }
        public Nullable<System.DateTime> DatumPocetka { get; set; }
        public Nullable<System.DateTime> DatumZavršetka { get; set; }
        public Nullable<decimal> Cijena { get; set; }
        public Nullable<int> TrajanjeDani { get; set; }
        public Nullable<int> KategorijaID { get; set; }
        public string Kategorija { get; set; }
        public string Naziv_Kompanije { get; set; }
        public Nullable<bool> Ocjenjen { get; set; }


    }
}
