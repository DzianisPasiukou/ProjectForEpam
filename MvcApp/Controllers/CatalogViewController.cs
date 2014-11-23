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
        public ActionResult Details(int id, string description)
        {
            if (id != 0)
                return PartialView("RecordView", _recordsManager.GetBy(id.ToString()).First());
            else
                return Content(description);
        }
        public ActionResult TechicalDetails(int id)
        {
            return PartialView("TechnicalCharacteristic");
        }
        public ActionResult PhotoDetails(int id)
        {
            return PartialView("Photo");
        }
        public ActionResult VideoDetails(int id)
        {
            return PartialView("Video");
        }
        public ActionResult DocumentsDetails(int id)
        {
            return PartialView("Documents");
        }
    }
}