using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer.Entities;
using LogicLayer.CatalogManager;
using LogicLayer.CatalogManager.ThemeManager.RecordManager;

namespace MvcApp.Controllers
{
    public class CatalogViewController : Controller
    {
        //
        // GET: /CatalogView/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}