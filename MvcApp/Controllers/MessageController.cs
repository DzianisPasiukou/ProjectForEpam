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
    public class MessageController : ApiController
    {
        private ISecurityHelper _securityHelper;

        public MessageController(ISecurityHelper securityHelper)
        {
            if (securityHelper == null)
            {
                throw new ArgumentNullException();
            }

            _securityHelper = securityHelper;
        }

        public IEnumerable<Message> GetLikeEnable(string sender, string recipient)
        {
            List<Message> messages = _securityHelper.GetMessages(sender, recipient).ToList<Message>();

            return messages;
        }
    }
}
