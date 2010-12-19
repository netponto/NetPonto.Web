using System;
using System.Text.RegularExpressions;

namespace NetPonto.Web.Extensions
{
    public static class EmbeddedItemsExtensions 
    {
        private static readonly Regex GetIdFromVimeoUrl = new Regex(@"http://vimeo.com/(?<id>\d+)",
                                                        RegexOptions.Compiled);

        private const string TemplateForVimeo = @"<iframe src=""http://player.vimeo.com/video/{0}?portrait=0"" width=""{1}"" height=""{2}"" frameborder=""0"">
</iframe>";

        private const string TemplateForSlideshare = @"<div style=""width:{2}px"" id=""{0}"">
                      <object id=""__sse1925010"" width=""{2}"" height=""{3}"">
                        <param name=""movie"" value=""http://static.slidesharecdn.com/swf/ssplayer2.swf?doc={1}"" />
                        <param name=""allowFullScreen"" value=""true""/>
                        <param name=""allowScriptAccess"" value=""always""/>
                        <embed name=""__sse1925010"" src=""http://static.slidesharecdn.com/swf/ssplayer2.swf?doc={1}"" type=""application/x-shockwave-flash"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""{2}"" height=""{3}""></embed>
                      </object>
                    </div>";

        private static readonly Regex GetIdAndDocFromSlideshareCode = new Regex(@"\[slideshare id=(?<id>\d+)&doc=(?<doc>[a-zA-Z0-9-]+)\]",
                                                              RegexOptions.Compiled);


        public static string RenderAsEmbeddedVimeoUrl(this Uri url)
        {
            return RenderAsEmbeddedVimeoUrl(url, 400, 300);
        }

        public static string RenderAsEmbeddedVimeoUrl(this Uri url, int width, int height)
        {
            var match = GetIdFromVimeoUrl.Match(url.ToString());
            var id = match.Groups["id"];
            return string.Format(TemplateForVimeo, id, width, height);
        }

        public static string RenderAsEmbeddedSlideshareCode(this string embedCode)
        {
            return RenderAsEmbeddedSlideshareCode(embedCode, 425, 300);
        }

        public static string RenderAsEmbeddedSlideshareCode(this string embedCode, int width, int height)
        {
            if (string.IsNullOrEmpty(embedCode))
            {
                return string.Empty;
            }

            var m = GetIdAndDocFromSlideshareCode.Match(embedCode);
            var id = m.Groups["id"];
            var doc = m.Groups["doc"];

            return string.Format(TemplateForSlideshare, id, doc, width, height);
        }
    }
}