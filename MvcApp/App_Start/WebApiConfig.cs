using Microsoft.Practices.Unity;
using System.Web.Http;

namespace MvcApp
{
    public class WebApiConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "API Default",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional }
                );
            /*
            config.Routes.MapHttpRoute(
                "Like Routing",
                "api/{controller}/{id}/{noteOrFile}",
                new { id = RouteParameter.Optional, noteOrFile = "" }
                );
             * */
        }
    }
}