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
    [RoutePrefix("api/oglasi")]
    public class OglasiController : ApiController
    {
        // GET api/values
        [BasicAuthentication]
        public IEnumerable<Apartman> Get()
        {
            string usernameRole = Thread.CurrentPrincipal.Identity.Name;    // format tipa username:role
            KorisnikDbContext baza = KorisnikDbContext.GetKorisnikDbContextInstance();
            List<Apartman> lista;

            if (usernameRole.Split(':')[1] == "admin")
            {
                try
                {
                    lista = baza.Apartmans.ToList();    //ako trazi admin daj sve
                    return lista;
                }
                catch (Exception)
                {

                }
                
            }
            else
            {
                try
                {
                    lista = baza.Apartmans.ToList().FindAll(x => x.Status == true);     //ako trazi obican korisnik daj samo aktivne
                    return lista;
                }
                catch (Exception)
                {

                }

            }



            return null;
        }



        // GET api/oglasi/oglas/5   ->  dobavlja pojedinacan oglas na osnovu id-a
        [Route("getoglas")]
        public Apartman GetOglas(int id)
        {
            try
            {
                var result = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {

            }
            return null;
            
        }


        // GET api/values/5   ->  dobavlja sve oglase na osnovu id-a korisnika koji ih je postavio
        public IEnumerable<Apartman> Get(int id)
        {
            IEnumerable<Apartman> result = null;
            try
            {
                result = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().FindAll(x => x.Domacin.Id == id);

            }
            catch (Exception) { }
            return result;
        }

        // POST api/oglasi   ->  dodaje oglas
        [HttpPost]
        public void Post([FromBody]Apartman u)
        {
            try
            {

                Lokacija lok = new Lokacija()
                {
                    GeografskaDuzina = "",
                    GeografskaSirina = "",
                    Adresa = new Adresa()
                    {
                        UlicaBroj = u.Lokacija.Adresa.UlicaBroj,
                        NaseljenoMesto = u.Lokacija.Adresa.NaseljenoMesto,
                        PostanskiBroj = u.Lokacija.Adresa.PostanskiBroj
                    }
                };

                Repository<Slika, KorisnikDbContext> slike = new Repository<Slika, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
                List<Slika> s = new List<Slika>();
                foreach(var slika in u.Slike)
                {
                    s.Add(slika);
                    slike.Add(slika);
  
                }
                

                Repository<SadrzajApartmana, KorisnikDbContext> sadrzaj = new Repository<SadrzajApartmana, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
                List<SadrzajApartmana> sadr = new List<SadrzajApartmana>();
                foreach (var item in u.ListaSadrzaja)
                {
                    sadr.Add(item);
                    sadrzaj.Add(item);

                }
                

                Apartman k = new Apartman()
                {
                    Naziv = u.Naziv,
                    TipApartmana = u.TipApartmana,
                    BrojSoba = u.BrojSoba,
                    BrojGostiju = u.BrojGostiju,
                    Lokacija = u.Lokacija,
                    DatumiZaIzdavanje = u.DatumiZaIzdavanje,
                    DostupnostPoDatumima = u.DostupnostPoDatumima,
                    Domacin = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList().Find(x=>x.Id == u.Domacin.Id),
                    Komentari = new List<Komentar>(),
                    Slike = s,
                    CenaPoNoci = u.CenaPoNoci,
                    Ocena = 0,
                    VremeZaPrijavu = u.VremeZaPrijavu,
                    VremeZaOdjavu =  u.VremeZaOdjavu,
                    Status = u.Status,
                    ListaSadrzaja = sadr,
                    ListaRezervacija = new List<Rezervacija>()

                };

                Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
                repo.Add(k);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            

        }

        [HttpPost]
        [Route("izmeniApartman")]
        public void Post1([FromBody]Apartman u)
        {
            var a = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x => x.Id == u.Id);

            a.Naziv = u.Naziv;
            a.TipApartmana = u.TipApartmana;
            a.BrojSoba = u.BrojSoba;
            a.BrojGostiju = u.BrojGostiju;
            a.Lokacija = u.Lokacija;
            a.DatumiZaIzdavanje = u.DatumiZaIzdavanje;
            a.DostupnostPoDatumima = u.DostupnostPoDatumima;
            
            
            
            a.CenaPoNoci = u.CenaPoNoci;
            a.Ocena = 0;
            a.VremeZaPrijavu = u.VremeZaPrijavu;
            a.VremeZaOdjavu = u.VremeZaOdjavu;
            a.Status = u.Status;
            a.ListaSadrzaja = u.ListaSadrzaja;
            a.ListaRezervacija = new List<Rezervacija>();







            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(a);
        }



        // POST api/oglasi/Komentar   ->  dobavlja pojedinacan oglas na osnovu id-a
        [HttpPost]
        [Route("komentar")]
        public void Post([FromBody]Komentar u)
        {

            
            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());

            u.Korisnik = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList().Find(x => x.Id == u.Korisnik.Id);

            Apartman a = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x=>x.Id == u.Apartman.Id);
            a.Komentari.Add(u);

            repo.Update(a);

        }


        // PUT api/values/odobri   ->  menja status komentara na 1
        [Route("odobri")]
        public void Put1([FromBody]Komentar k)
        {
            Komentar kom = KorisnikDbContext.GetKorisnikDbContextInstance().Komentari.ToList().Find(x => x.Id == k.Id);
            kom.Status = "1";
            Repository<Komentar, KorisnikDbContext> repo = new Repository<Komentar, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }


        // PUT api/values/zabrani   ->  menja status komentara na 2
        [Route("zabrani")]
        public void Put2([FromBody]Komentar k)
        {
            Komentar kom = KorisnikDbContext.GetKorisnikDbContextInstance().Komentari.ToList().Find(x => x.Id == k.Id);
            kom.Status = "2";
            Repository<Komentar, KorisnikDbContext> repo = new Repository<Komentar, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }









        // PUT api/values/odobri   ->  menja status apartmana na 1
        [Route("odobriApartman")]
        public void Put3([FromBody]Apartman k)
        {
            Apartman kom = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x => x.Id == k.Id);
            kom.Status = true;
            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }


        // PUT api/values/zabrani   ->  menja status apartmana na 2
        [Route("zabraniApartman")]
        public void Put4([FromBody]Apartman k)
        {
            Apartman kom = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().Find(x => x.Id == k.Id);
            kom.Status = false;
            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Update(kom);
        }



        



        // DELETE api/values/5   ->  brise apartman (promeniti na update -> status)
        public void Delete(int id)
        {
            Repository<Apartman, KorisnikDbContext> repo = new Repository<Apartman, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
            repo.Delete(KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().FirstOrDefault(x => x.Id == id));
        }
    }
}
