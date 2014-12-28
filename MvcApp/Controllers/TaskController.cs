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
    public class TaskController : ApiController
    {
        private ISecurityHelper _securityHelper;

        public TaskController(ISecurityHelper securityHelper)
        {
            if (securityHelper == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = securityHelper;
        }
        
        public IEnumerable<Task> GetTasks()
        {
            return _securityHelper.GetTasks().ToList();
        }
    }
}
