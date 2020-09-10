using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Korisnik> Get()
        {
            KorisnikDbContext baza = KorisnikDbContext.GetKorisnikDbContextInstance();
            return baza.Korisnici;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
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
                Uloga = u.Uloga
            };

            //KorisnikDbContext baza = KorisnikDbContext.GetKorisnikDbContextInstance();
            //baza.Korisnici.Add(k);
            Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Add(k);

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Delete(KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList().FirstOrDefault(x=>x.Id == id));
        }
    }
}
