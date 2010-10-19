using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using NetPonto.Services;

namespace NetPonto.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString IncludeCss(this HtmlHelper self, params string[] cssFiles)
        {
            var urlHelper = self.CreateUrlHelper();
            var links = new StringBuilder();

            foreach (var cssFile in cssFiles)
            {
                var link = new TagBuilder("link");
                link.Attributes["href"] = urlHelper.Content("~/content/css/" + cssFile);
                link.Attributes["rel"] = "stylesheet";
                link.Attributes["type"] = "text/css";
                links.AppendLine(link.ToString(TagRenderMode.SelfClosing));
            }

            return MvcHtmlString.Create(links.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper self, string imageFile, string altText = null)
        {
            var urlHelper = self.CreateUrlHelper();

            var link = new TagBuilder("img");
            link.Attributes["src"] = urlHelper.Image(imageFile);
            link.Attributes["alt"] = altText ?? "";

            return MvcHtmlString.Create(link.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString IncludeJs(this HtmlHelper self, params string[] srcFiles)
        {
            var urlHelper = self.CreateUrlHelper();

            var links = new StringBuilder();

            foreach (var srcFile in srcFiles)
            {
                var link = new TagBuilder("script");
                link.Attributes["src"] = urlHelper.Content("~/scripts/" + srcFile);
                link.Attributes["type"] = "text/javascript";
                links.AppendLine    (link.ToString(TagRenderMode.Normal));
            }
            return MvcHtmlString.Create(links.ToString());
        }

        public static void RenderAdminPartial(this HtmlHelper self, string partialView)
        {
            if (self.ViewContext.HttpContext.User.IsInRole(SiteRoles.Administrator))
            {
                self.RenderPartial(partialView);
            }
        }

        private static UrlHelper CreateUrlHelper(this HtmlHelper self)
        {
            return new UrlHelper(self.ViewContext.RequestContext);
        }
    }
}