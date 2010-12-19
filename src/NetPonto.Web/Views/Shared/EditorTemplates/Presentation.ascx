<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NetPonto.Web.Models.Event.Edit+Presentation>" %>
     
<%= Html.HiddenFor(model => model.Id) %>

<div class="editor-label">
    <%= Html.LabelFor(model => model.Description) %>
</div>
<div class="editor-field">
    <%= Html.EditorFor(model => model.Description) %>
    <%= Html.ValidationMessageFor(model => model.Description) %>
</div>
            
<div class="editor-label">
    <%= Html.LabelFor(model => model.Presenter) %>
</div>
<div class="editor-field">
    <%= Html.EditorFor(model => model.Presenter) %>
    <%= Html.ValidationMessageFor(model => model.Presenter) %>
</div>
     


