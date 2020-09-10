using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Lokacija
    {
        public int Id { get; set; }
        public String GeografskaSirina { get; set; }
        public String GeografskaDuzina { get; set; }
        public virtual Adresa Adresa { get; set; }

        public override string ToString()
        {
            return $"{Adresa}";
        }
    }
}