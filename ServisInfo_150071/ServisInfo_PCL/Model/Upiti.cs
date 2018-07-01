using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class Upiti
    {
        public int UpitID { get; set; }
        public string MarkaUredjaja { get; set; }
        public string ModelUredjaja { get; set; }
        public string OpisKvara { get; set; }
        public byte[] Slika { get; set; }
        public Nullable<System.DateTime> ZeljeniDatumPrijemaOd { get; set; }
        public Nullable<System.DateTime> ZeljeniDatumPrijemaDo { get; set; }
        public int KlijentID { get; set; }
        public int ModelUredjajaID { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<int> KategorijaID { get; set; }
    }
}
