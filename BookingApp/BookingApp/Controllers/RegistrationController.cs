using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    public class RegistrationController : ApiController
    {
        
        // GET api/registration
        public IEnumerable<String> Get()
        {
            return null;
        }

        // GET api/registration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/registration
        [HttpPost]
        public void Post([FromBody]Korisnik u)
        {

            Korisnik k = new Korisnik()
            {
                Ime = u.Ime,
                Prezime = u.Prezime,
                KorisnickoIme = u.KorisnickoIme,
                Lozinka = u.Lozinka,
                Pol = u.Pol,
                Uloga = u.Uloga,
                ApartmaniZaIzdavanje = new List<Apartman>(),
                IznajmljeniApartmani = new List<Apartman>(),
                ListaSvojihRezervacija = new List<Rezervacija>(),
                Status = "1"
            };

            Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Add(k);
        }

        // PUT api/registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/registration/5
        public void Delete(int id)
        {

        }
    }
}
