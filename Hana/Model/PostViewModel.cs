using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;
using System.Web.Mvc;

namespace Hana.Model {
    
    

    public class PostViewModel : ViewModelBase {
        public PostViewModel(IEnumerable<Post> related, IEnumerable<Comment> comments) {
            Related = new List<PostView>();
            Comments=new List<CommentView>();

            related.ToList().ForEach(x => Related.Add(new PostView(x)));

            //structure the comments
            var commentList=new List<CommentView>();
            comments.ForEach(x => commentList.Add(new CommentView(x)));

            //load parents
            Comments = commentList.Where(x => x.ParentID == 0).ToList();

            //load replies
            Comments.ForEach(x => x.Replies = commentList.Where(y => y.ParentID == x.ID).ToList());

        }
        public PostView SelectedPost { get; set; }
        public IList<PostView> Related { get; set; }
        public IList<CommentView> Comments { get; set; }

    }
}
