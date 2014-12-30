using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class FileUploadController : ApiController
    {
        public FileUploadController()
        {

        }
        public int GetTraffic()
        {
            return 0;
        }
        [HttpPost]
        public void Post(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
           {
               var fileName = Path.GetFileName(file.FileName);
               var path = Path.Combine("~/Resources/", fileName);
               file.SaveAs(path);
           }
       
        }

    }
}