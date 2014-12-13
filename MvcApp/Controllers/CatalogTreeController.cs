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
        IDataBaseManager<Note> _dataRecord;
        public CatalogTreeController(ITree tree, IDataBaseManager<Note> dataRecord)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
            _tree = tree;
            if (dataRecord == null)
            {
                throw new ArgumentNullException();
            }
            _dataRecord = dataRecord;
            
        }
        
        // GET api/<controller>
        public List<TreeView> GetTree()
        {
            return _tree.GetTree();
        }
        public Note GetRecord(int id)
        {
            Note rec = _dataRecord.GetBy("id", id.ToString()).First();
            return rec;
        }
    }
}
