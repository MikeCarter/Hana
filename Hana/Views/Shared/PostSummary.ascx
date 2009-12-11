<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PostView>" %>

            <div class="column">
            <h2>
            <a href="<%=Url.Action(
            "Details","Posts", 
                new {
                    year=Model.PublishedAt.Year,
                    month=Model.PublishedAt.Month.FormattedDayMonth(), 
                    day=Model.PublishedAt.Day.FormattedDayMonth(),
                    id=Model.Slug
                    }) 
            %>" 
            rel="bookmark" title="Permanent Link to <%=Model.Title %>!"
                class="title"><%=Model.Title %></a></h2>
            <p style="margin-bottom:10px"> <b><%=Model.PublishedAt.ToLongDateString()%></b> - <%=Model.Summary%></p>
    
            </div>
            <div class="column span-15" style="text-align:center;margin-bottom:16px">
                --
            </div>