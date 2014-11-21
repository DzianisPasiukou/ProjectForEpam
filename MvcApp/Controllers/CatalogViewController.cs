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
            return View();
        }
        /*
        public ActionResult DetailsTheme(string nameCatalog)
        {
            IEnumerable<TreeView> treeThemes = _tree.GetTree().children.Find(t => t.roleName == nameCatalog).children;

            return View(treeThemes);
        }

        public ActionResult DetailsRecord(string themeName, string nameCatalog)
        {
            IEnumerable<TreeView> treeRecord = _tree.GetTree().children.Find(t => t.roleName == nameCatalog).children.Find(r => r.roleName == themeName).children;

            return View(treeRecord);
        }
         * */
	}
}