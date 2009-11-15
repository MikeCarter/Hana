using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hana.Model;


namespace Hana.Controllers {
    [HandleError]
    public class HomeController : Controller {
        
       
        public ActionResult Index() {

            var recent = Post.Recent(5);

            
            var subsonic = Post.PostsByCategory("subsonic")
                .Take(5).ToList();

            var tekpub = Post.PostsByTags("tekpub")
                .Take(5).ToList();

            var pops = Post.All()
                .OrderByDescending(x => x.CommentCount)
                .Take(5).ToList();

            var result = new HomeViewModel(recent,subsonic,pops,tekpub);

            //set counts
            result.TotalPosts = Post.Published().Count();
            result.TotalComments = Post.Published().Sum(x => x.CommentCount);
            
            return View(result);
        }

        public ActionResult Who() {
            return View();
        }
        public ActionResult Contact() {
            return View();
        }
        public ActionResult About() {
            return View();
        }
        public ActionResult Resume() {
            return View();
        }
    }
}
