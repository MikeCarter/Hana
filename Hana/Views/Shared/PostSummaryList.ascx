<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PostView>>" %>
        <%foreach (PostView post in Model)
          {%>
            <%Html.RenderPartial("PostSummary", post); %>
        <%} %>