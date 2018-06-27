using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class Ponuda
    {
        public int PonudaID { get; set; }
        public System.DateTime DatumKreiranja { get; set; }
        public string Odgovor { get; set; }
        public string Cijena { get; set; }
        public System.DateTime DatumNajranijegMogucegPrijema { get; set; }
        public decimal TrajanjeDani { get; set; }
        public decimal TrajanjeSati { get; set; }
        public bool Prihvacena { get; set; }
        public int KompanijaID { get; set; }
        public int KlijentID { get; set; }
        public int UpitID { get; set; }

    }
}
