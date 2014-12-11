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
       
       
        IRecordCompare _recordsCompare;
        
        public CatalogViewController(IRecordCompare recordsComparers)
        {

            if (recordsComparers == null)
            {
                throw new ArgumentNullException();
            }
            _recordsCompare = recordsComparers;
        }
        
        //
        // GET: /CatalogView/
        public ActionResult Index()
        {
            return View();
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