using BookingApp.Common;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BookingApp.Controllers
{
    public class ProfilController : ApiController
    {
        // GET api/profil
        public IEnumerable<Apartman> Get()
        {
            return null;
        }

        // GET api/profil/5
        public Korisnik Get(int id)
        {
            KorisnikDbContext baza = KorisnikDbContext.GetKorisnikDbContextInstance();
            return baza.Korisnici.ToList().Find(x => x.Id == id);
        }

        // POST api/profil
        [HttpPost]
        public Korisnik Post([FromBody]Korisnik u)
        {
            try
            {
                var baza = KorisnikDbContext.GetKorisnikDbContextInstance();

                Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
                Korisnik k = baza.Korisnici.ToList().Find(x => x.Id == u.Id);

                k.KorisnickoIme = u.KorisnickoIme;
                k.Ime = u.Ime;
                k.Prezime = u.Prezime;
                k.Pol = u.Pol;

                repo.Update(k);
                return k;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }

        // PUT api/profil/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/profil/5
        public void Delete(int id)
        {
            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Delete(KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().FirstOrDefault(x => x.Id == id));
        }
    }
}
