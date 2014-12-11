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
        IDataBaseManager<Record> _dataRecord;
        public CatalogTreeController(ITree tree, IDataBaseManager<Record> dataRecord)
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
        public TreeView GetTree()
        {
            return _tree.GetTree();
        }
        public Record GetRecord(int id)
        {
            Record rec = _dataRecord.GetBy("id", id.ToString()).First();
            return rec;
        }
    }
}
