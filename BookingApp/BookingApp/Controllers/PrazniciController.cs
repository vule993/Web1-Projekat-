using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    public class PrazniciController : ApiController
    {


        public IEnumerable<Praznik> Get()
        {
            try
            {
                var x = KorisnikDbContext.GetKorisnikDbContextInstance().Praznici.ToList();
                return x;
            }
            catch (Exception)
            {

            }
            return null;
        }

        // GET api/praznici/5
        public void Get(int id)
        {
            List<Praznik> sadrzaj = KorisnikDbContext.GetKorisnikDbContextInstance().Praznici.ToList();
            Praznik apartmanZaBrisanje = sadrzaj.Find(x => x.Id == id);
            Repository<Praznik, KorisnikDbContext> repo = new Repository<Praznik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Delete(apartmanZaBrisanje);
        }



        public void Post([FromBody]Praznik param)
        {
            if(param.Dan != "unesi praznik")
            {

                Praznik praznik = new Praznik
                {
                    Dan = param.Dan
                };

                Repository<Praznik, KorisnikDbContext> repo = new Repository<Praznik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
                repo.Add(praznik);
            }
        }
    }
}
