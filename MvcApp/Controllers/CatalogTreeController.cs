using LogicLayer;
using LogicLayer.CatalogManager;
using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcApp.Controllers.WebApiControllers
{
    public class CatalogTreeController : ApiController
    {
        ITree _tree;
        IDataBaseManager<Note> _dataNote;
        public CatalogTreeController(ITree tree, IDataBaseManager<Note> dataNote)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
            _tree = tree;
            if (dataNote == null)
            {
                throw new ArgumentNullException();
            }
            _dataNote = dataNote;
            
        }
        
        // GET api/<controller>
        public List<TreeView> GetTree()
        {
            return _tree.GetTree();
        }
        public Note GetRecord(int id)
        {
            Note rec = _dataNote.GetBy("Id_Note", id.ToString()).First();
            return rec;
        }
    }
}
