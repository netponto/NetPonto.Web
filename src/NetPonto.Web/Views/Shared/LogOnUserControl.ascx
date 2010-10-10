<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="menu-secondary-menu-container">
    <ul class="menu">
    <%
        if (Request.IsAuthenticated) {
    %>
            <li class="menu-item menu-item-type-post_type">
                <%= Html.ActionLink("Log off "+Page.User.Identity.Name, "LogOff", "Account") %>
            </li>
    <%
        }
        else {
    %> 
            <li class="menu-item menu-item-type-post_type">
                <%= Html.ActionLink("Log on", "LogOn", "Account") %>
            </li>
    <%
        }
    %>
    </ul>
</div>