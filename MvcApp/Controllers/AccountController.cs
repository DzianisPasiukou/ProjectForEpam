using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using MvcApp.Models.Account;
using System.Web.Security;
using LogicLayer.Entities;

namespace MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private ISecurityHelper _databaseHelper;

        public AccountController(ISecurityHelper databaseHelper)
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
            if (ModelState.IsValid && _databaseHelper.RegisterUser(model.Login, model.Password, model.Email, model.Name, model.Surname, model.Avatar))
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            LoginValidate valid = _databaseHelper.LoginUser(model.Login, model.Password);

            if (valid == LoginValidate.Seccess)
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            if (valid == LoginValidate.NotApproved)
            {
                model.Message = "Not approved";
            }
            else
            {
                model.Message = "Not registered";
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Account()
        {
            User user = new User();
            return View();
        }
    }
}