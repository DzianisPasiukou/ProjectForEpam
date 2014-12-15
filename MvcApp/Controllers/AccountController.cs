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
using System.Data.SqlTypes;

namespace MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private ISecurityHelper _securityHelper;

        public AccountController(ISecurityHelper databaseHelper)
        {
            if (databaseHelper == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = databaseHelper;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Account()
        {
            ViewBag.SecurityHelper = _securityHelper;

            AccountViewModel model = new AccountViewModel();

            User user = _securityHelper.GetUser(User.Identity.Name);

            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Login = user.Login;
            model.Avatar = user.Avatar;
            model.Role = _securityHelper.GetRole(user.Login);
            model.DateOfRegistration = user.DateOfRegistration;
            model.IsActive = user.IsActive;
            model.Downloaded = user.Downloaded;
            model.Uploaded = user.Uploaded;
            model.HaveLikes = user.HaveLikes;
            model.GaveLikes = user.GaveLikes;

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            IEnumerable<User> users = _securityHelper.GetUsers();

            IEnumerable<Role> roles = _securityHelper.GetRoles();

            List<AccountViewModel> models = new List<AccountViewModel>();

            foreach (var item in users)
            {
                AccountViewModel model = new AccountViewModel();

                model.Name = item.Name;
                model.Surname = item.Surname;
                model.Email = item.Email;
                model.Login = item.Login;
                model.Avatar = item.Avatar;
                model.Role = roles.FirstOrDefault(role => role.ID == item.RoleID).Name;
                model.DateOfRegistration = item.DateOfRegistration;
                model.IsActive = item.IsActive;
                model.Downloaded = item.Downloaded;
                model.Uploaded = item.Uploaded;
                model.HaveLikes = item.HaveLikes;
                model.GaveLikes = item.GaveLikes;

                if (model.Role != "Admin")
                {
                    models.Add(model);
                }
            }

            return View(models);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public PartialViewResult GetUser(string login)
        {
            AccountViewModel model = new AccountViewModel();

            User user = _securityHelper.GetUser(login);

            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Login = user.Login;
            model.Avatar = user.Avatar;
            model.Role = _securityHelper.GetRole(user.Login);
            model.DateOfRegistration = user.DateOfRegistration;
            model.IsActive = user.IsActive;
            model.Downloaded = user.Downloaded;
            model.Uploaded = user.Uploaded;
            model.HaveLikes = user.HaveLikes;
            model.GaveLikes = user.GaveLikes;

            return PartialView("_User", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaveUser(AccountViewModel model)
        {
            if (_securityHelper.UpdateUser(model.Login, model.Name, model.Surname, model.Email, model.Role, model.IsActive))
            {
                return RedirectToAction("Users", "Account");
            }

            return View(model);

        }
    }
}