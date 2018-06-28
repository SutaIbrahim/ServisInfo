using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class ServisiKlijent_Result
    {
        public int ServisID { get; set; }
        public int PonudaID { get; set; }
        public int UpitID { get; set; }
        public int KlijentID { get; set; }
        public Nullable<decimal> Završna_cijena { get; set; }
        public System.DateTime DatumPrihvatanja { get; set; }
        public Nullable<System.DateTime> DatumPocetka { get; set; }
        public Nullable<System.DateTime> DatumZavršetka { get; set; }
        public string Naziv_kompanije { get; set; }
        public string DatumPrihvatanjaS { get; set; }
        public string DatumPocetkaS { get; set; }
        public string DatumZavrsetkaS { get; set; }



    }
}
