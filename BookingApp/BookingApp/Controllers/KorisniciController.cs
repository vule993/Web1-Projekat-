using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    [RoutePrefix("api/korisnici")]
    public class KorisniciController : ApiController
    {
        // GET api/korisnici
        public IEnumerable<Korisnik> Get()
        {
            try { 
                return KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        //  -> pretvori u domacina
        public string Get(int id)
        {
            var user = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList().Find(x => x.Id == id);
            if(user.Uloga != "admin")
            {
                user.Uloga = "domacin";
            }
            

            Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(user);
            return "success!";
        }

        [Route("blok")]
        public string Get1(int id)
        {
            var user = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList().Find(x => x.Id == id);
            user.Status = "2";

            Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(user);
            return "success!";
        }



        // POST api/korisnici   
        public void Post([FromBody]String param)
        {
            

        }

        // PUT api/korisnici/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/korisnici/5
        public void Delete(int id)
        {

        }
    }
}
