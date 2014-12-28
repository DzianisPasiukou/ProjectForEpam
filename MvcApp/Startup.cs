using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using MvcApp.Hubs;
using LogicLayer.Chat;

[assembly: OwinStartup(typeof(MvcApp.Startup))]

namespace MvcApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(
            typeof(MessageHub),
            () => new MessageHub(new ChatHelper()));
            app.MapSignalR();
        }
    }
}
