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
        IDataBaseManager<Record> _dataRecord;
        public CatalogViewController(IRecordCompare recordsComparer, IDataBaseManager<Record> dataRecord)
        {
           
            if(recordsComparer== null)
            {
                throw new ArgumentNullException();
            }
            _recordsCompare = recordsComparer;
            if (dataRecord == null)
            {
                throw new ArgumentNullException();
            }
            _dataRecord = dataRecord;
        }
        
        //
        // GET: /CatalogView/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Record rec = _dataRecord.GetBy("id", id.ToString()).First();
            return PartialView("_RecordView", rec);
        }
        public ActionResult TechicalDetails(int id)
        {
            return PartialView("_TechnicalCharacteristic");
        }
        public ActionResult PhotoDetails(int id)
        {
            return PartialView("_Photo");
        }
        public ActionResult VideoDetails(int id)
        {
            return PartialView("_Video");
        }
        public ActionResult DocumentsDetails(int id)
        {
            return PartialView("_Documents");
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