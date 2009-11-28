
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Hana.Model;
using SubSonic.Query;
using System.Threading;
using System.Text;
using SubSonic.DataProviders;

namespace Hana.Controllers
{
    public class ArchiveController : Controller
    {
        //
        // GET: /Archive/
        const int PAGE_SIZE = 20;
        public ActionResult Index(int? id)
        {
            var model = new ArchiveViewModel(new List<Post>());
            var pageIndex = id.HasValue ? id.Value : 0;
            var skipPosts = PAGE_SIZE * pageIndex;
            
            //pull back the last 20 posts, paged
            var posts = Post.All()
                .OrderByDescending(x => x.PublishedOn)
                .Skip(skipPosts).Take(PAGE_SIZE);
                


            model = new ArchiveViewModel(posts);
            model.Categories = Hana.Model.Category.All().ToList();

            if (Request.IsAjaxRequest())
            {

                return View("PostSummaryList", model.PostList);
            }
            model.ThisTerm = "index";
            model.ThisAction = "archive";
            model.SearchTerm = "All Posts By Date";
            return View(model);
        }

        public ActionResult Tag(int? id, string tag)
        {
            var model = new ArchiveViewModel(new List<Post>());
            if (String.IsNullOrEmpty(tag))
                return RedirectToAction("Index");


            var pageIndex = id.HasValue ? id.Value : 0;
            var skipPosts = PAGE_SIZE * pageIndex;

            //pull back the last 20 posts, paged
            var posts = Post.PostsByTags(tag)
                .OrderByDescending(x => x.PublishedOn)
                .Skip(skipPosts).Take(PAGE_SIZE);



            model = new ArchiveViewModel(posts);
            model.SearchTerm = "Tag: '" + tag + "'";
            model.ThisTerm = tag;
            model.ThisAction = "tag";
            model.Categories = Hana.Model.Category.All().ToList();
            if (Request.IsAjaxRequest())
            {

               return View("PostSummaryList", model.PostList);
            }
            return View("Index", model);
        }        
        
        
        public ActionResult Category(int? id, string category)
        {
            var model = new ArchiveViewModel(new List<Post>());
            if (String.IsNullOrEmpty(category))
                return RedirectToAction("Index");

            
            var pageIndex = id.HasValue ? id.Value : 0;
            var skipPosts = PAGE_SIZE * pageIndex;

            //pull back the last 20 posts, paged
            var posts = Post.PostsByCategorySlug(category)
                .OrderByDescending(x => x.PublishedOn)
                .Skip(skipPosts).Take(PAGE_SIZE);


            model = new ArchiveViewModel(posts);
            model.ThisTerm = category;
            model.ThisAction = "category";
            model.SearchTerm = "Category: '"+category+"'";

            model.Categories = Hana.Model.Category.All().ToList();

            if (Request.IsAjaxRequest())
            {
                return View("PostSummaryList", model.PostList);
            } 
            return View("Index", model);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string q)
        {
            var model = new ArchiveViewModel(new List<Post>());
            model.Categories = Hana.Model.Category.All().ToList();
            if (!String.IsNullOrEmpty(q))
            {
                //id is the query term
                //I know you won't like this
                //but that's OK -it's my blog :)
                var posts = new CodingHorror(ProviderFactory.GetProvider("Hana"), @"SELECT TOP 30 
                Posts.PostID, Posts.Title, Posts.Body, Posts.Excerpt, 
                Posts.Author, Posts.PublishedOn,Posts.Slug, Posts.Tags, Posts.CommentCount
                FROM dbo.SearchPosts(@p0) as t0
                INNER JOIN Posts on Posts.PostID=t0.PostID
                ORDER BY t0.Rank DESC", q).ExecuteTypedList<Post>();

                model = new ArchiveViewModel(posts);
                model.SearchTerm = q;
                if (Request.IsAjaxRequest())
                {
                    return View("PostSummaryList", model.PostList);
                } 
                return View(model);
            }
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Search()
        {
            var model = new ArchiveViewModel(new List<Post>());
            model.Categories = Hana.Model.Category.All().ToList();
            return View(model);
        }

    }
}
