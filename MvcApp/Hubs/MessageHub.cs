using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MvcApp.Hubs
{
    public class MessageHub : Hub
    {
        public void Send(string login,string message)
        {
            Clients.Client(login).Send(message);
        }
        public void Registr(string login)
        {
            Groups.Add(Context.ConnectionId, login);
        }
    }
}