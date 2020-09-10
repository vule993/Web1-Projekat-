using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookingApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            //kada nije inicijalizovana baza ucitavaju se admini, nakon toga nema izmena, komentari se zanemaruju, sintaksa kao u c#, css
            
            
            if (KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici.Count() == 0 && KorisnikDbContext.GetKorisnikDbContextInstance() != null)
            {

                List<Korisnik> admini = new List<Korisnik>();

                string[] adminitxt = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/admini.txt");

                var korisniciBaza = KorisnikDbContext.GetKorisnikDbContextInstance().Korisnici;

                foreach (var admin in adminitxt)
                {
                    if(admin.Length > 2 && admin.Substring(0,2).ToString() != "//")
                    {
                        var data = admin.Split(' ');
                        Korisnik adm = new Korisnik()
                        {
                            KorisnickoIme = data[0],
                            Lozinka = data[1],
                            Ime = data[2],
                            Prezime = data[3],
                            Pol = data[4],
                            Uloga = data[5],
                            Status = data[6]
                        };

                        Repository<Korisnik, KorisnikDbContext> repo = new Repository<Korisnik, KorisnikDbContext>(KorisnikDbContext.GetKorisnikDbContextInstance());
                        repo.Add(adm);
                    }

                }

                //Application["administratori"] = admini;
            }

          
        }
    }
}
