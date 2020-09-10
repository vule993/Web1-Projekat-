using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    public class ItemsController : ApiController
    {
        // GET api/items
        public IEnumerable<DostupniSadrzaji> Get()
        {
            try
            {
                var x = KorisnikDbContext.GetKorisnikDbContextInstance().DostupniSadrzaji.ToList();
                return x;
            }
            catch (Exception)
            {

            }
            return null;
        }

        // GET api/items/5
        public void Get(int id)
        {
            List<DostupniSadrzaji> sadrzaj = KorisnikDbContext.GetKorisnikDbContextInstance().DostupniSadrzaji.ToList();
            DostupniSadrzaji apartmanZaBrisanje = sadrzaj.Find(x => x.Id == id);
            Repository<DostupniSadrzaji, KorisnikDbContext> repo = new Repository<DostupniSadrzaji, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Delete(apartmanZaBrisanje);
        }


        // POST api/items   
        public void Post([FromBody]DostupniSadrzaji param)
        {
            DostupniSadrzaji sadrzaj = new DostupniSadrzaji
            {
                Naziv = param.Naziv
            };

            Repository<DostupniSadrzaji, KorisnikDbContext> repo = new Repository<DostupniSadrzaji, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Add(sadrzaj);
        }

        // PUT api/items/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/items/5
        public void Delete(int id)
        {

        }
    }
}
