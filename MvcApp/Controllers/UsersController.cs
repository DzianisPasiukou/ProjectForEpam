using LogicLayer.Entities;
using LogicLayer.Security;
using LogicLayer.Users;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class UsersController : ApiController
    {
        private IUserHelper _userHelper;

        public UsersController(IUserHelper userHelper)
        {
            if (userHelper == null)
            {
                throw new ArgumentNullException();
            }

            _userHelper = userHelper;
        }

        // GET: api/Users
        public UsersAndGroups Get()
        {
            UsersAndGroups usersAndGroups = new UsersAndGroups();
            usersAndGroups.users = _userHelper.GetUsers().ToList();
            usersAndGroups.groups = _userHelper.GetGroups().ToList();

            return usersAndGroups;
        }

        // GET: api/Users/5
        public string GetAvatar(string login)
        {
            User user = _userHelper.GetUser(login);

            return user.AvatarPath;
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(string login, bool isActive)
        {
            _userHelper.UpdateUserActive(login, isActive);
        }

        public void Put(string login, string name, string surname, string email, string group)
        {
            _userHelper.UpdateUser(login, name, surname, email, group);
        }

        // DELETE: api/Users/5
        public void Delete(string login)
        {
            _userHelper.DeleteUser(login);
        }
    }
}
