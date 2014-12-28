using LogicLayer.Chat;
using LogicLayer.Entities;
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
        private IChatHelper _chatHelper;

        public MessageController(IChatHelper chatHelper)
        {
            if (chatHelper == null)
            {
                throw new ArgumentNullException();
            }

            _chatHelper = chatHelper;
        }

        public IEnumerable<Message> GetLikeEnable(string sender, string recipient)
        {
            List<Message> messages = _chatHelper.GetMessages(sender, recipient).ToList<Message>();

            return messages;
        }
    }
}
