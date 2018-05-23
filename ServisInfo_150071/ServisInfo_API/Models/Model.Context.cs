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
    }
}
