﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TravelScannerEntities : DbContext
    {
        public TravelScannerEntities()
            : base("name=TravelScannerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Araba> Araba { get; set; }
        public DbSet<Firmalar> Firmalar { get; set; }
        public DbSet<HavaDurumu> HavaDurumu { get; set; }
        public DbSet<Otel> Otel { get; set; }
        public DbSet<Resim> Resim { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Ucus> Ucus { get; set; }
        public DbSet<Yonetici> Yonetici { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
    }
}
