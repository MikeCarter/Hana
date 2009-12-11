<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArchiveViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Blog.BlogName %>: Archive
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="/scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="/scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(window).scroll(function() {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            loadMore();
        }
    });
var current=0;
function loadMore() {

    if (current > -1) {
        current++;

        $('#loading').html("<img src='/content/images/bigloader.gif' />");
        $.get("/<%=Model.ThisAction %>/<%=Model.ThisTerm %>/" + current,
        function(data) {

            if (data != '') {
                $('#results').append(data);
                $('#loading').empty();
            } else {
                current = -1;
                $('#loading').html("<h3><i>-- No more results -- </i></h3>");
            }
            

        });
    }
}
</script>


    <%Html.RenderPartial("Ribbon"); %>  
    
    <div class="column span-17 colborder">
        <div id="results">
        <!--BEGIN FEATURED POST-->
        <%foreach (PostView post in Model.PostList)
          {%>
            <%Html.RenderPartial("PostSummary", post); %>
        <%} %>
        </div>
        <div class="column span-16" id="loading" style="height:100px;text-align:center">
        
        </div>
    </div>
    
    <!-- SIDEBAR -->
    <div id="sidebar" class="column span-4 last">
        <div id="home_right" class="column" style="text-align:center">
            <div class="column" style="text-align:left">
                <img src="/content/images/categories.png" />
                <ul>
                <%foreach (var cat in Model.Categories.Where(x=>x.CategoryID>1)){%>
                  <li><a href="<%=Url.Action("Category","Archive",new {category=cat.Slug}) %>"><%=cat.Description %></a></li>
                      
                <%}%>
                </ul>
            
            </div>         
        </div>
    </div>
</asp:Content>

