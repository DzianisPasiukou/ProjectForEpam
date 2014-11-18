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

        public AccountController(IDatabaseHelper databaseHelper)
        {
            if (databaseHelper == null)
            {
                throw new ArgumentNullException();
            }

            _databaseHelper = databaseHelper;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
<<<<<<< HEAD
            _databaseHelper.RegisterUser(model.Login, model.Password, model.Email, model.Name, model.Surname, model.Avatar);
=======
            _databaseHelper.RegisterUser("1", "12", "asd", "sf", "sdf", "sadf");
>>>>>>> 53331d9d77ac54ec8f282d65ed79b8dd2b9752e8
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