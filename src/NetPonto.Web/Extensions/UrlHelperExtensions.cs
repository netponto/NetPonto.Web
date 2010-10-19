using System.Web.Mvc;

namespace NetPonto.Web.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string Image(this UrlHelper self, string imageFile)
        {
            return self.Content("~/content/image/" + imageFile);
        }
    }
}