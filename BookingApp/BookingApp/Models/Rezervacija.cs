using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }

        public int RezervisaniApartman { get; set; }
        public String PocetniDatumRezervacije { get; set; }
        public int BrojNocenja { get; set; }
        public double UkupnaCena { get; set; }
        public virtual Korisnik Gost { get; set; }
        public String Status { get; set; }
    }
}