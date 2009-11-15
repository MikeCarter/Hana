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
              "post",                                              // Route name
              "posts",                           // URL with parameters
              new { controller = "Posts", action = "Index", id = "" }  // Parameter defaults
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