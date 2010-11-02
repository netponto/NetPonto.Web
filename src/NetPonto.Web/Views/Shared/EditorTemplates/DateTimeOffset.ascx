<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DateTimeOffset?>" %>

<%string name = ViewData.TemplateInfo.HtmlFieldPrefix;%>  
<%string id = name.AsHtmlIdInTemplate();%>  
    
<%= Html.TextBoxFor(model => model) %>  
<%= Html.ValidationMessageFor(model => model) %>  
  
<script type="text/javascript">  
    $(document).ready(function() {  
  
        $("#<%=id%>").datepicker({  
            dateFormat: 'dd/mm/yy'
        });  
    });  
</script>  