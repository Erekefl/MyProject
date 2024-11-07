using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetAllAuthor",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Author", action = "GetAllAuthor", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "GetAllBooks",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Book", action = "GetAllBooks", id = UrlParameter.Optional }
           );
        }
    }
}
