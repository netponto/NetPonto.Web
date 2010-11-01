<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NetPonto.Web.Models.Event.Edit+SchedulePart>" %>

<%= Html.HiddenFor(s => s.Id) %>
            
<span class="editor-field">
    <span class="time"
        <%= Html.EditorFor(model => model.Hours) %>
        <%= Html.ValidationMessageFor(model => model.Hours) %>
    :
        <%= Html.EditorFor(model => model.Minutes) %>
        <%= Html.ValidationMessageFor(model => model.Minutes) %>
    </span>
    -
    <%= Html.TextBoxFor(model => model.Name, new {size = 50}) %>
    <%= Html.ValidationMessageFor(model => model.Name) %>
</span>
   
            
        



