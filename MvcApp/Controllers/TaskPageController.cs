using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class TaskPageController : Controller
    {
        //
        // GET: /TaskPage/
        public ActionResult Task()
        {
            return View();
        }
	}
}