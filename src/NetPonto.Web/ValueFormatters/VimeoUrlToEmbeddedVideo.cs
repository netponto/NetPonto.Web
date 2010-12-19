using System;
using System.Text.RegularExpressions;
using AutoMapper;

namespace NetPonto.Web.ValueFormatters
{
    internal class VimeoUrlToEmbeddedVideo : IValueFormatter
    {
        private static readonly Regex GetId = new Regex(@"http://vimeo.com/(?<id>\d+)",
                                                        RegexOptions.Compiled);

        private const string Template = @"<iframe src=""http://player.vimeo.com/video/{0}?portrait=0"" width=""400"" height=""300"" frameborder=""0"">
</iframe>

";
        public string FormatValue(ResolutionContext context)
        {
            var url = ((Uri) context.SourceValue);
            if (url == null)
            {
                return string.Empty;
            }

            var match = GetId.Match(url.ToString());
            var id = match.Groups["id"];
            return string.Format(Template, id);
        }
    }
}