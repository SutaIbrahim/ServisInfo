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
    
    public partial class PonudaDetalji_Result
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
        public string Naziv_kompanije { get; set; }
        public int UpitID { get; set; }
        public int KlijentID { get; set; }
        public string Klijent_ime_i_prezime { get; set; }
        public Nullable<int> KategorijaID { get; set; }
        public string Naziv { get; set; }
    }
}
