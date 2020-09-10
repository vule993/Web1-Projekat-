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




    [RoutePrefix("api/pretraga")]
    public class PretragaController : ApiController
    {
        //pretraga korisnika
        [HttpPut]
        [Route("korisnika")]
        public IEnumerable<Korisnik> Put1([FromBody] MyModelK model)
        {
            var rez = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.ToList();

            if (model.korisnickoIme != null) {
                rez = rez.FindAll(x => x.KorisnickoIme == model.korisnickoIme);
            }

            if (model.uloga != "*")
            {
                rez = rez.FindAll(x => x.Uloga == model.uloga);
            }

            if (model.pol != "*")
            {
                rez = rez.FindAll(x => x.Pol == model.pol);
            }

            return rez;
        }



        //pretraga Apartmana
        public IEnumerable<Apartman> Put([FromBody] MyModel m)
        {
            var rez = KorisnikDbContext.GetKorisnikDbContextInstance().Apartmans.ToList().FindAll(x => x.Status == true);

            if(m.cenaDo != 0)
            {
                rez = rez.FindAll(x => x.CenaPoNoci < m.cenaDo);
            }

            if (m.cenaOd != 0)
            {
                rez = rez.FindAll(x => x.CenaPoNoci > m.cenaOd);
            }

            if (m.doDatuma != "slobodno do")
            {
                var d1 = DateTime.Parse(m.doDatuma);
                var rez1 = new List<Apartman>();
                foreach(var ap in rez)
                {
                    //ako u sklopu datuma ovog apartmana postoji bar jedan datum manji od unetog, taj apartman se uzima
                    foreach(var dateString in ap.DostupnostPoDatumima)
                    {
                        var d2 = DateTime.Parse(dateString.Dan);
                        if (DateTime.Compare(d1, d2) > 0){
                            rez1.Add(ap);
                            break;
                        }
                    }

                }

                rez = rez1;
            }

            if (m.odDatuma != "slobodno od")
            {
                var d1 = DateTime.Parse(m.odDatuma);
                var rez1 = new List<Apartman>();
                foreach (var ap in rez)
                {
                    //ako u sklopu datuma ovog apartmana postoji bar jedan datum veci od unetog, taj apartman se uzima
                    foreach (var dateString in ap.DostupnostPoDatumima)
                    {
                        var d2 = DateTime.Parse(dateString.Dan);
                        if (DateTime.Compare(d1, d2) < 0)
                        {
                            rez1.Add(ap);
                            break;
                        }
                    }

                }

                rez = rez1;
            }



            if (m.naseljenoMesto != "*")
            {
                rez = rez.FindAll(x => x.Lokacija.Adresa.NaseljenoMesto == m.naseljenoMesto);
            }

            if (m.osoba > 0)
            {
                rez = rez.FindAll(x => x.BrojGostiju == m.osoba);
            }




            //sadrzaj
            if (m.sadrzaj != null)
            {
                var rez1 = new List<Apartman>();
                foreach (var str in m.sadrzaj)
                {
                    
                    foreach (var ap in rez)
                    {
                        //ako u sklopu datuma ovog apartmana postoji bar jedan datum veci od unetog, taj apartman se uzima
                        foreach (var Item in ap.ListaSadrzaja)
                        {

                            if (str == Item.Naziv)
                            {
                                rez1.Add(ap);
                                continue;
                            }
                        }

                    }
                }
                

                rez = rez1;
            }


            if (m.sobaOd != 0)
            {
                rez = rez.FindAll(x => x.BrojSoba < m.sobaOd);
            }

            if (m.sobaDo != 0)
            {
                rez = rez.FindAll(x => x.BrojSoba < m.sobaDo);
            }





            //default : true
            rez = rez.FindAll(x => x.Status == m.status);
            

            if (m.tip != "*")
            {
                rez = rez.FindAll(x => x.TipApartmana == m.tip);
            }




            if (m.sort == "r")
            {
                rez = rez.OrderBy(x=>x.CenaPoNoci).ToList();
            }else if(m.sort == "o")
            {
                rez = rez.OrderByDescending(x => x.CenaPoNoci).ToList();
            }

            
            return rez;
        }








        [HttpGet]
        [Route("adr")]
        public IEnumerable<String> Get1()
        {
            try
            {
                var rez = KorisnikDbContext.GetKorisnikDbContextInstance().Adrese.ToList().Select(x => x.NaseljenoMesto).Distinct().ToList();
                return rez;
            }
            catch (Exception)
            {

            }
            return null;
            
        }


        [HttpGet]
        [Route("itm")]
        public IEnumerable<String> Get2()
        {
            try
            {

                var rez = KorisnikDbContext.GetKorisnikDbContextInstance().DostupniSadrzaji.ToList().Select(x => x.Naziv).Distinct().ToList();
                return rez;
            }
            catch (Exception)
            {

            }
            return null;
        }



    }
}
