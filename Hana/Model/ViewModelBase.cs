using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model {

    public class CommentView {
        public CommentView(Comment comment) {
            Author = comment.Author;
            Email = comment.Email;
            CreatedOn = comment.CreatedOn;
            Body = comment.Body;
            Url = comment.URL;
            ParentID=comment.ParentID;
            Replies=new List<CommentView>();
            ID=comment.CommentID;

        }
        public string Author { get; set; }
        public string Permalink { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public int ParentID { get; set; }
        public IList<CommentView> Replies;
        public int ID { get; set; }
        public string AuthorFormatted {
            get {
                string result = Author;
                if (!string.IsNullOrEmpty(Url)) {
                    result = string.Format("<a href='{0}' 'target=_blank'>{1}</a>", Url, Author);
                }
                return result;
            }
        }
    }


    public class PostView {
        public PostView(Post post) {
            Slug = post.Slug;
            Title = post.Title;
            Body = post.Body;
            Author = "Rob Conery";
            PublishedAt = post.PublishedOn;
            CommentCount = post.CommentCount;
            Summary = post.Excerpt;
        }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public long CommentCount { get; set; }
        public string Summary { get; set; }

    }
    
    public class ViewModelBase {



    
    }
}
