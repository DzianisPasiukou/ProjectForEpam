using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using LogicLayer.Chat;

namespace MvcApp.Hubs
{
    [Authorize]
    public class MessageHub : Hub
    {

        IChatHelper _chatHelper;

        public MessageHub(IChatHelper chatHelper)
        {
            if (chatHelper == null)
            {
                throw new NullReferenceException("chatHelper/MessageHub");
            }
            _chatHelper = chatHelper;
        }

        public void SendTo(string recepientLogin, string message)
        {
            string senderLogin = Context.User.Identity.Name;
            string date = DateTime.Now.ToString();

            Clients.Caller.AddToPage(senderLogin, message, date);
            Clients.User(recepientLogin).Send(senderLogin, message, date);
            _chatHelper.AddMessage(senderLogin, recepientLogin, message, date);
        }       
    }
}