<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArchiveViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Blog.BlogName %>: Search <%=Html.Encode(Model.SearchTerm) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="/scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="/scripts/jquery.form.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function() {
        var options = {
            target: '#results',
            success: after 
        };

        // bind form using 'ajaxForm'
        $('#searchForm').submit(function() {
            $('#results').empty();
            $('#loading').html("<img src='/content/images/bigloader.gif' />");
            $(this).ajaxSubmit(options);
            return false; 
        });
    });
    // post-submit callback
    function after(responseText, statusText) {
        if (responseText == "") {
            $('#loading').html("<h3><i>-- No results -- </i></h3>");
        } else {
            $('#loading').empty();
        }
    }
 
</script>
    <%Html.RenderPartial("Ribbon"); %>
    <div class="column span-24" style="margin-bottom: 20px">
        <h1>The Honu Answers All</h1>
        <form action="<%=Url.Action("Search") %>" method="post" id="searchForm">
        <div class="column span-15 ">
            <input name="q" id="query" size="48" class="txt" style="font-size: 1.8em; font-family: Georgia;
                color: #808080; border: 4px solid #f5f5f5; padding: 8px;" title="pet honu to find your sunglasses..."
                value="<%=Html.AttributeEncode(Model.SearchTerm) %>" />
        </div>
        <div class="column span-2 ">
            <input type="image" src="/content/images/honu.gif" style="border: 0; width: 50px;"
                align="middle" />
        </div>
        </form>
  
    </div>

    <div class="column span-17 colborder" style="margin-top: 20px">
        <div id="results">
        </div>
        <div class="column span-16" id="loading" style="height: 100px; text-align: center">
        </div>
    </div>  
    <!-- SIDEBAR -->
    <div id="sidebar" class="column span-3 last">
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
                
       </div>
    </div>   
</asp:Content>
