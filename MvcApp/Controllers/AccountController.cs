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
using LogicLayer.Security;

namespace MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private ISecurityHelper _securityHelper;

        public AccountController(ISecurityHelper securityHelper)
        {
            if (securityHelper == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = securityHelper;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid && _securityHelper.RegisterUser(model.Login, model.Password, model.Email, model.Name, model.Surname, model.Avatar))
            {
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

            LoginValidate valid = _securityHelper.LoginUser(model.Login, model.Password);

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

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ProfileInformation()
        {
            ViewBag.SecurityHelper = _securityHelper;
            return View();
        }

        public ActionResult UsersInformation()
        {
            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.SecurityHelper = _securityHelper;
            return View();
        }

        public ActionResult Chat()
        {
            ViewBag.SecurityHelper = _securityHelper;
            return View();
        }       
    }
}