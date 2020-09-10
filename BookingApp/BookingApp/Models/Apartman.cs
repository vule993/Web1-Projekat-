using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Apartman
    {
        public int Id { get; set; }// /
        public String Naziv { get; set; }     //   
        public String TipApartmana { get; set; }    //    
        public int BrojSoba { get; set; }//
        public int BrojGostiju { get; set; }//

        public virtual Lokacija Lokacija { get; set; }//
        public virtual List<Datum> DatumiZaIzdavanje { get; set; }//
        public virtual List<Datum> DostupnostPoDatumima { get; set; }//

        public virtual Korisnik Domacin { get; set; }// / 
        public virtual List<Komentar> Komentari { get; set; }// /

        public virtual List<Slika> Slike { get; set; }         
        public double CenaPoNoci { get; set; }//

        public double Ocena { get; set; }// /

        public String VremeZaPrijavu { get; set; }//
        public String VremeZaOdjavu { get; set; }//

        public bool Status { get; set; }// /

        public virtual List<SadrzajApartmana> ListaSadrzaja { get; set; }

        public virtual List<Rezervacija> ListaRezervacija { get; set; }// /



        public Apartman()
        {
            ListaRezervacija = new List<Rezervacija>();
            ListaSadrzaja = new List<SadrzajApartmana>();
            Slike = new List<Slika>();
            Komentari = new List<Komentar>();
            DatumiZaIzdavanje = new List<Datum>();
            DostupnostPoDatumima = new List<Datum>();
        }


    }
}