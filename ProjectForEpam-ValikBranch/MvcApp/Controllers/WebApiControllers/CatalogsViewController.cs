using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer.CatalogManager;
using LogicLayer.Entities;

namespace MvcApp.Controllers.WebApiControllers
{
    [RoutePrefix("api/catalogs")]
    public class CatalogsViewController : ApiController
    {
         ITree _tree;
         public CatalogsViewController(ITree tree) 
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
            _tree = tree;
        }
        // GET api/<controller>
        [Route("")]
        [HttpGet]
        public IEnumerable<TreeView> Get()
        {
            return _tree.GetTree().ChildNode;
        }
    }
}