using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Hana.Model {
    public interface IBlogRepository {

        IQueryable<Post> GetPosts();
        IQueryable<Post> GetPosts(Category category);
        IQueryable<Comment> GetApprovedComments();
        Post GetPost(string slug, int year, int month, int day);
        IList<Post> GetRelatedPosts(Post post);
    }
}
