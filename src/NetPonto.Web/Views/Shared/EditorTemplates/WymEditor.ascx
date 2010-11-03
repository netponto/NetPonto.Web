<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>

<%string name = ViewData.TemplateInfo.HtmlFieldPrefix;%>  
<%
  string id = name.AsHtmlIdInTemplate();%>  
    
<%= Html.TextAreaFor(model => model) %>  
<%= Html.ValidationMessageFor(model => model) %>  
  
<script type="text/javascript">
    $(document).ready(function () {

        $("#<%=id%>").wymeditor();
    });  
</script>  