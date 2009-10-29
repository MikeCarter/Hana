using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model {

    public class PostService {
        IBlogRepository _repo;
        public PostService() {
            _repo = null;
        }
        public PostService(IBlogRepository repo) {
            _repo = repo;
        }

        /// <summary>
        /// pulls the data for use on the home page
        /// </summary>
        /// <returns></returns>
        public PostViewModel GetHomePage() {

            var posts = _repo.GetPosts();

            var totalPosts = posts.Count();
            var totalComments = _repo.GetApprovedComments().Count();

            var featured = (from p in posts
                       where p.PublishedAt <= DateTime.Now && p.Status==Post.Status_Published
                       select p);
            

            var subsonicCategory=new Category("SubSonic");
            var subsonic = _repo.GetPosts(subsonicCategory);

            var opinionCat = new Category("Opinion");
            var opinion = _repo.GetPosts(opinionCat);

            var recentComments = (from c in _repo.GetApprovedComments()
                                  orderby c.CreatedAt descending
                                  where c.Status==CommentStatus.Approved
                                  select c);


            return new PostViewModel(totalPosts, totalComments, featured, 
                subsonic, opinion, recentComments);

        }
        /// <summary>
        /// pulls the data for use on the home page
        /// </summary>
        /// <returns></returns>
        public PostViewModel GetPostPage(string slug) {

            return GetPostPage(slug, 0, 0, 0);

        }
        /// <summary>
        /// pulls the data for use on the home page
        /// </summary>
        /// <returns></returns>
        public PostViewModel GetPostPage(string slug, int year, int month, int day) {
            var posts = _repo.GetPosts();

            var totalPosts = posts.Count();
            var totalComments = _repo.GetApprovedComments().Count();
            Post post = null;

            post = _repo.GetPost(slug, year, month, day);

            var related = _repo.GetRelatedPosts(post);

            return new PostViewModel(post, related,totalPosts, totalComments);

        }
    }
}
