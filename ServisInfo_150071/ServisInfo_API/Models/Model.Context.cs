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
    
        public virtual ObjectResult<KompanijeUpiti_Result> esp_KompanijeUpiti_GetByDate(string datum1, string datum2)
        {
            var datum1Parameter = datum1 != null ?
                new ObjectParameter("Datum1", datum1) :
                new ObjectParameter("Datum1", typeof(string));
    
            var datum2Parameter = datum2 != null ?
                new ObjectParameter("Datum2", datum2) :
                new ObjectParameter("Datum2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KompanijeUpiti_Result>("esp_KompanijeUpiti_GetByDate", datum1Parameter, datum2Parameter);
        }
    }
}
