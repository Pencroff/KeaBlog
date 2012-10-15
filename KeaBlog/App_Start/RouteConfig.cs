using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace KeaBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Robots.txt",
                "robots.txt",
                new { controller = "Home", action = "Robots" },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute("DownloadRoute",
                "Download/{*fileName}",
                new { controller = "Home", action = "Download", fileName = UrlParameter.Optional },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapRoute(
                "BlogTagRoute",
                "Tags/{id}/{*tag}",
                new { Controller = "Blog", action = "Tag" },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapRoute(
                "BlogCategoryRoute",
                "Categories/{id}/{*category}",
                new { Controller = "Blog", action = "Category" },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapRoute(
                "BlogSearchRoute",
                "Search/",
                new { Controller = "Blog", action = "Search" },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapRoute(
                "BlogPostRoute",
                "Post/{date}/{*url}",
                new { Controller = "Blog", action = "Post", date = UrlParameter.Optional, url = UrlParameter.Optional },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );

            routes.MapRoute(
                name: "All",
                url: "{*pathInfo}",
                defaults: new { controller = "Home", action = "NotFound" },
                namespaces: new string[] { "KeaBlog.Controllers" }
            );
        }
    }
}