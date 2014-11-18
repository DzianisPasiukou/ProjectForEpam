using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using MvcApp.Models.Account;

namespace MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private IDatabaseHelper _databaseHelper;

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            _databaseHelper.RegisterUser(model.Login, model.Password, model.Email, model.Name, model.Surname, "");
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }
    }
}