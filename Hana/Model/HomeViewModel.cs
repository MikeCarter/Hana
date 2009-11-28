using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;
using System.Web.Mvc;

namespace Hana.Model {
    
    public class HomeViewModel :ViewModelBase{
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

        public IList<Category> Categories { get; set; }
        public IList<PostView> PopularPosts { get;  private set; }
        public IList<PostView> RecentPosts { get;  private set; }
        public IList<PostView> SubSonicPosts { get;  private set; }
        public IList<PostView> TekpubPosts { get;  private set; }


    }
}
