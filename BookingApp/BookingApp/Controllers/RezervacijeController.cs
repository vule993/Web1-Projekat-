using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingApp.Controllers
{
    [RoutePrefix("api/rezervacije")]
    public class RezervacijeController : ApiController
    {

        
        public IEnumerable<Rezervacija> Get([FromUri] int idApartmana)
        {
            try
            {
                var rez = KorisnikDbContext.GetKorisnikDbContextInstance().Rezervacije.ToList().FindAll(x => x.RezervisaniApartman == idApartmana);
                return rez;
            }
            catch (Exception)
            {

            }
            return null;

        }


        [HttpPost]
        public void Post([FromBody]Rezervacija u)
        {

            u.Gost = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList().Find(x => x.Id == u.Gost.Id);
            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());

            Apartman a = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x => x.Id == u.RezervisaniApartman);
            a.ListaRezervacija.Add(u);
            repo.Update(a);

        }



        [Route("odobriRezervaciju")]
        public void Put1([FromBody]Rezervacija k)
        {
            Rezervacija rez = KorisnikDbContext.GetKorisnikDbContextInstance().Rezervacije.ToList().Find(x => x.Id == k.Id);
            rez.Status = "PRIHVACENA";
            Repository<Rezervacija, KorisnikDbContext> repo = new Repository<Rezervacija, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            //repo.Update(rez);


            Apartman apartman = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x => x.Id == k.RezervisaniApartman);

            var pocetni = rez.PocetniDatumRezervacije.Split(' ')[0];
            var startDate = DateTime.ParseExact(pocetni,"d",null);

            for (int i = 0; i < rez.BrojNocenja; i++)
            {
                //za svaki dan brisemo iz dostupnih
                foreach (var Datum in apartman.DostupnostPoDatumima.ToList())
                {
                    if(startDate == DateTime.ParseExact(Datum.Dan, "d", null))
                    {
                        apartman.DostupnostPoDatumima.Remove(Datum);
                    }
                }

                startDate.AddDays(1);
            }



              


            Repository<Apartman, KorisnikDbContext> repo1 = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo1.Update(apartman);





        }

        [Route("odbijRezervaciju")]
        public void Put2([FromBody]Rezervacija k)
        {
            Rezervacija kom = KorisnikDbContext.GetKorisnikDbContextInstance().Rezervacije.ToList().Find(x => x.Id == k.Id);
            kom.Status = "ODBIJENA";
            Repository<Rezervacija, KorisnikDbContext> repo = new Repository<Rezervacija, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }


        [Route("zavrsiRezervaciju")]
        public void Put3([FromBody]Rezervacija k)
        {
            Rezervacija kom = KorisnikDbContext.GetKorisnikDbContextInstance().Rezervacije.ToList().Find(x => x.Id == k.Id);
            kom.Status = "ZAVRSENA";
            Repository<Rezervacija, KorisnikDbContext> repo = new Repository<Rezervacija, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }




        [Route("odustaniOdRezervacije")]
        public void Put4([FromBody]Rezervacija k)
        {
            Rezervacija kom = KorisnikDbContext.GetKorisnikDbContextInstance().Rezervacije.ToList().Find(x => x.Id == k.Id);
            kom.Status = "ODUSTANAK";
            Repository<Rezervacija, KorisnikDbContext> repo = new Repository<Rezervacija, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }
    }
}
