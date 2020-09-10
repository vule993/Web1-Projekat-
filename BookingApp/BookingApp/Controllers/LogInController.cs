using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    public class LogInController : ApiController
    {

        // GET api/login
        public IEnumerable<String> Get()
        {
            String[] s = { "ad", "asd" };


            try { 
                return s;

            }
            catch (Exception)
            {

            }
            return null;
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login   slanje podataka pri logovanju
        public Korisnik Post([FromBody]String param)
        {
            KorisnikDbContext db = KorisnikDbContext.GetKorisnikDbContextInstance();

            String username = (param.Split(':')[1]);
            String password = (param.Split(':')[0]);

            try
            {
                Korisnik korisnik = db.Korisnici.First(k => k.Lozinka == password && k.KorisnickoIme == username);
                return korisnik;
            }
            catch(Exception e)
            {
                return null;
            }

            

            //vracam status OK + samog korisnika kako bismo mogli pokrenuti sesiju
            
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
            
        }
    }
}
