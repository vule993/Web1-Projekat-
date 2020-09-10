using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Adresa
    {
        public int Id { get; set; }
        public String UlicaBroj { get; set; }
        public String NaseljenoMesto { get; set; }
        public int PostanskiBroj { get; set; }

        public override string ToString()
        {
            return $"{UlicaBroj},{PostanskiBroj},{NaseljenoMesto}";
        }
    }
}