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
    
    public partial class KompanijaPrometByDate_Report
    {
        public int ServisID { get; set; }
        public Nullable<System.DateTime> DatumZavršetka { get; set; }
        public string Naziv_kompanije { get; set; }
        public Nullable<decimal> Cijena { get; set; }
        public string Ime_i_prezime_klijenta { get; set; }
        public Nullable<System.DateTime> Od { get; set; }
        public Nullable<System.DateTime> Do { get; set; }
    }
}
