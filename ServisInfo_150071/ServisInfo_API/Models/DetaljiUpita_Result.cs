//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServisInfo_API.Models
{
    using System;
    
    public partial class DetaljiUpita_Result
    {
        public int UpitID { get; set; }
        public int KlijentID { get; set; }
        public Nullable<System.DateTime> Datum_upita { get; set; }
        public string Marka_uredjaja { get; set; }
        public string Model_uredjaja { get; set; }
        public string Opis_kvara { get; set; }
        public byte[] Slika { get; set; }
        public Nullable<System.DateTime> ZeljeniDatumPrijemaOd { get; set; }
        public Nullable<System.DateTime> ZeljeniDatumPrijemaDo { get; set; }
        public string NazivKlijenta { get; set; }
        public Nullable<bool> Odgovoreno { get; set; }
        public string Naziv_kategorije { get; set; }
        public Nullable<int> KompanijaUpitID { get; set; }
        public Nullable<int> KategorijaID { get; set; }
    }
}
