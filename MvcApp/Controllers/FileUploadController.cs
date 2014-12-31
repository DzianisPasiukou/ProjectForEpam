using LogicLayer.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Configuration;


namespace MvcApp.Controllers
{
    public class FileUploadController : ApiController
    {
        ISecurityHelper _securityHelper;
        IHashCalculator _hashCalculator;
        public FileUploadController(ISecurityHelper securityHelper, IHashCalculator hashCalculator)
        {
            if (securityHelper == null && hashCalculator == null)
            {
                throw new NullReferenceException("fileUploadController");
            }
            _securityHelper = securityHelper;
            _hashCalculator = hashCalculator;
        }
        public int GetTraffic()
        {
            return 0;
        }
        
        [HttpPost]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var files = new List<string>();

                foreach (string file in httpRequest.Files)
                { 
                    var postedFile = httpRequest.Files[file];
                    string fileName = _hashCalculator.Calculate(postedFile.FileName);
                    char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
                    foreach (char charInvalid in charInvalidFileChars)
                    {
                        fileName = fileName.Replace(charInvalid, ' ');
                    }
                    string ext = Path.GetExtension(postedFile.FileName);
                    string folder = WebConfigurationManager.AppSettings["NotesForModeration"];
                    string folderDirectory = Path.Combine(HttpContext.Current.Server.MapPath(folder));

                    if (!Directory.Exists(folderDirectory))
                    {
                        Directory.CreateDirectory(folderDirectory);
                    }

                    var filePath = Path.Combine(folderDirectory, fileName + ext);
                    postedFile.SaveAs(filePath);
                    files.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, files);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

    }
}

