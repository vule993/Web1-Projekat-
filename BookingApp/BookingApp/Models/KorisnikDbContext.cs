using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class KorisnikDbContext : DbContext
    {

        private static KorisnikDbContext obj = null;

        public KorisnikDbContext(){}

        

        public static KorisnikDbContext GetKorisnikDbContextInstance()
        {
            if (obj == null)
                obj = new KorisnikDbContext();
            return obj;
        }

        //regulise promenu data context-a
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<KorisnikDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<Adresa> Adrese { get; set; }
        public virtual DbSet<Apartman> Apartmans { get; set; }
        public virtual DbSet<Komentar> Komentari { get; set; }
        public virtual DbSet<Lokacija> Lokacije { get; set; }
        public virtual DbSet<Rezervacija> Rezervacije { get; set; }
        public virtual DbSet<SadrzajApartmana> SadrzajiApartmana { get; set; }
        public virtual DbSet<Slika> Slikas { get; set; }
        public virtual DbSet<DostupniSadrzaji> DostupniSadrzaji { get; set; }
        public virtual DbSet<Praznik> Praznici { get; set; }
    }
}