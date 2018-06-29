using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
  public  class DetaljiUpita_Result
    {
        public int UpitID { get; set; }
        public int KlijentID { get; set; }
        public int KompanijaUpitID { get; set; }
        public Nullable<System.DateTime> Datum_upita { get; set; }
        public string Marka_uredjaja { get; set; }
        public string Model_uredjaja { get; set; }
        public string Opis_kvara { get; set; }
        public byte[] Slika { get; set; }
        public Nullable<System.DateTime> ZeljeniDatumPrijemaOd { get; set; }
        public Nullable<System.DateTime> ZeljeniDatumPrijemaDo { get; set; }
        public string NazivKlijenta { get; set; }
        public bool Odgovoreno { get; set; }
        public string Naziv_kategorije { get; set; }

    }
}
