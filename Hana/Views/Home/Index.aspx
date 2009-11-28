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
            <%Html.RenderPartial("PostSummary", post); %>
        <%} %>
        <h3><a href="<%=Url.Action("Index","Archive") %>">More >>> </a></h3>
    </div>
    
    <!-- SIDEBAR -->
    <div id="sidebar" class="column span-7">
        <div id="home_right" class="column" style="text-align:center">
                <div id="adzerk" class="column">
                    <div id="adzerk_ad_div" class="column">
                        <script type="text/javascript" src="http://engine.theloungenet.com/Server/DOTNET/RCONERY/VERT"></script>
                    </div>
                    <p id="adzerk_by">
                        <a href='http://theloungenet.com'>Ads by The Lounge</a>
                    </p>
                </div>
            <div class="column" style="text-align:left">
                <img src="/content/images/categories.png" />
                <ul>
                <%foreach (var cat in Model.Categories.Where(x=>x.CategoryID>1)){%>
                  <li><a href="<%=Url.Action("Category","Archive",new {category=cat.Slug}) %>"><%=cat.Description %></a></li>
                      
                <%}%>
                </ul>
            
            </div>
            <img src="/content/images/twitter.png" />
            <div id="twitter" name="twitter" style="margin-bottom:24px;margin-top:12px"></div>
       </div>
    </div>
    
    <hr></hr>
    
    <!-- BOTTOM LEFT FOUR CATEGORY LISTINGS -->
    <div class="column span-7 colborder">
        <div class="five_posts">
               <img src="/content/images/popular.png" />
               <%var popFirst = Model.PopularPosts.First(); %>
                <h6><a href="<%=Url.Action(
            "Details","Posts", 
                new {
                    year=popFirst.PublishedAt.Year,
                    month=popFirst.PublishedAt.Month.FormattedDayMonth(), 
                    day=popFirst.PublishedAt.Day.FormattedDayMonth(),
                    id=popFirst.Slug
                    }) 
            %>" rel="bookmark" title="Permalink to <%=popFirst.Title %>"><%=popFirst.Title %></a></h6> 
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
                <img src="/content/images/subsonic.png" />
              <%var subFirst = Model.SubSonicPosts.First(); %>
                <h6><a href="<%=Url.Action(
            "Details","Posts", 
                new {
                    year=subFirst.PublishedAt.Year,
                    month=subFirst.PublishedAt.Month.FormattedDayMonth(), 
                    day=subFirst.PublishedAt.Day.FormattedDayMonth(),
                    id=subFirst.Slug
                    }) 
            %>" rel="bookmark" title="Permalink to <%=subFirst.Title %>"><%=subFirst.Title %></a></h6> 
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
            <img src="/content/images/pictures.png" style="margin-bottom:38px;margin-top:20px;" />
            <iframe align="center" src="http://www.flickr.com/slideShow/index.gne?user_id=91469966@N00&" frameBorder="0" width="300" scrolling="no" height="250"></iframe>


        </div>
    </div>
</asp:Content>
