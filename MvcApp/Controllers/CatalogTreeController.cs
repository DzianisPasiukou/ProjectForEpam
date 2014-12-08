using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer.CatalogManager;
using LogicLayer.Entities;
using LogicLayer.CatalogManager.ThemeManager.RecordManager;
using System.Web.Mvc;

namespace MvcApp.Controllers.WebApiControllers
{
    public class CatalogTreeController : ApiController
    {
        ITree _tree;
        public CatalogTreeController(ITree tree)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
            _tree = tree;
            
        }
        
        // GET api/<controller>
        public TreeView GetTree()
        {
            return _tree.GetTree();
        }
    }
}
