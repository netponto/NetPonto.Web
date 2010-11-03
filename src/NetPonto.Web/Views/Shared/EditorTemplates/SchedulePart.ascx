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

<% if (Model.Presentation != null)
   {  %>
<div class="presentation">
    <fieldset>
        <legend>Presentation</legend>
        <%= Html.EditorFor(model => model.Presentation)%>
        <div class="remove">
            <a href="#" onclick="removePresentation(<%= Model.Id %>); return false;">remove this presentation</a>
        </div>
    </fieldset>
</div>
<% }else if(Model.Id.HasValue){%>
    <a href="#" onclick="addPresentation(<%= Model.Id %>); return false;">add presentation to this schedule part</a>
<%}%>