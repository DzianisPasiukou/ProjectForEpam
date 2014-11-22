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
        ITree _tree;
        public CatalogViewController(ITree tree)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
            _tree = tree;
        }
        //
        // GET: /CatalogView/
        public ActionResult Index()
        {

            TreeView treeCatalog = _tree.GetTree();

            return View(treeCatalog);
        }
       
    }
}