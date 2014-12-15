using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MvcApp.Hubs
{
    public class MessageHub : Hub
    {
        public void Send(string userName,string message,string date)
        {
            Clients.Client(userName).Send(message,date);
        }
        public void Registr(string userName)
        {
            Groups.Add(Context.ConnectionId, userName);
        }
        public void SendAll(string senderUserName,string message,string date)
        {
            date = DateTime.Now.ToString();
            Clients.All.addToPage(senderUserName,message,date);
        }
    }
}