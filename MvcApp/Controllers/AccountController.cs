using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using MvcApp.Models.Account;
using System.Web.Security;
using LogicLayer.Models;

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
            AccountViewModel model = new AccountViewModel();

            model.Name = "Admin";
            model.Surname = "Admin";
            model.Email = "admin@gmail.com";
            model.Login = "admin";
            model.Avatar = "default";
            model.Role = "Admin";
            model.DateOfRegistration = DateTime.Now.Date;
            model.IsActive = true;
            model.Downloaded = 0;
            model.Uploaded = 0;
            model.HaveLikes = 0;
            model.GaveLikes = 0;

            return View(model);
        }

        public ActionResult Users()
        {
            IEnumerable<User> users = _databaseHelper.GetUsers();

            IEnumerable<Role> roles = _databaseHelper.GetRoles();

            List<AccountViewModel> models = new List<AccountViewModel>();

            /*foreach (var item in users)
            {
                AccountViewModel model = new AccountViewModel();

                model.Name = item.Name;
                model.Surname = item.Surname;
                model.Email = item.Email;
                model.Login = item.Login;
                model.Avatar = item.Avatar;
                //model.Role = roles.FirstOrDefault(role => role.ID == item.RoleID).Name;
                model.DateOfRegistration = item.DateOfRegistration;
                model.IsActive = item.IsActive;
                model.Downloaded = item.Downloaded;
                model.Uploaded = item.Uploaded;
                model.HaveLikes = item.HaveLikes;
                model.GaveLikes = item.GaveLikes;
            }*/
            AccountViewModel model = new AccountViewModel();

            model.Name = "Admin";
            model.Surname = "Admin";
            model.Email = "admin@gmail.com";
            model.Login = "admin";
            model.Avatar = "default";
            model.Role = "Admin";
            model.DateOfRegistration = DateTime.Now;
            model.IsActive = true;
            model.Downloaded = 0;
            model.Uploaded = 0;
            model.HaveLikes = 0;
            model.GaveLikes = 0;

            models.Add(model);

            return View(models);
        }
    }
}