﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ServisInfoEntities : DbContext
    {
        public ServisInfoEntities()
            : base("name=ServisInfoEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Kategorije> Kategorije { get; set; }
        public virtual DbSet<Klijenti> Klijenti { get; set; }
        public virtual DbSet<Kompanije> Kompanije { get; set; }
        public virtual DbSet<KompanijeKategorije> KompanijeKategorije { get; set; }
        public virtual DbSet<KompanijeUpiti> KompanijeUpiti { get; set; }
        public virtual DbSet<MarkeUredjaja> MarkeUredjaja { get; set; }
        public virtual DbSet<ModeliUredjaja> ModeliUredjaja { get; set; }
        public virtual DbSet<Ocjene> Ocjene { get; set; }
        public virtual DbSet<Ponude> Ponude { get; set; }
        public virtual DbSet<Servisi> Servisi { get; set; }
        public virtual DbSet<Upiti> Upiti { get; set; }
        public virtual DbSet<VrsteOcjena> VrsteOcjena { get; set; }
    
        public virtual ObjectResult<Kompanije> esp_Kompanije_GetByKorisnickoIme(string korisnickoIme)
        {
            var korisnickoImeParameter = korisnickoIme != null ?
                new ObjectParameter("KorisnickoIme", korisnickoIme) :
                new ObjectParameter("KorisnickoIme", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Kompanije>("esp_Kompanije_GetByKorisnickoIme", korisnickoImeParameter);
        }
    
        public virtual ObjectResult<Kompanije> esp_Kompanije_GetByKorisnickoIme(string korisnickoIme, MergeOption mergeOption)
        {
            var korisnickoImeParameter = korisnickoIme != null ?
                new ObjectParameter("KorisnickoIme", korisnickoIme) :
                new ObjectParameter("KorisnickoIme", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Kompanije>("esp_Kompanije_GetByKorisnickoIme", mergeOption, korisnickoImeParameter);
        }
    
        public virtual ObjectResult<KompanijaUpiti_Result> esp_KompanijeUpiti_GetByDate(Nullable<int> kompanijaID, Nullable<System.DateTime> datum1, Nullable<System.DateTime> datum2)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            var datum1Parameter = datum1.HasValue ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(System.DateTime));
    
            var datum2Parameter = datum2.HasValue ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KompanijaUpiti_Result>("esp_KompanijeUpiti_GetByDate", kompanijaIDParameter, datum1Parameter, datum2Parameter);
        }
    
        public virtual ObjectResult<DetaljiUpita_Result> esp_Upiti_GetDetalji(Nullable<int> upitID)
        {
            var upitIDParameter = upitID.HasValue ?
                new ObjectParameter("UpitID", upitID) :
                new ObjectParameter("UpitID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetaljiUpita_Result>("esp_Upiti_GetDetalji", upitIDParameter);
        }
    
        public virtual ObjectResult<Kompanije_Result> esp_Kompanije_SearchByNaziv(string naziv)
        {
            var nazivParameter = naziv != null ?
                new ObjectParameter("Naziv", naziv) :
                new ObjectParameter("Naziv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Kompanije_Result>("esp_Kompanije_SearchByNaziv", nazivParameter);
        }
    
        public virtual ObjectResult<KompanijaPonude_Result> esp_KompanijePonude_GetByDate(Nullable<int> kompanijaID, Nullable<System.DateTime> datum1, Nullable<System.DateTime> datum2)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            var datum1Parameter = datum1.HasValue ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(System.DateTime));
    
            var datum2Parameter = datum2.HasValue ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KompanijaPonude_Result>("esp_KompanijePonude_GetByDate", kompanijaIDParameter, datum1Parameter, datum2Parameter);
        }
    
        public virtual ObjectResult<PonudaDetalji_Result> edp_Ponude_DetaljiByID(Nullable<int> ponudaID)
        {
            var ponudaIDParameter = ponudaID.HasValue ?
                new ObjectParameter("PonudaID", ponudaID) :
                new ObjectParameter("PonudaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PonudaDetalji_Result>("edp_Ponude_DetaljiByID", ponudaIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> esp_Upiti_GetPonudaID(Nullable<int> kompanijaID, Nullable<int> upitID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            var upitIDParameter = upitID.HasValue ?
                new ObjectParameter("UpitID", upitID) :
                new ObjectParameter("UpitID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("esp_Upiti_GetPonudaID", kompanijaIDParameter, upitIDParameter);
        }
    
        public virtual ObjectResult<KompanijaServisi_Result> esp_KompanijeServisi_GetByDate(Nullable<int> kompanijaID, Nullable<System.DateTime> datum1, Nullable<System.DateTime> datum2, string status)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            var datum1Parameter = datum1.HasValue ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(System.DateTime));
    
            var datum2Parameter = datum2.HasValue ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KompanijaServisi_Result>("esp_KompanijeServisi_GetByDate", kompanijaIDParameter, datum1Parameter, datum2Parameter, statusParameter);
        }
    
        public virtual ObjectResult<ServisDetalji_Result> esp_Servisi_DetaljiByID(Nullable<int> servisID)
        {
            var servisIDParameter = servisID.HasValue ?
                new ObjectParameter("ServisID", servisID) :
                new ObjectParameter("ServisID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ServisDetalji_Result>("esp_Servisi_DetaljiByID", servisIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> esp_NeodgovoreniUpiti(Nullable<int> kompanijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("esp_NeodgovoreniUpiti", kompanijaIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> esp_ServisiUTokuCount(Nullable<int> kompanijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("esp_ServisiUTokuCount", kompanijaIDParameter);
        }
    
        public virtual ObjectResult<string> esp_GetKategorijeByKompanijaID(Nullable<int> kompanijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("esp_GetKategorijeByKompanijaID", kompanijaIDParameter);
        }
    
        public virtual int esp_KompanijeUpdate(Nullable<int> kompanijaID, string naziv, string adresa, string email, string telefon, string korisnickoIme, string lozinkaSalt, string lozinkaHash)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            var nazivParameter = naziv != null ?
                new ObjectParameter("Naziv", naziv) :
                new ObjectParameter("Naziv", typeof(string));
    
            var adresaParameter = adresa != null ?
                new ObjectParameter("Adresa", adresa) :
                new ObjectParameter("Adresa", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var telefonParameter = telefon != null ?
                new ObjectParameter("Telefon", telefon) :
                new ObjectParameter("Telefon", typeof(string));
    
            var korisnickoImeParameter = korisnickoIme != null ?
                new ObjectParameter("KorisnickoIme", korisnickoIme) :
                new ObjectParameter("KorisnickoIme", typeof(string));
    
            var lozinkaSaltParameter = lozinkaSalt != null ?
                new ObjectParameter("LozinkaSalt", lozinkaSalt) :
                new ObjectParameter("LozinkaSalt", typeof(string));
    
            var lozinkaHashParameter = lozinkaHash != null ?
                new ObjectParameter("LozinkaHash", lozinkaHash) :
                new ObjectParameter("LozinkaHash", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("esp_KompanijeUpdate", kompanijaIDParameter, nazivParameter, adresaParameter, emailParameter, telefonParameter, korisnickoImeParameter, lozinkaSaltParameter, lozinkaHashParameter);
        }
    
        public virtual int esp_KompanijeKategorije_Insert(Nullable<int> kompanijaID, Nullable<int> kategorijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            var kategorijaIDParameter = kategorijaID.HasValue ?
                new ObjectParameter("KategorijaID", kategorijaID) :
                new ObjectParameter("KategorijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("esp_KompanijeKategorije_Insert", kompanijaIDParameter, kategorijaIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> esp_GetServisIDbyPonudaID(Nullable<int> ponudaID)
        {
            var ponudaIDParameter = ponudaID.HasValue ?
                new ObjectParameter("PonudaID", ponudaID) :
                new ObjectParameter("PonudaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("esp_GetServisIDbyPonudaID", ponudaIDParameter);
        }
    
        public virtual ObjectResult<KompanijeDetalji_X_Result> esp_SearchByKategorijaGrad(Nullable<int> kategorijaId, Nullable<int> gradId)
        {
            var kategorijaIdParameter = kategorijaId.HasValue ?
                new ObjectParameter("kategorijaId", kategorijaId) :
                new ObjectParameter("kategorijaId", typeof(int));
    
            var gradIdParameter = gradId.HasValue ?
                new ObjectParameter("gradId", gradId) :
                new ObjectParameter("gradId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KompanijeDetalji_X_Result>("esp_SearchByKategorijaGrad", kategorijaIdParameter, gradIdParameter);
        }
    
        public virtual ObjectResult<PonudeKlijent_Result> esp_GetPonudeByKlijentID(Nullable<int> klijentID)
        {
            var klijentIDParameter = klijentID.HasValue ?
                new ObjectParameter("klijentID", klijentID) :
                new ObjectParameter("klijentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PonudeKlijent_Result>("esp_GetPonudeByKlijentID", klijentIDParameter);
        }
    
        public virtual ObjectResult<ServisiKlijent_Result> esp_KlijentiServisi_GetByDate(Nullable<int> klijentID, Nullable<System.DateTime> datum1, Nullable<System.DateTime> datum2, string status)
        {
            var klijentIDParameter = klijentID.HasValue ?
                new ObjectParameter("KlijentID", klijentID) :
                new ObjectParameter("KlijentID", typeof(int));
    
            var datum1Parameter = datum1.HasValue ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(System.DateTime));
    
            var datum2Parameter = datum2.HasValue ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ServisiKlijent_Result>("esp_KlijentiServisi_GetByDate", klijentIDParameter, datum1Parameter, datum2Parameter, statusParameter);
        }
    
        public virtual ObjectResult<PonudeByDate_Result> esp_KlijentPonude_GetByDate(Nullable<int> klijentID, Nullable<System.DateTime> datum1, Nullable<System.DateTime> datum2)
        {
            var klijentIDParameter = klijentID.HasValue ?
                new ObjectParameter("KlijentID", klijentID) :
                new ObjectParameter("KlijentID", typeof(int));
    
            var datum1Parameter = datum1.HasValue ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(System.DateTime));
    
            var datum2Parameter = datum2.HasValue ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PonudeByDate_Result>("esp_KlijentPonude_GetByDate", klijentIDParameter, datum1Parameter, datum2Parameter);
        }
    
        public virtual ObjectResult<UpitiKlijentByDate_Result> esp_KlijentiUpiti_GetByDate(Nullable<int> klijetID, Nullable<System.DateTime> datum1, Nullable<System.DateTime> datum2)
        {
            var klijetIDParameter = klijetID.HasValue ?
                new ObjectParameter("KlijetID", klijetID) :
                new ObjectParameter("KlijetID", typeof(int));
    
            var datum1Parameter = datum1.HasValue ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(System.DateTime));
    
            var datum2Parameter = datum2.HasValue ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpitiKlijentByDate_Result>("esp_KlijentiUpiti_GetByDate", klijetIDParameter, datum1Parameter, datum2Parameter);
        }
    
        public virtual ObjectResult<KompanijeDetalji_Result> esp_Kompanije_GetDetalji(Nullable<int> kompanijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("KompanijaID", kompanijaID) :
                new ObjectParameter("KompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KompanijeDetalji_Result>("esp_Kompanije_GetDetalji", kompanijaIDParameter);
        }
    
        public virtual ObjectResult<Ocjene> esp_Ocjene_GetByKompanijaID(Nullable<int> kompanijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("kompanijaID", kompanijaID) :
                new ObjectParameter("kompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Ocjene>("esp_Ocjene_GetByKompanijaID", kompanijaIDParameter);
        }
    
        public virtual ObjectResult<Ocjene> esp_Ocjene_GetByKompanijaID(Nullable<int> kompanijaID, MergeOption mergeOption)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("kompanijaID", kompanijaID) :
                new ObjectParameter("kompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Ocjene>("esp_Ocjene_GetByKompanijaID", mergeOption, kompanijaIDParameter);
        }
    
        public virtual int esp_getOcjeneKompanija(Nullable<int> kompanijaID)
        {
            var kompanijaIDParameter = kompanijaID.HasValue ?
                new ObjectParameter("kompanijaID", kompanijaID) :
                new ObjectParameter("kompanijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("esp_getOcjeneKompanija", kompanijaIDParameter);
        }
    }
}
