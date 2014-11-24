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
        IRecordCompare _recordsCompare;
        public CatalogViewController(ITree tree, IDataBaseManager<Record> recordsManager, IRecordCompare recordsComparer)
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
            if(recordsComparer== null)
            {
                throw new ArgumentNullException();
            }
            _recordsCompare = recordsComparer;
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
            {
                List<SelectListItem> selectList = new List<SelectListItem>();
                Record current = _recordsManager.GetBy("ID",id.ToString()).First();
                IEnumerable<Record> records = _recordsManager.GetBy("ThemeID",current.ThemeID.ToString());

                foreach (var rc in records)
                {
                    selectList.Add(new SelectListItem()
                    {
                        Text = rc.Name,
                        Value = rc.ID.ToString()
                    });
                }
                ViewData.Add(new KeyValuePair<string, object>("CompareList",selectList));
                TempData["Compare"] = selectList;

                return PartialView("RecordView", current);
            }
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
        public ActionResult Compare(string str,string str1)
        {
            string[] arr = str.Split(':');

            if (arr[0]==arr[1])
            {
                return View();
            }

            IEnumerable<Record> currentRec = _recordsCompare.GetRecords(arr[0], arr[1]); ;

            return PartialView(currentRec);
        }
        
    }
}