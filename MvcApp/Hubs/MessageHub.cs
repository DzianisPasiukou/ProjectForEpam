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

        public void SendTo(string senderUserName, string recepientUserName, string message)
        {
            string date = DateTime.Now.ToString();
            Clients.Client(recepientUserName).Send(message, date);
            _securityHelper.AddMessage(senderUserName, recepientUserName, message, date);
        }
        public void Registr(string userName)
        {
            Groups.Add(Context.ConnectionId, userName);
        }

        //test
        public void SendAll(string senderUserName,string message,string date)
        {         
            date = DateTime.Now.DayOfWeek.ToString();
            Clients.Others.addToPage(senderUserName,message,date);
            
        }
    }
}