using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
    public class UpitiKlijentByDate_Result
    {
        public int UpitID { get; set; }
        public Nullable<int> KategorijaID { get; set; }
        public int KlijentID { get; set; }
        public Nullable<System.DateTime> Datum_upita { get; set; }
        public string Marka_uredjaja { get; set; }
        public Nullable<System.DateTime> Zeljeni_datum_prijema_Od { get; set; }
        public Nullable<System.DateTime> Zeljeni_datum_prijema_Do { get; set; }
        public string Naziv_klijenta { get; set; }
        public bool Odgovoreno { get; set; }
        public string Naziv_kategorije { get; set; }
        public string DatumUpitaS { get; set; }
        public string OdgovorenoS { get; set; }



    }
}
