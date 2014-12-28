using LogicLayer.Entities;
using LogicLayer.Security;
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
        private ISecurityHelper _securityHelper;

        public UsersController(ISecurityHelper securityHelper)
        {
            if (securityHelper == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = securityHelper;
        }

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return _securityHelper.GetUsers().ToList();
        }

        // GET: api/Users/5
        public string Get(string id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(string login, bool isActive)
        {
            _securityHelper.updateUserActive(login, isActive);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
