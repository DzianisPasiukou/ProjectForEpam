using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using LogicLayer.Security;

namespace MvcApp.Hubs
{
    public class MessageHub : Hub
    {
       
        ISecurityHelper _securityHelper = new SecurityHelper();

        public void SendTo(string senderLogin, string recepientLogin, string message)
        {
            string date = DateTime.Now.ToString();
            Clients.Caller.AddToPage(senderLogin,message,date);
            Clients.Group(recepientLogin).Send(senderLogin,message,date);
            bool flag = _securityHelper.AddMessage(senderLogin, recepientLogin, message, date);
        }
        public void Registr(string login)
        {
            Groups.Add(Context.ConnectionId, login);
        }

        //test
        public void SendAll(string senderUserName,string message)
        {         
            string date = DateTime.Now.DayOfWeek.ToString();
            Clients.Others.addToPageAll(senderUserName,message,date);
            
        }
    }
}