<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeViewModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Blog.BlogName %>: <%=Blog.BlogTagLine %>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<%Html.RenderPartial("Ribbon"); %>  
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
	            url: 'http://twitter.com/statuses/user_timeline/81883339.rss'
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
    
        <h1>Hi There</h1>
        <p>
            If you've just downloaded this blog you're probably wondering what it looks like and how it works. Well here ya go!
            I'll try to outline the steps for you here - but know that this is supposed to get you to about 80%, *you* get to
            do the rest yourself. That's the point!
        </p>
        <h2>Setting Things Up</h2>
        <p>
            In no particular order you will probably want to...
            <ul>
                <li>Open up /model/blog.cs and change up all the constant values</li>
                <li>Reset the Twitter link to the right to point to  your own stuff. You do that on this page (/views/home/index.aspx)</li>
                <li>Next you'll want to install a database. The scripts are in /DBScripts.</li>
                <li>As far as Importing data goes - check out the WordPress importer project. If you're not on WordPress you can use
                it as a template for how to get rolling.
                </li>
                <li>There's nothing on the Contact and Resume pages - you might want to update those.</li>
            
            </ul>
        
        </p>
    
        <!--BEGIN FEATURED POST-->
        <%foreach (PostView post in Model.RecentPosts){%>
            <%Html.RenderPartial("PostSummary", post); %>
        <%} %>
        <h3><a href="<%=Url.Action("Index","Archive") %>">More >>> </a></h3>
    </div>
    
    <!-- SIDEBAR -->
    <div id="sidebar" class="column span-7">
        <div id="home_right" class="column" style="text-align:center">
            <div class="column" style="text-align:left">
                <h3>Categories</h3>
                <ul>
                <%foreach (var cat in Model.Categories.Where(x=>x.CategoryID>1)){%>
                  <li><a href="<%=Url.Action("Category","Archive",new {category=cat.Slug}) %>"><%=cat.Description %></a></li>
                      
                <%}%>
                </ul>
            
            </div>
            <h2>Twitter</h2>
            <div id="twitter" name="twitter" style="margin-bottom:24px;margin-top:12px"></div>
       </div>
    </div>
    
    <hr></hr>
    
    <!-- BOTTOM LEFT FOUR CATEGORY LISTINGS -->
    <div class="column span-7 colborder">
        <div class="five_posts">
           <h3>Popular</h3>
            <h6><a href="" rel="bookmark" title="Permalink to Post">Lorem Ipsum</a></h6> 
            <p class="byline">11/5/1624 | <a href="" title="Comment on Lorem Ipsum">Discuss</a></p> 
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis luctus aliquam massa at commodo. Vestibulum sagittis pulvinar nulla</p> 
            <h6>More Popular Posts</h6> 
            <ul>
            <%for(int i=0;i<5;i++) { %>
                <li><a href="" rel="bookmark" title="Permanent Link to Lorem Ipsum" class="title">Lorem Ipsum</a></li> 
            <%} %> 
            </ul> 
        </div>
    </div>
    <div class="column span-7 colborder">
        <div class="five_posts">
           <h3>Exciting and New</h3>
            <h6><a href="" rel="bookmark" title="Permalink to Post">Lorem Ipsum</a></h6> 
            <p class="byline">11/5/1624 | <a href="" title="Comment on Lorem Ipsum">Discuss</a></p> 
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis luctus aliquam massa at commodo. Vestibulum sagittis pulvinar nulla</p> 
            <h6>More Popular Posts</h6> 
            <ul>
            <%for(int i=0;i<5;i++) { %>
                <li><a href="" rel="bookmark" title="Permanent Link to Lorem Ipsum" class="title">Lorem Ipsum</a></li> 
            <%} %> 
            </ul> 
        </div>
    </div>
    
    <!-- LAST CATEGORY LISTING - NEEDED TO END CSS COLUMNS -->
    <div class="column span-7 last">
        <div class="five_posts">
           <h3>Hip and Cool</h3>
            <h6><a href="" rel="bookmark" title="Permalink to Post">Lorem Ipsum</a></h6> 
            <p class="byline">11/5/1624 | <a href="" title="Comment on Lorem Ipsum">Discuss</a></p> 
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis luctus aliquam massa at commodo. Vestibulum sagittis pulvinar nulla</p> 
            <h6>More Popular Posts</h6> 
            <ul>
            <%for(int i=0;i<5;i++) { %>
                <li><a href="" rel="bookmark" title="Permanent Link to Lorem Ipsum" class="title">Lorem Ipsum</a></li> 
            <%} %> 
            </ul> 
        </div>    
    </div>
</asp:Content>
