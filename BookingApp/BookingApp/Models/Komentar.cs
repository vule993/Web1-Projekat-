using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        //probaj da vratis na Apartman ali dodaj virtual, zaboravio si virtual
        //[ForeignKey("Id")]
        [NotMapped]
        public virtual Apartman Apartman { get; set; }
        public String TekstKomentara { get; set; }
        public double Ocena { get; set; }
        public String Status { get; set; }
    }
}