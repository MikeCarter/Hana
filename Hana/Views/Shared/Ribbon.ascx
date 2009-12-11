<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="column span-24" id="ribbon">
    <div class="column span-4"><a href="<%=Url.Action("Search","Archive") %>">Search the Archives</a></div>
    <div class="column span-15" style="text-align:center">Planet Earth, Solar System <%=DateTime.Now.ToShortDateString() %></div>
    <div class="column span-5  alignright last" ><%=Post.All().Count() %> Posts and Counting</div>
</div> 