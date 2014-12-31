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
using LogicLayer.Users;
using System.Web.Configuration;
using System.IO;

namespace MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private ISecurityHelper _securityHelper;
        private IUserHelper _userHelper;
        IHashCalculator _hashCalculator;

        public AccountController(ISecurityHelper securityHelper,IUserHelper userHelper,IHashCalculator hashCalculator)
        {
            if (securityHelper == null)
            {
                throw new ArgumentNullException();
            }

            if (userHelper == null)
            {
                throw new ArgumentNullException();
            }
            if (hashCalculator == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = securityHelper;
            _userHelper = userHelper;
            _hashCalculator = hashCalculator;
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
            string avatar = "";
            if (Request.Files.Count > 0)
            {
                string folderPath = Server.MapPath(WebConfigurationManager.AppSettings["UsersAvatars"]);
                string fileName = _hashCalculator.Calculate(Request.Files[0].FileName);

                char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
                foreach (char charInvalid in charInvalidFileChars)
                {
                    fileName = fileName.Replace(charInvalid, ' ');
                }

                string ext = Path.GetExtension(Request.Files[0].FileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string filePath = Path.Combine(folderPath, fileName + ext);
                Request.Files[0].SaveAs(filePath);
                avatar = fileName;
            }

            if (ModelState.IsValid && _securityHelper.RegisterUser(model.Login, model.Password, model.Email, model.Name, model.Surname, avatar))
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

            if (valid == LoginValidate.Success)
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
        public JsonResult AutocompleteSearch(string term)
        {           
                IEnumerable<User> users = _userHelper.GetUsers();
                var models = users.Where(a => a.Login.Contains(term)).Select(a => new { value = a.Login }).Distinct();
                return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}