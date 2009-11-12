using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Query;

namespace Hana.Model.Repo {
    public class WPRepository:IBlogRepository {


        IQueryable<Comment> TranslateComment(IQueryable<WP.wp_comment> query) {
            return from c in query
                   select new Comment {
                       Author=c.comment_author,
                       AuthorUrl=c.comment_author_url,
                       Body=c.comment_content,
                       CreatedAt=c.comment_date,
                       Email=c.comment_author_email,
                       ID=(ulong)c.comment_ID,
                       PostID=(ulong)c.comment_post_ID,
                       ReplyToID=c.comment_reply_ID,
                       IP=c.comment_author_IP,
                       IsApproved=c.comment_approved=="1"
                       
                   };
        }

        IQueryable<Post> TranslatePost(IQueryable<WP.wp_post> query) {
            return from p in query
                   join a in WP.wp_user.All() on p.post_author equals a.ID
                   select new Post {
                       ID = (ulong)p.ID,
                       Author = a.display_name,
                       Body = p.post_content,
                       CreatedAt = p.post_date,
                       Excerpt = p.post_excerpt,
                       ModifiedAt = p.post_modified,
                       PublishedAt = p.post_date,
                       Slug = p.post_name,
                       Status = p.post_status,
                       Title = p.post_title

                   };
        }

        public IQueryable<Post> GetPosts() {
            return TranslatePost(WP.wp_post.All());
        }

        public IQueryable<Post> GetPosts(Category category) {
            var query = from p in WP.wp_post.All()
                        join tr in WP.wp_term_relationship.All() on p.ID equals tr.object_id
                        join tx in WP.wp_term_taxonomy.All() on tr.term_taxonomy_id equals tx.term_taxonomy_id
                        join t in WP.wp_term.All() on tx.term_id equals t.term_id
                        where t.name == category.Description
                        select p;
            return TranslatePost(query);
        }

        public IQueryable<Comment> GetApprovedComments() {
            var query = from c in WP.wp_comment.All()
                        where c.comment_approved == "1"
                        select c;
            return TranslateComment(query);
        }

        public Post GetPost(string slug, int year, int month, int day) {
            var post = GetPosts().Where(x => x.Slug == slug).SingleOrDefault();

            if (post != null)
                //add the comments
                post.Comments = new Select().From<Comment>().Where<Comment>(x => x.PostID == post.ID).ToList<Comment>();

            return post;
        }

        public IList<Post> GetRelatedPosts(Post post) {
            return new List<Post>();
        }

    }
}
