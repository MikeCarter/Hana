<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Blog.BlogName %>: Resume
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Ribbon"); %>  
    <div id="feature" class="column span-15 colborder">
        <h2>Your Resume Here</h2>

        
    </div>
    
</asp:Content>
