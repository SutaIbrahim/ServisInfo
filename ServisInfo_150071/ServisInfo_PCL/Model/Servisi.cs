using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
    public class Servisi
    {
        public int ServisID { get; set; }
        public System.DateTime DatumPrihvatanja { get; set; }
        public Nullable<System.DateTime> DatumPocetka { get; set; }
        public Nullable<System.DateTime> DatumZavršetka { get; set; }
        public Nullable<decimal> Cijena { get; set; }
        public Nullable<int> TrajanjeDani { get; set; }
        public int KompanijaID { get; set; }
        public int PonudaID { get; set; }
    }
}
