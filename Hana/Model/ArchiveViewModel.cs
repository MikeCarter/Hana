using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model
{
    public class ArchiveViewModel:ViewModelBase
    {

        public ArchiveViewModel(IEnumerable<Post> posts)
        {
            PostList = new List<PostView>();
            posts.ToList().ForEach(x => PostList.Add(new PostView(x)));

        }

        
        public IList<PostView> PostList { get; private set; }
        public IList<Category> Categories { get; set; }
        public string SearchTerm { get; set; }
        public string ThisAction { get; set; }
        public string ThisTerm { get; set; }
    }
}
