<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PostViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Blog.BlogName %>: <%=Model.SelectedPost.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%Html.RenderPartial("Ribbon"); %>  

<div class="column span-19 colborder">
<div id="post">
    <h2><%=Model.SelectedPost.Title %></h2>
     <p>
        <b><%=Model.SelectedPost.PublishedAt.ToLongDateString() %></b> - <%=Model.SelectedPost.Body %>
    </p>
   <div class="column span-3">
    <script type="text/javascript" src="http://www.reddit.com/button.js?t=3"></script>
    </div>
    <div class="column span-5" style="padding-top:10px">
        <div id="dnk"></div>
        <script type="text/javascript">
            addLoadEvent(AddDotNetKicks);

            function addLoadEvent(fn) {
                if (window.addEventListener)
                    window.addEventListener('load', fn, false)
                else if (window.attachEvent)
                    window.attachEvent('onload', fn);
            }

            function AddDotNetKicks() {
                var insertLocation = document.getElementById('dnk');
                if (insertLocation) {
                    var currentPageUrl = document.location.protocol + "//" + document.location.host + document.location.pathname;
                    var dotnetkicksLink = document.createElement('a');
                    dotnetkicksLink.href = 'http://www.dotnetkicks.com/kick/?url=' + currentPageUrl;
                    var dotnetkicksImg = document.createElement('IMG');
                    dotnetkicksImg.src = 'http://www.dotnetkicks.com/Services/Images/KickItImageGenerator.ashx?url=' + currentPageUrl;
                    dotnetkicksImg.border = 0;
                    dotnetkicksLink.appendChild(dotnetkicksImg);
                    insertLocation.appendChild(dotnetkicksLink);
                }
            }
        
        </script>
    </div> 
    </div>
</div>

<div class="column span-4 last">
    <p>
    <div id="adzerk">
        <div id="adzerk_ad_div">
            <script type="text/javascript" src="http://engine.theloungenet.com/Server/DOTNET/RCONERY/VERT"></script>
        </div>
        <p id="adzerk_by">
            <a href='http://theloungenet.com'>Ads by The Lounge</a>
        </p>
    </div>
    </p>
    <p>
    <h3>Related</h3>
     <p>
        <ul>
        <%foreach (var item in Model.Related) {%>
            <li><a href="<%=Url.Action("Details","Posts",new {id=item.Slug})%>" rel="bookmark" title="Permanent Link to <%=item.Title %>" class="title"><%=item.Title%></a></li> 
          <%} %>
        </ul>
     </p>
    
</div>

<hr />

<div id="comments" class="column span-24 last">

<%foreach(var comment in Model.Comments) { %>
 <div class="column comment">
    <div class="column span-3" style="text-align:center">
        <div>
            <%=Html.Gravatar(comment.Email,90) %>
        </div>
    </div>
    <div class="column span-13 append-2">
         <span class="comment-author"><%=comment.AuthorFormatted %></span> - <b><%=comment.CreatedOn.ToLongDateString() %></b> - 
         <%=comment.Body.Replace("\r","<br/>") %>
    </div>
</div>
<%} %>

<div id="disqus_thread" class="column span-15"></div><script type="text/javascript" src="http://disqus.com/forums/wekeroad/embed.js"></script><noscript><a href="http://disqus.com/forums/wekeroad/?url=ref">View the discussion thread.</a></noscript>

<div class="column last"></div>
</div>


<script type="text/javascript">
//<![CDATA[
(function() {
	var links = document.getElementsByTagName('a');
	var query = '?';
	var disqus_developer = 1;

	for(var i = 0; i < links.length; i++) {
	if(links[i].href.indexOf('#disqus_thread') >= 0) {
		query += 'url' + i + '=' + encodeURIComponent(links[i].href) + '&';
	}
	}
	document.write('<script charset="utf-8" type="text/javascript" src="http://disqus.com/forums/wekeroad/get_num_replies.js' + query + '"></' + 'script>');
})();
//]]>
</script>

</asp:Content>
