using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Ninject.Web.Mvc;
using Ninject.Modules;
using Ninject;

namespace Hana {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication {
        
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //ignore for now
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("MetaWeblogAPI.ashx");
            
            routes.MapRoute(
              "wp_post",                                              // Route name
              "{year}/{month}/{day}/{id}",                           // URL with parameters
              new { controller = "Posts", action = "Details"}  // Parameter defaults
            );
            routes.MapRoute(
              "feed",                                              // Route name
              "feed",                           // URL with parameters
              new { controller = "Posts", action = "Feed" }  // Parameter defaults
            );
            routes.MapRoute(
              "search",                                              // Route name
              "search",                           // URL with parameters
              new { controller = "Archive", action = "Search" }  // Parameter defaults
            );

            routes.MapRoute(
              "category",                                              // Route name
              "category/{category}/{id}",                           // URL with parameters
              new { controller = "Archive", action = "Category", id=0 }  // Parameter defaults
            );
            routes.MapRoute(
              "tag",                                              // Route name
              "tag/{tag}/{id}",                           // URL with parameters
              new { controller = "Archive", action = "Tag", id = 0 }  // Parameter defaults
            );            
            
            routes.MapRoute(
              "who",                                              // Route name
              "who",                           // URL with parameters
              new { controller = "Home", action = "who", id = "" }  // Parameter defaults
           );           
            routes.MapRoute(
               "contact",                                              // Route name
               "contact",                           // URL with parameters
               new { controller = "Home", action = "contact", id = "" }  // Parameter defaults
           );

            routes.MapRoute(
                "resume",                                              // Route name
                "resume",                           // URL with parameters
                new { controller = "Home", action = "Resume", id = "" }  // Parameter defaults
            );


            routes.MapRoute(
              "post",                                              // Route name
              "{category}/{id}",                           // URL with parameters
              new { controller = "Posts", action = "Details" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected override void OnApplicationStarted() {
            RegisterRoutes(RouteTable.Routes);
            RegisterAllControllersIn(Assembly.GetExecutingAssembly());

        }
        protected override Ninject.IKernel CreateKernel() {
            return new StandardKernel(new BlogModule());
        }
    
    }

    class BlogModule:NinjectModule{
        public override void Load() {
            //Bind<IBlogRepository>().To<WPRepository>();
        }
    }


}