using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Hana.Model;
using Hana.Infrastructure;

namespace Hana.Controllers
{
    public class PostsController : Controller
    {
        //
        // GET: /Posts/Details/5

        public ActionResult Details(string id)
        {
            
            //pull the post
            var post= Post.All().SingleOrDefault(x => x.Slug == id);
            if (post == null)
                return RedirectToAction("Index", "Home");
            var related = Post.Related(post.PostID).ToList();

            var model = new PostViewModel(related,post.Comments);
            model.SelectedPost = new PostView(post);

            return View(model);
        }


        public ActionResult Feed() {

            var posts = Post.Recent(10);
            return new FeedActionResult(FeedFormat.RSS, Url, posts);

        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Posts/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Posts/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Posts/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
