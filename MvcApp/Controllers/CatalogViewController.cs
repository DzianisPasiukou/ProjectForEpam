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
        ITree _tree;
        IDataBaseManager<Record> _recordsManager;
        public CatalogViewController(ITree tree, IDataBaseManager<Record> recordsManager)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
            _tree = tree;
            if (recordsManager == null)
            {
                throw new ArgumentNullException();
            }
            _recordsManager = recordsManager;
        }
        //
        // GET: /CatalogView/
        public ActionResult Index()
        {

            TreeView treeCatalog = _tree.GetTree();

            return View(treeCatalog);
        }
       public PartialViewResult Details(int id)
        {
            Record rc = _recordsManager.GetBy(id.ToString()).First();
            return PartialView(rc);
        }
    }
}