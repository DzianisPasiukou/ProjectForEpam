using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer.Entities;
using LogicLayer.CatalogManager;

namespace MvcApp.Controllers
{
    public class CatalogViewController : Controller
    {
        //
        // GET: /CatalogView/
        IDataBaseManager<Catalog> _catalogs;
        IDataBaseManager<Theme> _themes;
        IDataBaseManager<Record> _records;

        public CatalogViewController(IDataBaseManager<Catalog> catalogs, IDataBaseManager<Theme> themes, IDataBaseManager<Record> records) 
        {
            if (catalogs == null)
            {
                throw new ArgumentNullException();
            }
            _catalogs = catalogs;

            if (themes == null)
            {
                throw new ArgumentException();
            }
            _themes = themes;

            if (records == null)
            {
                throw new ArgumentException();
            }
            _records = records;
        }

        //
        // GET: /CatalogView/
        public ActionResult Index()
        {
            IEnumerable<Catalog> cats = _catalogs.Get();

            return View(cats);
        }

        public ActionResult DetailsCatalog(string nameCatalog)
        {
            IEnumerable<Theme> ths = _themes.GetBy(nameCatalog);

            return View(ths);
        }

        public ActionResult DetailsTheme(string theme)
        {
            IEnumerable<Record> rcs = _records.GetBy(theme);

            return View(rcs);
        }
	}
}