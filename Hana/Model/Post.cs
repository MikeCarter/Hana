using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using SubSonic.Extensions;

namespace Hana.Model {
    public partial class Post{
        public static IQueryable<Post> PostsByCategory(string category)
        {
            var query = from p in Published()
                        join cp in Categories_Post.All() on p.PostID equals cp.PostID
                        join c in Category.All() on cp.CategoryID equals c.CategoryID
                        where c.Description==category
                        select p;
            return query;
        }
        public static IQueryable<Post> Recent(int limit){
            return Post.Published()
                .OrderByDescending(x => x.PublishedOn).Take(limit);
        }
        public static IQueryable<Post> PostsByTags(string tag) {
            var query = from p in Published()
                        join tp in Tags_Post.All() on p.PostID equals tp.PostID
                        join t in Tag.All() on tp.TagID equals t.TagID
                        where t.Description==tag
                        select p;
            return query;
        }

        public static IQueryable<Post> Published() {
            return Post.All().Where(x => x.PublishedOn <= DateTime.Now);
        }

        public static IList<Category> Categories(int postID){
            return (from p in Published()
                        join cp in Categories_Post.All() on p.PostID equals cp.PostID
                        join c in Category.All() on cp.CategoryID equals c.CategoryID
                        where p.PostID == postID
                        select c).ToList();
        }

        public static string CreateSummary(Post post){
            string result = post.Body;

            if (post.Body.Contains("<!--more-->")) {
                result= post.Body.Chop("<!--more-->");
            } else {
                var entry = post.Body.StripHTML();
                //regex on the sentences and return the first 2
                var reg = new Regex(@"[^.?!]+[.?!]");
                var matches = reg.Matches(entry);
                if (matches.Count > 1) {
                    result = matches[0].Value + matches[1].Value;
                } else if (matches.Count > 0) {
                    result = matches[0].Value;
                }
            }

            return result;
        }
    }

}
