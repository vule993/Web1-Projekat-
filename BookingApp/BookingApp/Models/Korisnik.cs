using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public String KorisnickoIme { get; set; }
        public String Lozinka { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Pol { get; set; }
        public String Uloga { get; set; }
        public List<Apartman> ApartmaniZaIzdavanje { get; set; }
        public List<Apartman> IznajmljeniApartmani { get; set; }
        public List<Rezervacija> ListaSvojihRezervacija { get; set; }
        public String Status { get; set; }
    }
}