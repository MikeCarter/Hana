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
   <h3>Side Column Stuff</h3>

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

<h2>Comment Code Here</h2>
<p>Check out Disqus - I like them a lot. Also jsKit</p>


<div class="column last"></div>
</div>


</asp:Content>
