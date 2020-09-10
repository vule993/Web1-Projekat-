using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Common
{
    public class KorisnikSecurity
    {
        public static Korisnik Login(String username, String password)
        {

            KorisnikDbContext korisnici = KorisnikDbContext.GetKorisnikDbContextInstance();

            Korisnik korisnik;
            //ako imamo korisnika sa tim username-om i passwordom uspesno smo prijavljeni
            try
            {
                korisnik = korisnici.Korisnici.FirstOrDefault(x => x.Lozinka == password && x.KorisnickoIme == username);
                return korisnik;
            }
            catch (Exception) { }

            return null;
        }
    }
}