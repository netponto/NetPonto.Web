<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="menu-secondary-menu-container">
    <ul class="menu">
    <%
        if (Request.IsAuthenticated) {
    %>
            Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
            <li class="menu-item menu-item-type-post_type">
                <%= Html.ActionLink("Log Off", "LogOff", "Account") %>
            </li>
    <%
        }
        else {
    %> 
            <li class="menu-item menu-item-type-post_type">
                <%= Html.ActionLink("Log On", "LogOn", "Account") %>
            </li>
    <%
        }
    %>
    </ul>
</div>