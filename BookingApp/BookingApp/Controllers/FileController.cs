using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookingApp.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        public async Task<string> Upload()
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            // extract file name and file contents
            var fileNameParam = provider.Contents[0].Headers.ContentDisposition.Parameters
                .FirstOrDefault(p => p.Name.ToLower() == "filename");


            //ovde nam je username da kreiramo folder
            var userParam = provider.Contents[0].Headers.ContentDisposition.Parameters
                .FirstOrDefault(p => p.Name.ToLower() == "name");

            string user = (fileNameParam == null) ? "" : userParam.Value.Trim('"');

            string path = System.Web.HttpContext.Current.Server.MapPath("~/img/apartmani/" + user);



            string fileName = (fileNameParam == null) ? "" : fileNameParam.Value.Trim('"');
            byte[] file = await provider.Contents[0].ReadAsByteArrayAsync();


            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                File.WriteAllBytes(path + "/" + fileName, file);

            }
            catch (Exception)
            {
                return "Greska prilikom cuvanja slika!";
            }


            return "Slike uspesno primljene!";
        }
    }
}

