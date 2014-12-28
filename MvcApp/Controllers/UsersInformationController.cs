using LogicLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer.Entities;

namespace MvcApp.Controllers
{
    public class UsersInformationController : ApiController
    {
        private ISecurityHelper _securityHelper;

        public UsersInformationController(ISecurityHelper securityHelper)
        {
            if (securityHelper == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = securityHelper;
        }

        public User GetUser(string login)
        {
            return _securityHelper.GetUser(login);
        }

        public IEnumerable<User> GetUsers()
        {

            return _securityHelper.GetUsers().ToList();
        }

        //public IEnumerable<Group> GetGroups()
        //{
        //    return _securityHelper.GetGroups().ToList();
        //}
    }
}
