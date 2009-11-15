<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeViewModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="http://www.google.com/jsapi?key=ABQIAAAAXDxCekvc3BRLZSw2AaTpVhRk2KHjkhDr-AinWwGiTLTg4BpP1RQkA87A7cGo2bXtxIFVC9ui4LIlSw"></script>
  <script src="http://www.google.com/uds/solutions/dynamicfeed/gfdynamicfeedcontrol.js"
    type="text/javascript"></script>
  <style type="text/css">
    @import url("/content/css/newsfeed.css");
  </style>
  <script type="text/javascript">
      function LoadDynamicFeedControl() {
          var feeds = [
	        {
	            title: 'Twitter',
	            url: 'http://twitter.com/statuses/user_timeline/5721912.rss'
	        }
	        ];
          var options = {
 
              stacked: true,
              horizontal: false,
              numResults: 5
          }
          new GFdynamicFeedControl(feeds, 'twitter', options);
      }
      // Load the feeds API and set the onload callback.
      google.load('feeds', '1');
      google.setOnLoadCallback(LoadDynamicFeedControl);
  </script>

    <!--START LEFT SIDE-->
    <script type="text/javascript" src="http://v6.flickrshow.com/scripts/"></script>
    <div id="feature" class="column span-15 colborder">
        <!--BEGIN FEATURED POST-->
        <%foreach (PostView post in Model.RecentPosts){%>
        <h2>
            <a href="/posts" rel="bookmark" title="Permanent Link to <%=post.Title %>!"
                class="title"><%=post.Title %></a></h2>
        <p>
            <b><%=post.PublishedAt.ToLongDateString() %></b> - <%=post.Summary %></p>
    
            <p class="postmetadata"> <a href="http://graphpaperpress.com/demo/modularity/category/arts/" title="View all posts in Arts" rel="category tag">Arts</a>,  <a href="http://graphpaperpress.com/demo/modularity/category/culture/" title="View all posts in Culture" rel="category tag">Culture</a>  | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/eighth-test-post/#respond" title="Comment on Eighth Test Post">Leave A Comment &#187;</a>  </p> 
        <%} %>
        
    
    </div>
    
    <!-- BEGIN THREE AT RIGHT -->
    <div class="column span-8 last">
        <div id="home_right">
            <h3>Twitter</h3>
            <div id="twitter" name="twitter"></div>
           <h3>Pix</h3>
           <iframe align="center" src="http://www.flickr.com/slideShow/index.gne?user_id=91469966@N00&" frameBorder="0" width="300" scrolling="no" height="250"></iframe>
       </div>
    </div>
    
    <hr></hr>
    
    <!-- BOTTOM LEFT FOUR CATEGORY LISTINGS -->
    <div class="column span-7 colborder">
        <div class="five_posts">
               <%var popFirst = Model.PopularPosts.First(); %>
                <h6><a href="<%=Url.Action("Details","Posts",new {id=popFirst.Slug})%> rel="bookmark" title="Permalink to <%=popFirst.Title %>"><%=popFirst.Title %></a></h6> 
                <p class="byline"><%=popFirst.PublishedAt.ToShortDateString() %> | <a href="<%=Url.Action("Details","Posts",new {id=popFirst.Slug})%>/#comments" title="Comment on <%=popFirst.Title %>">Discuss</a></p> 
                <p><%=popFirst.Summary %></p> 
                <h6>More Popular Posts</h6> 
                <ul>
                <%foreach (var pop in Model.PopularPosts.Skip(1)) { %>
                    <li><a href="<%=Url.Action("Details","Posts",new {id=pop.Slug})%>" rel="bookmark" title="Permanent Link to <%=pop.Title %>" class="title"><%=pop.Title %></a></li> 
                <%} %> 
                </ul> 
                
        </div>
    </div>
    <div class="column span-7 colborder">
        <div class="five_posts">
               <%var subFirst = Model.SubSonicPosts.First(); %>
                <h6><a href="<%=Url.Action("Details","Posts",new {id=subFirst.Slug})%> rel="bookmark" title="Permalink to <%=subFirst.Title %>"><%=subFirst.Title %></a></h6> 
                <p class="byline"><%=subFirst.PublishedAt.ToShortDateString()%> | <a href="<%=Url.Action("Details","Posts",new {id=subFirst.Slug})%>/#comments" title="Comment on <%=subFirst.Title %>">Discuss</a></p> 
                <p><%=subFirst.Summary%></p> 
                <h6><a href="/category/subsonic">More SubSonic</a></h6> 
                <ul>
                <%foreach (var pop in Model.SubSonicPosts.Skip(1)) { %>
                    <li><a href="<%=Url.Action("Details","Posts",new {id=pop.Slug})%>" rel="bookmark" title="Permanent Link to <%=pop.Title %>" class="title"><%=pop.Title %></a></li> 
                <%} %> 
                </ul> 

        </div>
    </div>
    
    <!-- LAST CATEGORY LISTING - NEEDED TO END CSS COLUMNS -->
    <div class="column span-7 last">
        <div class="five_posts">
        <h6><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/sixth-test-post/" rel="bookmark" title="Permanent Link to Sixth Test Post">Sixth Test Post</a></h6> 
        <p class="byline">Oct 05, 2008 | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/sixth-test-post/#respond" title="Comment on Sixth Test Post">Discuss</a></p> 
        <p>Nulla faucibus erat non pede. Pellentesque imperdiet, diam ut elementum aliquet, mi felis placerat r</p> 
        <h6><a href="http://graphpaperpress.com/demo/modularity/category/music/">More Favorites</a></h6> 
        <ul> 
        <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fifth-test-post/" rel="bookmark" title="Permanent Link to Fifth Test Post" class="title">Fifth Test Post</a></li> 
        <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fourth-test-post/" rel="bookmark" title="Permanent Link to Fourth Test Post" class="title">Fourth Test Post</a></li> 
        <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/third-test-post/" rel="bookmark" title="Permanent Link to Third Test Post" class="title">Third Test Post</a></li> 
        <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/second-test-post/" rel="bookmark" title="Permanent Link to Second Test Post" class="title">Second Test Post</a></li> 
        <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/03/first-test-pos/" rel="bookmark" title="Permanent Link to First Test Post" class="title">First Test Post</a></li> 
        </ul>      
            
        </div>
    </div>
</asp:Content>
