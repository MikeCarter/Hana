using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;

namespace Hana.Model {
    
    
    public class PostView{
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

    public class HomeViewModel {
        //IList<PostView> 
        public HomeViewModel(
                IEnumerable<Post> recent,
                IEnumerable<Post> subsonic,
                IEnumerable<Post> popular,
                IEnumerable<Post> tekpub
           
            )
        
        {
            PopularPosts=new List<PostView>();
            RecentPosts = new List<PostView>();
            SubSonicPosts = new List<PostView>();
            TekpubPosts = new List<PostView>();

            popular.ToList().ForEach(x => PopularPosts.Add(new PostView(x)));
            recent.ToList().ForEach(x => RecentPosts.Add(new PostView(x)));
            subsonic.ToList().ForEach(x => SubSonicPosts.Add(new PostView(x)));
            tekpub.ToList().ForEach(x => TekpubPosts.Add(new PostView(x)));

            
        }

        public int TotalPosts { get; set; }
        public int TotalComments { get; set; }
        public int VolumeNumber {
            get {
                
                //volume should be the number of  weeks since I started blogging :)
                //which was... I think November of 2004. Ahhh... .Text....
                var then = new DateTime(2004,11,1);
                var now = DateTime.Now;

                var ticks = now.Subtract(then);
                var days = ticks.Days;

                return days / 7;
            }
        }

        public IList<PostView> PopularPosts { get;  private set; }
        public IList<PostView> RecentPosts { get;  private set; }
        public IList<PostView> SubSonicPosts { get;  private set; }
        public IList<PostView> TekpubPosts { get;  private set; }


    }
}
