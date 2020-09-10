using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BookingApp.Common
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //saljemo kroz header podatke
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                //get authentication token 64 encoded
                //format username:password -> encoded
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                //dekodiramo dobijeni token
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                //uzimamo username i password
                string username = decodedAuthenticationToken.Split(':')[0];
                string password = decodedAuthenticationToken.Split(':')[1];

                Korisnik k = KorisnikSecurity.Login(username, password);

                if ( k != null)
                {
                    //korisnik je uspesno pronadjen i pogodio je password 
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(k.KorisnickoIme+":"+k.Uloga), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}